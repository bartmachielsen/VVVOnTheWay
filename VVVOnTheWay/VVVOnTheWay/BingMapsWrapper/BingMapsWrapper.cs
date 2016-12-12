using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Services.Maps;
using VVVOnTheWay.Route;


namespace LocationSystem
{
    /// <summary>
    /// This class has as function to provide a bridge between the GPS Api from the windows device and the software.
    /// </summary>
    class BingMapsWrapper
    {
        
        ///<summary>
        /// Get the current location of the user as a GeoPosition
        ///</summary>
        /// <returns> Geoposition as gps information</returns>
        ///TODO: Return Geoposition of user
       public static Geoposition getCurrentPosition()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Calculate the distance between two geoposition
        /// </summary>
        /// <param name="source">The location of the source as Geoposition</param>
        /// <param name="target">The location to calculate the distance to</param>
        /// <returns> double as distance in meters between the two positions</returns>
        /// TODO: Return distance between points
       public static double getDistanceTo(Geoposition source, Geoposition target)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Method for checking if the user has lost the route.
        /// </summary>
        /// <param name="source">The location of the user as Geoposition <seealso cref="Geoposition"/></param>
        /// <param name="route">The route the user is using <seealso cref="Route"/></param>
        /// <returns>returns a boolean that is true if the user has lost the route</returns>
        public static Boolean RouteLeaved(Geoposition source, Route route)
        {
            throw new NotImplementedException();
        }

    }
}
