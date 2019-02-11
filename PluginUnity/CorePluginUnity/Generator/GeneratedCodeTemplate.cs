﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Core.Plugin.Unity.Generator
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Users\nicol\Source\Repos\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class GeneratedCodeTemplate : GeneratedCodeTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write(@"using System;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using CoreCommand;
using System.Collections.Generic;
using CorePackage;
using CorePackageCNTK;
//using UnityEditorInternal;
//using UnityEditor;
//using Core.Plugin.Unity.Editor.Conditions.Inspector;
//using Core.Plugin.Unity.Editor.Conditions;
using Core.Plugin.Unity.Runtime;

namespace DNAI.");
            
            #line 22 "C:\Users\nicol\Source\Repos\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n\t//namespace ");
            
            #line 24 "C:\Users\nicol\Source\Repos\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("\r\n\t//{\r\n\t\t///<summary>\r\n\t\t/// Base behaviour for DNAI IA.\r\n\t\t///</summary>\r\n\t\tpub" +
                    "lic class ");
            
            #line 29 "C:\Users\nicol\Source\Repos\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(" : DNAIScriptConditionRuntime\r\n\t\t{\r\n\t\t\t//[HideInInspector]\r\n\t\t\t//public List<Cond" +
                    "itionItem> _cdtList = new List<ConditionItem>();// { new ConditionItem() { cdt =" +
                    " new IntCondition() } };\r\n\r\n\t\t\t");
            
            #line 34 "C:\Users\nicol\Source\Repos\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
 foreach (var item in DataTypes)
			{
            
            #line default
            #line hidden
            this.Write("\t\t\t\t");
            
            #line 36 "C:\Users\nicol\Source\Repos\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t");
            
            #line 37 "C:\Users\nicol\Source\Repos\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\tpublic static string[] OutputsAsStrings = new string[]\r\n\t\t\t{\r\n\t\t\t\t\"No Output" +
                    " Selected\",\r\n\t\t\t\t");
            
            #line 42 "C:\Users\nicol\Source\Repos\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
 foreach (var item in Outputs)
				{
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t\"");
            
            #line 44 "C:\Users\nicol\Source\Repos\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item));
            
            #line default
            #line hidden
            this.Write("\",\r\n\t\t\t\t");
            
            #line 45 "C:\Users\nicol\Source\Repos\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t};\r\n\r\n\t\t\tpublic static string[] OutputsAsStringsQualified = new string[]\r\n\t\t\t{" +
                    "\r\n\t\t\t\t\"void\",\r\n\t\t\t\t");
            
            #line 51 "C:\Users\nicol\Source\Repos\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
 foreach (var item in Outputs)
				{
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\ttypeof(");
            
            #line 53 "C:\Users\nicol\Source\Repos\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item.Split(' ')[0]));
            
            #line default
            #line hidden
            this.Write(").AssemblyQualifiedName,\r\n\t\t\t\t");
            
            #line 54 "C:\Users\nicol\Source\Repos\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write(@"			};

			//[Serializable]
			//public class UnityEventOutputChange : UnityEvent<EventOutputChange>
			//{
			//}

			///<summary>
			/// Called when output values of the DNAI script change.
			///</summary>
			//public UnityEventOutputChange OnOutputChanged;

			//[Header(""Input variables"")]
			");
            
            #line 68 "C:\Users\nicol\Source\Repos\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
 foreach (var item in Inputs)
			{ 
            
            #line default
            #line hidden
            this.Write("\t\t\t\tpublic ");
            
            #line 70 "C:\Users\nicol\Source\Repos\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item));
            
            #line default
            #line hidden
            this.Write(";\r\n\t\t\t");
            
            #line 71 "C:\Users\nicol\Source\Repos\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t//[Header(\"Output variables\")]\r\n\t\t\t");
            
            #line 74 "C:\Users\nicol\Source\Repos\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
 foreach (var item in Outputs)
			{ 
            
            #line default
            #line hidden
            this.Write("\t\t\t\tprivate ");
            
            #line 76 "C:\Users\nicol\Source\Repos\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item.Split(' ')[0]));
            
            #line default
            #line hidden
            this.Write(" _");
            
            #line 76 "C:\Users\nicol\Source\Repos\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item.Split(' ')[1]));
            
            #line default
            #line hidden
            this.Write(";\r\n\t\t\t\tpublic ");
            
            #line 77 "C:\Users\nicol\Source\Repos\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\t{\r\n\t\t\t\t\tget { return _");
            
            #line 79 "C:\Users\nicol\Source\Repos\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item.Split(' ')[1]));
            
            #line default
            #line hidden
            this.Write("; }\r\n\t\t\t\t\tprivate set\r\n\t\t\t\t\t{\r\n\t\t\t\t\t\t_");
            
            #line 82 "C:\Users\nicol\Source\Repos\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item.Split(' ')[1]));
            
            #line default
            #line hidden
            this.Write(" = value;\r\n\t\t\t\t\t\t//OnOutputChanged.Invoke(new EventOutputChange { Value = value, " +
                    "ValueType = value.GetType(), Invoker = this });\r\n\t\t\t\t\t\t_cdtList.FindAll((x) => x" +
                    ".SelectedOutput == \"");
            
            #line 84 "C:\Users\nicol\Source\Repos\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(item));
            
            #line default
            #line hidden
            this.Write("\").ForEach((y) =>\r\n\t\t\t\t\t\t{\r\n\t\t\t\t\t\t\tif (y.Evaluate(value) && y.OnOutputChanged != " +
                    "null)\r\n\t\t\t\t\t\t\t\ty.OnOutputChanged.Invoke(new EventOutputChange { Value = value, V" +
                    "alueType = value.GetType(), Invoker = this });\r\n\t\t\t\t\t\t});\r\n\t\t\t\t\t}\r\n\t\t\t\t}\r\n\t\t\t");
            
            #line 91 "C:\Users\nicol\Source\Repos\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\tprivate static readonly BinaryManager _manager = new BinaryManager();\r\n\r\n\t\t\t" +
                    "static ");
            
            #line 95 "C:\Users\nicol\Source\Repos\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(@"()
			{
				//_manager = new BinaryManager();

				//UnityEngine.Debug.Log($""Manager: {_manager}"");
				//UnityEngine.Debug.Log($""Controller: {_manager.Controller}"");
				string cwd = Directory.GetCurrentDirectory();
				_manager.Controller.SetRessourceDirectory(cwd + @""/Assets/DNAI/Scripts/"");
				_manager.LoadCommandsFrom(@""Assets/DNAI/Scripts/"" + """);
            
            #line 103 "C:\Users\nicol\Source\Repos\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(FilePath));
            
            #line default
            #line hidden
            this.Write("\");\r\n\t\t\t\tPredictor.InitPredictor();\r\n\t\t\t}\r\n\r\n\t\t\t///<summary>\r\n\t\t\t/// Executes the" +
                    " Duly Behaviour by calling the created function.\r\n\t\t\t/// Updates Outputs accordi" +
                    "ngly.\r\n\t\t\t///</summary>\r\n\t\t\t");
            
            #line 111 "C:\Users\nicol\Source\Repos\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
 foreach (var f in Functions)
			{ 
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\t\tpublic void Execute");
            
            #line 114 "C:\Users\nicol\Source\Repos\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(f.Name));
            
            #line default
            #line hidden
            this.Write("()\r\n\t\t\t\t{\r\n\t\t\t\t\tvar generated_script_execution_results = new Dictionary<string, d" +
                    "ynamic>();\r\n\r\n\t\t\t\t\tgenerated_script_execution_results = _manager.Controller.Call" +
                    "Function(");
            
            #line 118 "C:\Users\nicol\Source\Repos\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(f.FunctionId));
            
            #line default
            #line hidden
            this.Write(", new Dictionary<string, dynamic>{ ");
            
            #line 118 "C:\Users\nicol\Source\Repos\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(f.FunctionArguments));
            
            #line default
            #line hidden
            this.Write(" });\r\n\t\t\t\t\t");
            
            #line 119 "C:\Users\nicol\Source\Repos\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
 if (Outputs.Count > 0)
					{
						foreach (var output in Outputs)
						{
							var varType = output.Split(' ')[0];
							var varName = output.Split(' ')[1]; 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t\t\t\tif (generated_script_execution_results.ContainsKey(\"");
            
            #line 125 "C:\Users\nicol\Source\Repos\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(varName));
            
            #line default
            #line hidden
            this.Write("\"))\r\n\t\t\t\t\t\t\t{\r\n\t\t\t\t\t\t\t\tif (generated_script_execution_results[\"");
            
            #line 127 "C:\Users\nicol\Source\Repos\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(varName));
            
            #line default
            #line hidden
            this.Write("\"].GetType() != typeof(");
            
            #line 127 "C:\Users\nicol\Source\Repos\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(varType));
            
            #line default
            #line hidden
            this.Write("))\r\n\t\t\t\t\t\t\t\t{\r\n\t\t\t\t\t\t\t\t\tthis.");
            
            #line 129 "C:\Users\nicol\Source\Repos\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(varName));
            
            #line default
            #line hidden
            this.Write(" = Convert.ChangeType(generated_script_execution_results[\"");
            
            #line 129 "C:\Users\nicol\Source\Repos\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(varName));
            
            #line default
            #line hidden
            this.Write("\"], typeof(");
            
            #line 129 "C:\Users\nicol\Source\Repos\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(varType));
            
            #line default
            #line hidden
            this.Write("));\r\n\t\t\t\t\t\t\t\t}\r\n\t\t\t\t\t\t\t\telse\r\n\t\t\t\t\t\t\t\t{\r\n\t\t\t\t\t\t\t\t\tthis.");
            
            #line 133 "C:\Users\nicol\Source\Repos\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(varName));
            
            #line default
            #line hidden
            this.Write(" = generated_script_execution_results[\"");
            
            #line 133 "C:\Users\nicol\Source\Repos\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(varName));
            
            #line default
            #line hidden
            this.Write("\"];\r\n\t\t\t\t\t\t\t\t}\r\n\t\t\t\t\t\t\t}\r\n\t\t\t\t\t\t");
            
            #line 136 "C:\Users\nicol\Source\Repos\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
 }
					} 
            
            #line default
            #line hidden
            this.Write("\t\t\t\t}\r\n\t\t\t\t\r\n\t\t\t");
            
            #line 140 "C:\Users\nicol\Source\Repos\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t}\r\n\t//}\r\n}");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 1 "C:\Users\nicol\Source\Repos\Duly\PluginUnity\CorePluginUnity\Generator\GeneratedCodeTemplate.tt"

private string _parameter1Field;

/// <summary>
/// Access the parameter1 parameter of the template.
/// </summary>
private string parameter1
{
    get
    {
        return this._parameter1Field;
    }
}


/// <summary>
/// Initialize the template
/// </summary>
public virtual void Initialize()
{
    if ((this.Errors.HasErrors == false))
    {
bool parameter1ValueAcquired = false;
if (this.Session.ContainsKey("parameter1"))
{
    this._parameter1Field = ((string)(this.Session["parameter1"]));
    parameter1ValueAcquired = true;
}
if ((parameter1ValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("parameter1");
    if ((data != null))
    {
        this._parameter1Field = ((string)(data));
    }
}


    }
}


        
        #line default
        #line hidden
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public class GeneratedCodeTemplateBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
