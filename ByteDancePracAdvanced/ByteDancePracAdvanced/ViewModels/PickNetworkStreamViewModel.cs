using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ByteDancePracAdvanced.ViewModels
{
    public class PickNetworkStreamViewModel : INotifyPropertyChanged
    {
        public string MediaUri { get; set; }
        public ICommand TestCommand { get; private set; }

        public PickNetworkStreamViewModel()
        {
            MediaUri = "";
            TestCommand = new Command(() =>
            {
                VideoPlayerViewModel.MediaPath = MediaUri;
                VideoPlayerViewModel.MediaFromType = LibVLCSharp.Shared.FromType.FromLocation;
                MediaUri = "";
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MediaUri"));
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
