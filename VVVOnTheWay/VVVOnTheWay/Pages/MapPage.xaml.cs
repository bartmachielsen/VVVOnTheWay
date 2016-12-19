using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
using Point = VVVOnTheWay.Route.Point;

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
                ShowNewRoute(location);
            }
            catch (GpsNotAllowed)
            {
                await new MessageDialog("No GPS Access!", "GPS not functional!").ShowAsync();
                // TODO take action when no gps
                // TODO show in language which is chosen
            }
            
            BingMapsWrapper.NotifyOnLocationUpdate((async geoposition =>
            {
                await Dispatcher.TryRunAsync(CoreDispatcherPriority.Normal, () =>
                 {
                     UpdateUserLocation(geoposition);
                     ShowNewRoute(geoposition);
                 });
                // TODO CHECK IF DISPATCHER IS NEEDED BECAUSE OTHER THREAD
            }));
            
            ListenToNextPointOfInterest();
            

        }

        private async void ShowNewRoute(Geoposition position)
        {
            List<Point> routepoints = new List<Point>();
            List<Geopoint> points = new List<Geopoint>() { position.Coordinate.Point};
            while (true)
            {
                var nextPoint = GetNextPointOfInterest(false,routepoints);
                if (nextPoint == null) break;
                points.Add(nextPoint.Location);
                routepoints.Add(nextPoint);
                if (nextPoint is PointOfInterest)
                    break;
            }
            if (points.Count <= 1) return;
            var routeResult = await BingMapsWrapper.GetRouteBetween(points);
            if (routeResult == null) return;
            if (_routeView != null)
                Map.Routes.Remove(_routeView);

            _routeView = new MapRouteView(routeResult)
            {
                OutlineColor = Colors.Black,
                RouteColor = Colors.Yellow
            };
            Map.Routes.Add(_routeView);
        }

        private async void ListenToNextPointOfInterest()
        {
            var point = GetNextPointOfInterest(true);
            if (point != null)
            {
                await BingMapsWrapper.PointOfInterestEntered((async interest =>
                {
                    await Dispatcher.TryRunAsync(CoreDispatcherPriority.Normal, async () =>
                    {
                        if (interest.IsVisited) return;
                        // TODO SHOW NOTIFICATION THAT POINT OF INTEREST IS REACHED
                        if (interest.GetType() == typeof(PointOfInterest))
                        {
                            PointOfInterest poi = ((PointOfInterest)interest);
                            NotificationSystem.NotificationSystem.SenToastificationAsync(poi.GetNotification());
                            NotificationSystem.NotificationSystem.SendVibrationNotificationAsync();
                        }
                        interest.IsVisited = true;
                        ListenToNextPointOfInterest();
                        ShowNewRoute((await BingMapsWrapper.GetCurrentPosition()));
                        FileIO.RouteProgressIO.SaveRouteProgressToFile(route);
                    });
                    return;
                }), point);
            }
        }

        private Route.Point GetNextPointOfInterest(bool pointOfInterest = false, List<Point> skip = null)
        {
            if(skip == null)
                skip = new List<Point>();
            var reversed = new List<Point>(route.RoutePoints);
            reversed.Reverse();
            var index = reversed.FindIndex((point) => point.IsVisited);
            if (index == -1)
                index = route.RoutePoints.Count;
            for (var i = route.RoutePoints.Count-index; i < route.RoutePoints.Count; i++)
            {
                var point = route.RoutePoints.ElementAt(i);
                if (!point.IsVisited && (point is PointOfInterest == pointOfInterest || !pointOfInterest) && !skip.Contains(point))
                    return point;
            }
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
