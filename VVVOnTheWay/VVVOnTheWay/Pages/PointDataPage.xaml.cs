// Created by Bart Machielsen

#region

using System;
using Windows.ApplicationModel;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using VVVOnTheWay.Route;

#endregion

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace VVVOnTheWay.Pages
{
    public sealed partial class PointDataPage : ContentDialog
    {
        private readonly PointOfInterest _poi;

        public PointDataPage(PointOfInterest poi)
        {
            InitializeComponent();
            _poi = poi;
            PointInfoText.Text = _poi.Title[(int) Settings.Language] + "\n\n" +
                                 _poi.Description[(int) Settings.Language];
            if (_poi.Description == null) poi.Description = new[] {"No description", "Geen beschrijving"};
            PointPicture.Source = _poi.ImagePath != null
                ? new BitmapImage(new Uri($"ms-appx:///{_poi.ImagePath}"))
                : new BitmapImage(new Uri("ms-appx:///Assets/unavailable-image.png"));
        }

        private async void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (_poi.AudioPath == null) return;
            try
            {
                var mysong = new MediaElement();

                var folder =
                    await Package.Current.InstalledLocation.GetFolderAsync("Assets");
                var file = await folder.GetFileAsync(_poi.AudioPath[(int) Settings.Language]);
                var stream = await file.OpenAsync(FileAccessMode.Read);
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