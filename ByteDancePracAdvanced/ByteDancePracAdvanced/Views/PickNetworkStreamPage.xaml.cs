using ByteDancePracAdvanced.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ByteDancePracAdvanced.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PickNetworkStreamPage : ContentPage
    {
        public PickNetworkStreamPage()
        {
            InitializeComponent();
        }

        private async void PlayButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VideoPlayerPage());
        }
    }
}