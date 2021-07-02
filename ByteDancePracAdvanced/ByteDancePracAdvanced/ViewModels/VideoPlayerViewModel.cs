using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ByteDancePracAdvanced.ViewModels
{
    public class VideoPlayerViewModel : INotifyPropertyChanged
    {
        public VideoPlayerViewModel()
        {
        }

        private LibVLC _libVLC;
        public LibVLC LibVLC
        {
            get => _libVLC;
            private set => Set(nameof(LibVLC), ref _libVLC, value);
        }

        private MediaPlayer _mediaPlayer;
        public MediaPlayer MediaPlayer
        {
            get => _mediaPlayer;
            private set => Set(nameof(MediaPlayer), ref _mediaPlayer, value);
        }

        // Default video. FOR TESTING ONLY.
        // private static string _mediaPath = "http://clips.vorwaerts-gmbh.de/big_buck_bunny.mp4";
        private static string _mediaPath = "rtsp://freja.hiof.no:1935/rtplive/definst/hessdalen03.stream";
        public static string MediaPath
        {
            get => _mediaPath;
            set => _mediaPath = value;
        }

        // Default video type. FOR TESTING ONLY.
        private static FromType _mediaFromType = FromType.FromLocation;
        public static FromType MediaFromType
        {
            get => _mediaFromType;
            set => _mediaFromType = value;
        }

        public void OnAppearing()
        {
            LibVLC = new LibVLC();
            Media media = new Media(LibVLC, MediaPath, MediaFromType);
            MediaPlayer = new MediaPlayer(media) { EnableHardwareDecoding = true };
            media.Dispose();
            MediaPlayer.Play();
        }

        internal void OnDisappearing()
        {
            MediaPlayer.Dispose();
            LibVLC.Dispose();
        }

        private void Set<T>(string propertyName, ref T field, T value)
        {
            if (field == null && value != null || field != null && !field.Equals(value))
            {
                field = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
