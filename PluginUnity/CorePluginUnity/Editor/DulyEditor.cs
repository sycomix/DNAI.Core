﻿using System;
using Core.Plugin.Unity.Drawing;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Duly editor.
/// </summary>

// See also : https://msdn.microsoft.com/en-us/library/dd997372.aspx
// Custom editor example : https://github.com/Thundernerd/Unity3D-ExtendedEvent
// Unity event code source : https://bitbucket.org/Unity-Technologies/ui/src/0155c39e05ca5d7dcc97d9974256ef83bc122586/UnityEditor.UI/EventSystem/EventTriggerEditor.cs?at=5.2&fileviewer=file-view-default
// List of icons : https://gist.github.com/MattRix/c1f7840ae2419d8eb2ec0695448d4321
// Advanced reorderable list : https://forum.unity3d.com/threads/reorderable-list-v2.339717/
// Atlassian to advanced reordarable list : https://bitbucket.org/rotorz/reorderable-list-editor-field-for-unity
// Order list in editor : https://forum.unity3d.com/threads/reorderablelist-in-the-custom-editorwindow.384006/
// Unity Decompiled : https://github.com/MattRix/UnityDecompiled/blob/master/UnityEditor/UnityEditorInternal/ReorderableList.cs
// Saving window state : https://answers.unity.com/questions/119978/how-do-i-have-an-editorwindow-save-its-data-inbetw.html
// Serialization rules in Unity : https://blogs.unity3d.com/2012/10/25/unity-serialization/

// TODO : L'idée ce serait de faire un système comme les unity events, ou on chargerait un script,
// qui une fois chargé (avec des threads) afficherait les behaviours dispos
// Pour ce qui est de l'affichage, ce serait comme les unity events, mais avec un zone
// de texte pour mettre le path à la place du truc pour selectionner les objets, et au bout un bouton load.
// Si le fichier est bien load, ça montre tous les behaviours disponibles en dessous.

// Note : pour unity, si la .dll référence d'autres .dll cela provoque un crash au runtime. Deux solutions :
// soit copier toutes les .dll dans le dossier plugin, soit utiliser un utilitaire de merge de librairies
// cf : https://github.com/Microsoft/ILMerge/blob/master/ilmerge-manual.md

namespace Core.Plugin.Unity.Editor
{
    /// <summary>
    /// Duly editor, the unique, the one.
    /// </summary>
    public class DulyEditor : EditorWindow
    {
        private ScriptDrawer _scriptDrawer;
        private OnlineScriptDrawer _onlineScriptDrawer;
        private SettingsDrawer _settingsDrawer;
        private static DulyEditor _window;
        private static Texture _texture;
        private static GUIContent _settingsContent;

        public static DulyEditor Instance { get { return _window; } }

        public DulyEditor()
        {
            _window = this;
            //CloudFileWatcher.Watch(true);
        }

        //[MenuItem("Window/Duly")]
        //static void Init()
        //{
        //    // Get existing open window or if none, make a new one:
        //    if (_window == null)
        //    {
        //        _window = (DulyEditor)EditorWindow.GetWindow(typeof(DulyEditor));
        //        _window.titleContent = new GUIContent("Duly");
        //        _window.Show();
        //    }
        //    else
        //    {
        //        _window.Focus();
        //    }
        //    //DulyEditor window = (DulyEditor)EditorWindow.GetWindow(typeof(DulyEditor));
        //    //_window.titleContent = new GUIContent("Duly");
        //    //_window.Show();
        //}

        [MenuItem("Window/DNAI &d")]
        public static void ShowWindow()
        {
            if (_window == null)
            {
                _window = (DulyEditor)EditorWindow.GetWindow(typeof(DulyEditor));
                _texture = AssetDatabase.LoadAssetAtPath<Texture>(Constants.ResourcesPath + "dnai_logo.png");
                _window.titleContent = new GUIContent("DNAI", _texture);
                _window.Show();
            }
            else
            {
                _window.Focus();
            }
        }

        Vector2 scrollPos;

        private void OnGUI()
        {
            if (_settingsContent == null)
                _settingsContent = EditorGUIUtility.IconContent("SettingsIcon", "|Settings");

            scrollPos = GUILayout.BeginScrollView(scrollPos);
            GUILayout.BeginHorizontal();
            DrawWindowTitle();
            if (GUILayout.Button(_settingsContent))
            {
                if (_settingsDrawer == null)
                    _settingsDrawer = CreateInstance<SettingsDrawer>();
                _settingsDrawer?.ShowAuxWindow();
            }
            GUILayout.EndHorizontal();

            EditorGUILayout.Space();

            DrawBuildButton();
            GUI.enabled = !EditorApplication.isPlaying;
            _scriptDrawer?.Draw();
            EditorGUILayout.Space();
            _onlineScriptDrawer?.Draw();

            GUILayout.EndScrollView();
        }

        private void OnEnable()
        {
            hideFlags = HideFlags.HideAndDontSave;
            //Debug.Log("[DulyEditor] On enable");
            if (_scriptDrawer == null)
            {
                //_scriptDrawer = ScriptableObject.CreateInstance<ScriptDrawer>();
                _scriptDrawer = new ScriptDrawer();
                _scriptDrawer.OnEnable();
            }
            if (_settingsDrawer == null)
            {
                //_settingsDrawer = CreateInstance<SettingsDrawer>();
            }
            if (_onlineScriptDrawer == null)
            {
                _onlineScriptDrawer = new OnlineScriptDrawer();
            }
        }

        private void OnDisable()
        {
            //Debug.Log("[DulyEditor] On disable");
            _scriptDrawer?.OnDisable();
            AssetDatabase.SaveAssets();
        }

        private void OnDestroy()
        {
            _scriptDrawer?.OnDestroy();
            AssetDatabase.SaveAssets();
        }

        #region Editor Drawing

        private void DrawWindowTitle()
        {
            GUILayout.FlexibleSpace();
            GUILayout.Label("DNAI Editor", EditorStyles.largeLabel);
            GUILayout.FlexibleSpace();
        }

        /// <summary>
        /// Draws the build button to the window.
        /// </summary>
        private void DrawBuildButton()
        {
            if (GUILayout.Button("Build"))
            {
                Context.UnityTask.Run(async () =>
                {
                    //await scriptManager.CompileAsync(_selectedScripts.FindIndices(x => x));
                    try
                    {
                        foreach (var script in _scriptDrawer.ListAI)
                        {
                            await script.scriptManager.CompileAsync();
                            AssetDatabase.ImportAsset(Constants.CompiledPath + script.scriptManager.AssemblyName + ".dll");
                        }
                    }
                    catch (System.IO.FileNotFoundException ex)
                    {
                        Debug.LogError($"Could not find the DNAI file {ex.FileName}. Make sure it exists in the Scripts folder.");
                    }
                }).ContinueWith((e) =>
                {
                    if (e.IsFaulted)
                    {
                        Debug.LogError(e?.Exception.GetBaseException().Message + " " + e?.Exception.GetBaseException().StackTrace);
                    }
                });
            }
        }

        #endregion Editor Drawing
    }
}