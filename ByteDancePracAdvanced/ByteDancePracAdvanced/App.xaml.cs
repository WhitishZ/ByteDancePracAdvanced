using ByteDancePracAdvanced.Views;
using LibVLCSharp.Forms.Shared;
using LibVLCSharp.Shared;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ByteDancePracAdvanced
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            // NOTE: Initializing libVLCSharp.Forms:
            // Call on each platform (MainActivity.cs in Android and AppDelegate.cs in iOS):
            // LibVLCSharpFormsRenderer.Init();
            Core.Initialize();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            base.OnStart();
            MessagingCenter.Send(new LifecycleMessage(), nameof(OnStart));
        }

        protected override void OnSleep()
        {
            base.OnSleep();
            MessagingCenter.Send(new LifecycleMessage(), nameof(OnSleep));
        }

        protected override void OnResume()
        {
            base.OnResume();
            MessagingCenter.Send(new LifecycleMessage(), nameof(OnResume));
        }
    }
}
