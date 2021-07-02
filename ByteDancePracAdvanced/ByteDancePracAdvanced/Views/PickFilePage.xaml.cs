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
    public partial class PickFilePage : ContentPage
    {
        public PickFilePage()
        {
            InitializeComponent();
        }

        private async void PlayButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VideoPlayerPage());
        }
    }
}