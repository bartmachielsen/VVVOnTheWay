using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using VVVOnTheWay.Route;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace VVVOnTheWay.Pages
{
    public sealed partial class PointDataPage : ContentDialog
    {
        private PointOfInterest _poi;

        public PointDataPage(PointOfInterest poi)
        {
            this.InitializeComponent();
            _poi = poi;
            PointInfoText.Text = _poi.Title[(int)VVVOnTheWay.Settings.Language] + "\n\n" + _poi.Description[(int)VVVOnTheWay.Settings.Language];
            if (_poi.Description == null) poi.Description = new[] { "No description", "Geen beschrijving" };
            PointPicture.Source = _poi.ImagePath != null ? new BitmapImage(new Uri($"ms-appx:///{_poi.ImagePath}")) : new BitmapImage(new Uri("ms-appx:///Assets/unavailable-image.png"));
        }

        private async void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (_poi.AudioPath == null) return;
            try
            {
                MediaElement mysong = new MediaElement();

                Windows.Storage.StorageFolder folder =
                    await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
                Windows.Storage.StorageFile file = await folder.GetFileAsync(_poi.AudioPath[(int)Settings.Language]);
                var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                mysong.SetSource(stream, file.ContentType);
                mysong.Play();
                
            }
            catch
            {
                // ignored
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private async void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            var g = new GuidePage();
            await g.ShowAsync();
        }
    }
}
