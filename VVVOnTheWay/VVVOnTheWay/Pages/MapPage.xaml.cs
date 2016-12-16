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
using VVVOnTheWay.Pages;
using VVVOnTheWay.Route;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace VVVOnTheWay
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MapPage : Page
    {
        private Route.Route route;
        private MapIcon _userIcon;
        private MapRouteView _routeView;
        private Language _language = VVVOnTheWay.Language.ENGLISH;

        public MapPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            route = e.Parameter as Route.Route;
            BingMapsWrapper.ClearGeofences();
            await GetUserLocation();
            AddPointsOfInterest();
        }

        private async Task GetUserLocation()
        {
            try
            {
                var location = await BingMapsWrapper.GetCurrentPosition();
                Map.Center = location.Coordinate.Point;
                Map.ZoomLevel = 15;
                UpdateUserLocation(location);
            }
            catch (GpsNotAllowed)
            {
                await new MessageDialog("No GPS Access!", "GPS not functional!").ShowAsync();
                // TODO take action when no gps
                // TODO show in language which is chosen
            }
            BingMapsWrapper.NotifyOnLocationUpdate((geoposition =>
            {
                UpdateUserLocation(geoposition);

                // TODO CHECK IF DISPATCHER IS NEEDED BECAUSE OTHER THREAD
                return null;
            }));
            
            ListenToNextPointOfInterest();
            

        }

        private async void ShowNewRoute(Geoposition position)
        {
            var nextPoint = GetNextPointOfInterest();
            if (nextPoint != null)
            {
                if (_routeView != null)
                    Map.Routes.Remove(_routeView);
                _routeView = new MapRouteView(await BingMapsWrapper.GetRouteTo(position.Coordinate.Point, nextPoint.Location));
                if (_routeView == null)
                    Map.Routes.Add(_routeView);
            }

        }

        private async void ListenToNextPointOfInterest()
        {
            var point = GetNextPointOfInterest();
            if (point != null)
            {
                await BingMapsWrapper.PointOfInterestEntered((async interest =>
                {
                    // TODO SHOW NOTIFICATION THAT POINT OF INTEREST IS REACHED
                    interest.IsVisited = true;
                    ListenToNextPointOfInterest();
                    ShowNewRoute((await BingMapsWrapper.GetCurrentPosition()));
                    return;
                }), point);
            }
        }

        private Route.Point GetNextPointOfInterest()
        {
            foreach (var point in route.RoutePoints)
                if (!point.IsVisited)
                    return point;
            return null;
        }

        private void UpdateUserLocation(Geoposition geoposition)
        {
            if (_userIcon == null)
            {
                _userIcon = new MapIcon()
                {
                    Title = "Your Location",
                    Location = geoposition.Coordinate.Point
                };
                Map.MapElements.Add(_userIcon);
            }
            else
            {
                _userIcon.Location = geoposition.Coordinate.Point;
            }
        }

      
        private void AddPointsOfInterest()
        {
            foreach (var poi in route.RoutePoints)
            {
                PointOfInterest point = poi as PointOfInterest;
                if (point != null)
                {
                    Map.MapElements.Add(new MapIcon()
                    {
                        Title = point.Title[(int) _language],
                        Location = poi.Location

                    });
                }
            }
        }

        private async void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            var g = new GuidePage();
            await g.ShowAsync();
        }

        private async void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            var g = new SettingsPage();
            await g.ShowAsync();
        }

       
    }
}
