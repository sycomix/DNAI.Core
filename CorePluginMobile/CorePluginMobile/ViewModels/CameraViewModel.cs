﻿using Xamarin.Forms;
using CorePluginMobile.Services;
using CoreCommand;

// https://docs.microsoft.com/en-us/xamarin/xamarin-forms/platform/native-views/xaml
// https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/custom-renderer/contentpage
namespace CorePluginMobile.ViewModels
{
    public class CameraViewModel : BaseViewModel
    {
        private readonly BinaryManager _manager = new BinaryManager();

        public CameraViewModel()
        {
            //Contents = new Xamarin.Forms.StackLayout();
            //Contents.Children.Add(DependencyService.Get<ICamera>().GetView());
            DependencyService.Get<ICamera>().OnImageChange += CameraViewModel_OnImageChange;
        }

        private void CameraViewModel_OnImageChange(object sender, System.EventArgs e)
        {
            var image = (sender as ICamera).GetImage();
            //_binaryManager.Controller.CallFunction(...)
            DependencyService.Get<IToaster>().MakeText($"Number found: [{0}] ({0}%)");
        }
    }
}