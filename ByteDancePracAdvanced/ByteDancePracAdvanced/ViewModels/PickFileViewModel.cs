using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ByteDancePracAdvanced.ViewModels
{
    public class PickFileViewModel : INotifyPropertyChanged
    {
        public ICommand PickFileCommand { get; private set; }
        private static readonly string[] mediaExtensions = {
            ".mp3", ".wav", ".flac", ".m4a",
            ".mp4", ".mkv", ".webm"
        };
        public string HintMessage { get; set; }
        public string SelectedFilePath { get; set; }
        public bool CanPlayVideo { get; set; }
        
        public PickFileViewModel()
        {
            HintMessage = "Please select a media file to open.";
            CanPlayVideo = false;
            PickFileCommand = new Command(async () =>
            {
                await PickFile();
            });
        }
        public async Task<FileResult> PickFile()
        {
            try
            {
                FileResult fileResult = await FilePicker.PickAsync();
                if (fileResult != null)
                {
                    string pickedFilePath = fileResult.FullPath;
                    if (mediaExtensions.Contains(Path.GetExtension(pickedFilePath), StringComparer.OrdinalIgnoreCase))
                    {
                        SelectedFilePath = pickedFilePath;
                        VideoPlayerViewModel.MediaPath = pickedFilePath;
                        VideoPlayerViewModel.MediaFromType = LibVLCSharp.Shared.FromType.FromPath;
                        HintMessage = "Selected file: " + fileResult.FileName;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("HintMessage"));
                        CanPlayVideo = true;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CanPlayVideo"));
                    }
                    else
                    {
                        HintMessage = fileResult.FileName + " is not a supported media.";
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("HintMessage"));
                        CanPlayVideo = false;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CanPlayVideo"));
                    }
                }
                return fileResult;
            }
            catch (Exception)
            {
                // TODO: The user canceled or something went wrong
            }
            return null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
