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
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
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
            
            BingMapsWrapper.notifyOnLocationUpdate(UpdateUserLocation);
        }

        private async Task<object> UpdateUserLocation(Geoposition geoposition)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                Map.Center = geoposition.Coordinate.Point;
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
            Frame.Navigate(typeof(MainPage));
            //#TODO: Make GuidePage
        }

    }
}
