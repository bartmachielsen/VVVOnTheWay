using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Services.Maps;
using VVVOnTheWay.Route;


namespace LocationSystem
{
    /// <summary>
    /// This class has as function to provide a bridge between the GPS Api from the windows device and the software.
    /// </summary>
    class BingMapsWrapper
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
        private static async Task<bool> checkGPSAccessibility()
        {
            return (await Geolocator.RequestAccessAsync()) == GeolocationAccessStatus.Allowed 
                && new Geolocator().LocationStatus != PositionStatus.NotAvailable;
        }

        /// <summary>
        /// Method for listening to changes from the gps locator
        /// </summary>
        /// <exception cref="GPSNotAllowed">Exception when system has deactivated GPS or user does not allow GPS to this application</exception>
        /// <param name="method"></param>
        public static async void notifyOnLocationUpdate(Func<Geoposition,object> method)
        {
            if (!await checkGPSAccessibility())
                throw new GPSNotAllowed();
           Geolocator locator = new Geolocator() {DesiredAccuracyInMeters = Accuracy, MovementThreshold = MovementThreshold};
            locator.PositionChanged +=
                (Geolocator sender, PositionChangedEventArgs args) => { method.Invoke(args.Position); };
        }

        ///<summary>
        /// Get the current location of the user as a GeoPosition
        /// <exception cref="GPSNotAllowed">Exception when system has deactivated GPS or user does not allow GPS to this application</exception>
        /// <returns> Geoposition as gps information</returns>
        public static async Task<Geoposition> getCurrentPosition()
        {
            if (!await checkGPSAccessibility())
                throw new GPSNotAllowed();
            Geolocator locator = new Geolocator() {DesiredAccuracyInMeters = Accuracy};
            return await locator.GetGeopositionAsync();
        }

        /// <summary>
        /// Calculate the distance between two geoposition
        /// </summary>
        /// <param name="source">The location of the source as Geoposition</param>
        /// <param name="target">The location to calculate the distance to</param>
        /// <returns> double as distance in meters between the two positions</returns>
        public static async Task<double> getDistanceTo(Geoposition source, Geoposition target)
        {
            
            return (await MapRouteFinder.GetWalkingRouteAsync(source.Coordinate.Point, target.Coordinate.Point)).Route.LengthInMeters;
        }

        

        /// <summary>
        /// Method for checking if the user has lost the route.
        /// </summary>
        /// <param name="source">The location of the user as Geoposition <seealso cref="Geoposition"/></param>
        /// <param name="route">The route the user is using <seealso cref="Route"/></param>
        /// <exception cref="GPSNotAllowed">Exception when system has deactivated GPS or user does not allow GPS to this application</exception>
        /// <returns>returns a boolean that is true if the user has lost the route</returns>
        public static async Task<Boolean> RouteLeaved(Geoposition source, Route route)
        {
            if (!await checkGPSAccessibility())
                throw new GPSNotAllowed();

            new Geopoint(new BasicGeoposition() {});
            throw new NotImplementedException();
        }

    }

    /// <summary>
    /// Exception which is thrown when GPS receiver does not allow access to the current location
    /// </summary>
    class GPSNotAllowed : Exception
    {
        
    }
}
