using ByteDancePracAdvanced.Views;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace ByteDancePracAdvanced
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(VideoPlayerPage), typeof(VideoPlayerPage));
            Routing.RegisterRoute(nameof(PickFilePage), typeof(PickFilePage));
            Routing.RegisterRoute(nameof(PickNetworkStreamPage), typeof(PickNetworkStreamPage));
        }
        private async void OnTestVideoPlayerSelected(object sender, EventArgs args)
        {
            await Current.GoToAsync("VideoPlayerPage");
            Current.FlyoutIsPresented = false;
        }
    }
}
