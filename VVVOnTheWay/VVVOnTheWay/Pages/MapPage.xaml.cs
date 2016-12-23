// Created by Bart Machielsen

#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Navigation;
using LocationSystem;
using VVVOnTheWay.FileIO;
using VVVOnTheWay.NotificationSystem;
using VVVOnTheWay.Pages;
using VVVOnTheWay.Route;

#endregion

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace VVVOnTheWay
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MapPage : Page
    {
        private readonly Language _language = VVVOnTheWay.Language.ENGLISH;

        private MapPolyline _mapPolyline;
        private readonly Dictionary<PointOfInterest, MapIcon> _routeIcons = new Dictionary<PointOfInterest, MapIcon>();
        private MapRouteView _routeView;
        private MapIcon _userIcon;
        private Route.Route route;

        public MapPage()
        {
            InitializeComponent();

            Map.MapElementClick += Map_MapElementClick;
        }

        private async void Map_MapElementClick(MapControl sender, MapElementClickEventArgs args)
        {
            var clickedIcon = args.MapElements.FirstOrDefault(x => x is MapIcon) as MapIcon;
            var poi = _routeIcons.FirstOrDefault(x => x.Value == clickedIcon).Key;
            var g = new PointDataPage(poi);
            await g.ShowAsync();
        }


        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            route = e.Parameter as Route.Route;
            RouteProgressIO.SaveRouteProgressToFile(route);

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

            BingMapsWrapper.NotifyOnLocationUpdate(async geoposition =>
            {
                await Dispatcher.TryRunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    UpdateUserLocation(geoposition);
                    ShowNewRoute(geoposition);
                });
            });

            ListenToNextPointOfInterest();
        }

        /// <summary>
        /// </summary>
        /// <param name="position"></param>
        private async void ShowNewRoute(Geoposition position)
        {
            var routepoints = new List<Point>();
            var points = new List<Geopoint> {position.Coordinate.Point};
            while (true)
            {
                var nextPoint = GetNextPointOfInterest(false, routepoints);
                if (nextPoint == null) break;
                points.Add(nextPoint.Location);
                routepoints.Add(nextPoint);
                if (nextPoint is PointOfInterest)
                    break;
            }
            if (points.Count <= 1)
            {
                if (_routeView != null)
                    Map.Routes.Remove(_routeView);
                return;
            }
            var routeResult = await BingMapsWrapper.GetRouteBetween(points);
            if (routeResult == null) return;
            if (_routeView != null)
                Map.Routes.Remove(_routeView);
            double distance = routeResult.LengthInMeters;
            if (distance >= 1000.0) { textBlock2.Text = Math.Round(distance / 1000.0, 2) + " km"; }
            else { textBlock2.Text = distance + " m"; }
            textBlock1.Text = (Math.Round(distance/5000) + " : " + Math.Round(distance/1000 %5 /5 *60));
            
            //@TODO textblock1 check lang 
            _routeView = new MapRouteView(routeResult)
            {
                OutlineColor = Colors.Blue,
                RouteColor = Colors.Blue
            };
            Map.Routes.Add(_routeView);
        }

        private async void ListenToNextPointOfInterest()
        {
            var point = GetNextPointOfInterest(true);
            if (point != null)
                await BingMapsWrapper.PointOfInterestEntered(async interest =>
                {
                    await Dispatcher.TryRunAsync(CoreDispatcherPriority.Normal, async () =>
                    {
                        if (interest.IsVisited) return;
                        if (interest.GetType() == typeof(PointOfInterest))
                        {
                            var poi = (PointOfInterest) interest;
                            NotificationSystem.NotificationSystem.SenToastificationAsync(poi.GetNotification());
                            NotificationSystem.NotificationSystem.SendVibrationNotificationAsync();
                            var g = new PointDataPage(poi);
                            await g.ShowAsync();
                        }
                        interest.IsVisited = true;
                        ListenToNextPointOfInterest();
                        ShowNewRoute(await BingMapsWrapper.GetCurrentPosition());
                        RouteProgressIO.SaveRouteProgressToFile(route);

                        //@TODO PLACE ON BETER LOCATION OR ON NEW TASK
                        if (point is PointOfInterest)
                        {
                            var icon = _routeIcons[(PointOfInterest) point];
                            if (icon == null) return;
                            icon.Image =
                                RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/Point visited.png"));
                        }
                    });
                }, point);
            else
            {
                switch (Settings.Language)
                {
                    case VVVOnTheWay.Language.ENGLISH:
                        NotificationSystem.NotificationSystem.SenToastificationAsync(
                            new Notification("End of the route.",
                                "You have reached the end of the route. You can turn in your phone to the VVV employee."));
                        break;
                    case VVVOnTheWay.Language.DUTCH:
                        NotificationSystem.NotificationSystem.SenToastificationAsync(
                            new Notification("Einde van de route.",
                                "U heeft de route afgerond. U kan nu de telefoon inleveren bij de VVV medewerker."));
                        break;
                }
            }
        }

        private Point GetNextPointOfInterest(bool pointOfInterest = false, List<Point> skip = null)
        {
            if (skip == null)
                skip = new List<Point>();
            var reversed = new List<Point>(route.RoutePoints);
            reversed.Reverse();
            var index = reversed.FindIndex(point => point.IsVisited);
            if (index == -1)
                index = route.RoutePoints.Count;
            for (var i = route.RoutePoints.Count - index; i < route.RoutePoints.Count; i++)
            {
                var point = route.RoutePoints.ElementAt(i);
                if (!point.IsVisited && (point is PointOfInterest == pointOfInterest || !pointOfInterest) &&
                    !skip.Contains(point))
                    return point;
            }
            return null;
        }

        private void UpdateUserLocation(Geoposition geoposition)
        {
            if (_mapPolyline == null)
            {
                _mapPolyline = new MapPolyline
                {
                    Path = new Geopath(new List<BasicGeoposition> {geoposition.Coordinate.Point.Position}),
                    StrokeColor = Colors.Green,
                    StrokeThickness = 3,
                    StrokeDashed = true
                };
                Map.MapElements.Add(_mapPolyline);
            }
            else
            {
                var geopath =
                    new Geopath(new List<BasicGeoposition>(_mapPolyline.Path.Positions)
                    {
                        geoposition.Coordinate.Point.Position
                    });
                _mapPolyline.Path = geopath;
            }
            if (_userIcon == null)
            {
                _userIcon = new MapIcon
                {
                    Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/guy.png")),
                    Title = Settings.Language == VVVOnTheWay.Language.ENGLISH ? "Your Location" : "Uw locatie",
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
                var point = poi as PointOfInterest;
                if (point != null)
                {
                    var icon = new MapIcon
                    {
                        Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/Point.png")),
                        Title = point.Title[(int) _language],
                        Location = poi.Location
                    };
                    Map.MapElements.Add(icon);
                    _routeIcons.Add(point, icon);
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
            var languageBefore = Settings.Language;
            var g = new SettingsPage();
            await g.ShowAsync();
            ChangeLanguage(languageBefore);
        }

        private void ChangeLanguage(Language languageBefore)
        {
            var languageAfter = Settings.Language;
            _userIcon.Title = languageAfter == VVVOnTheWay.Language.ENGLISH ? "Your Location" : "Uw locatie";
            if (languageAfter == languageBefore) return;
            foreach (var pair in _routeIcons)
                pair.Value.Title = pair.Key.Title[(int) languageAfter];
        }
    }
}