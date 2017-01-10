// Created by Bart Machielsen

#region

using System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using VVVOnTheWay.FileIO;
using VVVOnTheWay.Pages;

#endregion

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace VVVOnTheWay
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RouteSelectionPage : Page
    {
        private int _selectedRoute; // 0 = Blind Walls, 1 = Historische Kilometer

        public RouteSelectionPage()
        {
            InitializeComponent();
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            LoadRouteFromFilePath();
        }

        private async void LoadRouteFromFilePath()
        {
            Route.Route selectedRoute;
            if (_selectedRoute == 1)
                selectedRoute = await FullRouteIO.LoadRouteAsync(FullRouteIO.HistoricalKilometerFileName);
            else
                selectedRoute = await FullRouteIO.LoadRouteAsync(FullRouteIO.BlindWallsFileName);
            RouteSelectionFrame.Navigate(typeof(PasswordPage), selectedRoute);
        }

        private async void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            var g = new GuidePage();
            await g.ShowAsync();
        }

        private void BlindWallsButton_Click(object sender, RoutedEventArgs e)
        {
            BlindWallsButton.BorderBrush = new SolidColorBrush(Colors.Black);
            BlindWallsButton.BorderThickness = new Thickness(3);
            HistoricalKmButton.BorderBrush = new SolidColorBrush(Colors.Transparent);
            HistoricalKmButton.BorderThickness = new Thickness(1);
            _selectedRoute = 0;
        }

        private void HistoricalKmButton_Click(object sender, RoutedEventArgs e)
        {
            HistoricalKmButton.BorderBrush = new SolidColorBrush(Colors.Black);
            HistoricalKmButton.BorderThickness = new Thickness(3);
            BlindWallsButton.BorderBrush = new SolidColorBrush(Colors.Transparent);
            BlindWallsButton.BorderThickness = new Thickness(1);
            _selectedRoute = 1;
        }
    }
}