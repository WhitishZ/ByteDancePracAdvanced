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
    public partial class VideoPlayerPage : ContentPage
    {
        public VideoPlayerPage()
        {
            InitializeComponent();
        }
        void OnAppearing(object sender, EventArgs e)
        {
            base.OnAppearing();
            ((VideoPlayerViewModel)BindingContext).OnAppearing();
        }

        void OnDisappearing(object sender, EventArgs e)
        {
            base.OnDisappearing();
            ((VideoPlayerViewModel)BindingContext).OnDisappearing();
        }
    }
}