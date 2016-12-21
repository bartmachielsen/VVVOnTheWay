// Created by Bart Machielsen

#region

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Devices.Geolocation.Geofencing;
using Windows.Foundation;
using Windows.Services.Maps;
using VVVOnTheWay.Route;
using Point = VVVOnTheWay.Route.Point;

#endregion

namespace LocationSystem
{
    /// <summary>
    ///     This class has as function to provide a bridge between the GPS Api from the windows device and the software.
    /// </summary>
    internal static class BingMapsWrapper
    {
        /// <summary>
        ///     Uint which represents the wanted accuracy from the GPS receiver
        /// </summary>
        private static readonly uint Accuracy = 10;


        /// <summary>
        ///     Double which represents the movementthreshold in meters
        /// </summary>
        private static readonly double MovementThreshold = 0.5;

        /// <summary>
        ///     Method for checking if the GPS receiver in the windows phone is reachable
        /// </summary>
        /// <returns>returns boolean which represents the accessibility</returns>
        private static async Task<bool> CheckGpsAccessibility()
        {
            return await Geolocator.RequestAccessAsync() == GeolocationAccessStatus.Allowed
                   && new Geolocator().LocationStatus != PositionStatus.NotAvailable;
        }

        /// <summary>
        ///     Method for listening to changes from the gps locator
        /// </summary>
        /// <exception cref="GpsNotAllowed">
        ///     Exception when system has deactivated GPS or user does not allow GPS to this
        ///     application
        /// </exception>
        /// <param name="method"></param>
        public static async void NotifyOnLocationUpdate(Func<Geoposition, Task> method)
        {
            if (!await CheckGpsAccessibility())
                throw new GpsNotAllowed();
            var locator = new Geolocator {DesiredAccuracyInMeters = Accuracy, MovementThreshold = MovementThreshold};
            locator.PositionChanged +=
                (sender, args) => { method.Invoke(args.Position); };
        }

        /// <summary>
        ///     Get the current location of the user as a GeoPosition
        ///     <exception cref="GpsNotAllowed">
        ///         Exception when system has deactivated GPS or user does not allow GPS to this
        ///         application
        ///     </exception>
        ///     <returns> Geoposition as gps information</returns>
        public static async Task<Geoposition> GetCurrentPosition()
        {
            if (!await CheckGpsAccessibility())
                throw new GpsNotAllowed();
            var locator = new Geolocator {DesiredAccuracyInMeters = Accuracy};
            return await locator.GetGeopositionAsync();
        }

        public static void ClearGeofences()
        {
            GeofenceMonitor.Current.Geofences.Clear();
        }

        /// <summary>
        ///     Calculate the distance between two geoposition
        /// </summary>
        /// <param name="source">The location of the source as Geoposition</param>
        /// <param name="target">The location to calculate the distance to</param>
        /// <returns> double as distance in meters between the two positions</returns>
        public static async Task<double> GetDistanceTo(Geoposition source, Geoposition target)
        {
            return (await GetRouteTo(source.Coordinate.Point, target.Coordinate.Point)).LengthInMeters;
        }

        public static async Task<double> GetDistanceTo(Geopoint source, Geopoint target)
        {
            return (await GetRouteTo(source, target)).LengthInMeters;
        }

        /// <summary>
        ///     Calculate the route between two geopositons
        /// </summary>
        /// <param name="source">The location of the source as Geoposition</param>
        /// <param name="target">The location to calculate the distance to</param>
        /// <returns>MapRoute between the two points <seealso cref="MapRoute" /></returns>
        public static async Task<MapRoute> GetRouteTo(Geopoint source, Geopoint target)
        {
            var result = await MapRouteFinder.GetWalkingRouteAsync(source, target);
            if (result.Status == MapRouteFinderStatus.Success)
                return result.Route;
            return null;
        }


        public static async Task<MapRoute> GetRouteBetween(List<Geopoint> sources)
        {
            return (await MapRouteFinder.GetWalkingRouteFromWaypointsAsync(sources)).Route;
        }

        /// <summary>
        ///     Method for listening if the user the route has leaved or exited
        /// </summary>
        /// <param name="route">The route the user is using <seealso cref="Route" /></param>
        /// <exception cref="GpsNotAllowed">
        ///     Exception when system has deactivated GPS or user does not allow GPS to this
        ///     application
        /// </exception>
        public static async Task PointOfInterestEntered(Func<Point, Task> notifier, Point pointOfInterest)
        {
            if (!await CheckGpsAccessibility())
                throw new GpsNotAllowed();
            var distance = 100;
            if (pointOfInterest is PointOfInterest)
                distance = 30;
            var geofence = new Geofence($"{pointOfInterest.GetHashCode()} notifier",
                new Geocircle(pointOfInterest.Location.Position, distance), MonitoredGeofenceStates.Entered, true,
                TimeSpan.FromSeconds(1));


            GeofenceMonitor.Current.Geofences.Add(geofence);

            TypedEventHandler<GeofenceMonitor, object> listener = null;
            listener = (monitor, obj) =>
            {
                if (pointOfInterest.IsVisited) return;
                foreach (var report in monitor.ReadReports())
                    if (report.Geofence.Id == geofence.Id)
                    {
                        notifier.Invoke(pointOfInterest);
                        GeofenceMonitor.Current.GeofenceStateChanged -= listener;
                    }
            };
            GeofenceMonitor.Current.GeofenceStateChanged += listener;
        }
    }

    /// <summary>
    ///     Exception which is thrown when GPS receiver does not allow access to the current location
    /// </summary>
    internal class GpsNotAllowed : Exception
    {
    }
}