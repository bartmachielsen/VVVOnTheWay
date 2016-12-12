using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using LocationSystem;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace VVVOnTheWay
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MapPage : Page
    {
        public MapPage()
        {
            this.InitializeComponent();

            GetUserLocation();

        }

        private async Task GetUserLocation()
        {
            try
            {
                var location = await BingMapsWrapper.getCurrentPosition();
                Map.Center = location.Coordinate.Point;
                Map.ZoomLevel = 15;
                await UpdateUserLocation(location);
            }
            catch (GPSNotAllowed)
            {
                await new MessageDialog("No GPS Access!", "GPS not functional!").ShowAsync();
                // TODO take action when no gps
                // TODO show in language which is chosen
            }
            BingMapsWrapper.notifyOnLocationUpdate(UpdateUserLocation);
        }

        private async Task<object> UpdateUserLocation(Geoposition geoposition)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                MapIcon icon = new MapIcon()
                {
                    Title = "YOU",
                    Location = geoposition.Coordinate.Point
                };
                Map.MapElements.Clear();
                Map.MapElements.Add(icon);
            });
            
            return null;
        }

       

        private void LanguageSwitch_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RouteSelectionPage));
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MapPage));
            //#TODO: Make GuidePage
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MapPage));
            //#TODO: Make GuidePage
        }

       
    }
}
