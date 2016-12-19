using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Devices.Geolocation.Geofencing;
using Windows.Foundation;
using Windows.Services.Maps;
using Windows.UI.Xaml.Controls.Maps;
using VVVOnTheWay.Route;
using Point = VVVOnTheWay.Route.Point;


namespace LocationSystem
{
    /// <summary>
    /// This class has as function to provide a bridge between the GPS Api from the windows device and the software.
    /// </summary>
    static class BingMapsWrapper
    {
        /// <summary>
        /// Uint which represents the wanted accuracy from the GPS receiver
        /// </summary>
        private static uint Accuracy = 10;


        /// <summary>
        /// Double which represents the movementthreshold in meters
        /// </summary>
        private static double MovementThreshold = 0.5;

        /// <summary>
        /// Method for checking if the GPS receiver in the windows phone is reachable
        /// </summary>
        /// <returns>returns boolean which represents the accessibility</returns>
        private static async Task<bool> CheckGpsAccessibility()
        {
            return (await Geolocator.RequestAccessAsync()) == GeolocationAccessStatus.Allowed
                && new Geolocator().LocationStatus != PositionStatus.NotAvailable;
        }

        /// <summary>
        /// Method for listening to changes from the gps locator
        /// </summary>
        /// <exception cref="GpsNotAllowed">Exception when system has deactivated GPS or user does not allow GPS to this application</exception>
        /// <param name="method"></param>
        public static async void NotifyOnLocationUpdate(Func<Geoposition, Task> method)
        {
            if (!await CheckGpsAccessibility())
                throw new GpsNotAllowed();
            Geolocator locator = new Geolocator() { DesiredAccuracyInMeters = Accuracy, MovementThreshold = MovementThreshold };
            locator.PositionChanged +=
                (Geolocator sender, PositionChangedEventArgs args) => { method.Invoke(args.Position); };
        }

        ///<summary>
        /// Get the current location of the user as a GeoPosition
        /// <exception cref="GpsNotAllowed">Exception when system has deactivated GPS or user does not allow GPS to this application</exception>
        /// <returns> Geoposition as gps information</returns>
        public static async Task<Geoposition> GetCurrentPosition()
        {
            if (!await CheckGpsAccessibility())
                throw new GpsNotAllowed();
            Geolocator locator = new Geolocator() { DesiredAccuracyInMeters = Accuracy };
            return await locator.GetGeopositionAsync();
        }

        public static void ClearGeofences()
        {
            GeofenceMonitor.Current.Geofences.Clear();
        }

        /// <summary>
        /// Calculate the distance between two geoposition
        /// </summary>
        /// <param name="source">The location of the source as Geoposition</param>
        /// <param name="target">The location to calculate the distance to</param>
        /// <returns> double as distance in meters between the two positions</returns>
        public static async Task<double> GetDistanceTo(Geoposition source, Geoposition target)
        {
            return (await GetRouteTo(source.Coordinate.Point, target.Coordinate.Point)).LengthInMeters;
        }


        /// <summary>
        /// Calculate the route between two geopositons
        /// </summary>
        /// <param name="source">The location of the source as Geoposition</param>
        /// <param name="target">The location to calculate the distance to</param>
        /// <returns>MapRoute between the two points <seealso cref="MapRoute"/></returns>
        public static async Task<MapRoute> GetRouteTo(Geopoint source, Geopoint target)
        {
            return (await MapRouteFinder.GetWalkingRouteAsync(source, target)).Route;
        }


        public static async Task<MapRoute> GetRouteBetween(List<Geopoint> sources)
        {
            return (await MapRouteFinder.GetWalkingRouteFromWaypointsAsync(sources)).Route;
        }

        /// <summary>
        /// Method for listening if the user the route has leaved or exited
        /// </summary>
        /// <param name="route">The route the user is using <seealso cref="Route"/></param> 
        /// <exception cref="GpsNotAllowed">Exception when system has deactivated GPS or user does not allow GPS to this application</exception>
        public static async Task PointOfInterestEntered(Func<Point, Task> notifier, Point pointOfInterest)
        {
            if (!await CheckGpsAccessibility())
                throw new GpsNotAllowed();
            var geofence = new Geofence($"{pointOfInterest} notifier", new Geocircle(pointOfInterest.Location.Position, 20.0), MonitoredGeofenceStates.Entered, true);

            GeofenceMonitor.Current.Geofences.Add(geofence);
            GeofenceMonitor.Current.GeofenceStateChanged += (GeofenceMonitor monitor, object obj) =>
            {
                foreach (var report in monitor.ReadReports())
                    if (report.Geofence.Id == geofence.Id)
                        notifier.Invoke(pointOfInterest);
            };
        }


    }

    /// <summary>
    /// Exception which is thrown when GPS receiver does not allow access to the current location
    /// </summary>
    class GpsNotAllowed : Exception
    {

    }
}