using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using VVVOnTheWay.Pages;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace VVVOnTheWay
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RouteSelectionPage : Page
    {
        public RouteSelectionPage()
        {
            this.InitializeComponent();
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            if (HistoricalKmButton.BorderBrush == new SolidColorBrush(Colors.Black))
            {
                //choose histarical km route
            } 
            //choose blind walls route
            RouteSelectionFrame.Navigate(typeof(LanguageSelectionPage));
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
        }

        private void HistoricalKmButton_Click(object sender, RoutedEventArgs e)
        {
            HistoricalKmButton.BorderBrush = new SolidColorBrush(Colors.Black);
            HistoricalKmButton.BorderThickness = new Thickness(3);
            BlindWallsButton.BorderBrush = new SolidColorBrush(Colors.Transparent);
            BlindWallsButton.BorderThickness = new Thickness(1);
        }
    }
}
