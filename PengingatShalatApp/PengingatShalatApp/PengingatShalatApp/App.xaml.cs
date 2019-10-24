using Newtonsoft.Json;
using Plugin.LocalNotifications;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PengingatShalatApp
{
    public partial class App : Application
    {
        string waktunow { get; set; }
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }


        protected override void OnStart()
        {
            Debug.WriteLine("OnStart");

        }

        protected override void OnSleep()
        {
            Debug.WriteLine("OnSleep");
        }

        protected override void OnResume()
        {
            Debug.WriteLine("OnResume");
        }
    }
}
