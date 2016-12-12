using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVVOnTheWay.FileIO
{
    /// <summary>
    /// Retrieves and distributes the information about PointsOfInterest of routes
    /// </summary>
    static class FullRouteIO
    {
        /// <summary>
        /// The filepath of the Blind Walls route file
        /// </summary>
        public readonly static string BlindWallsFilePath;

        /// <summary>
        /// The filepath of the Historical Kilometer route file
        /// </summary>
        public readonly static string HistoricalKilometerFilePath;

        /// <summary>
        /// Loads/creates the Historical Kilometer Route, which can be retrieved as this class' attributes
        /// </summary>
        /// <returns>The Route object for the Historical Kilometer route</returns>
        public static Route.Route LoadHistoricalKilometerRoute()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Loads/creates the Blind Walls Route, which can be retrieved as this class' attributes
        /// </summary>
        /// <returns>The Route object for the Blind Walls route</returns>
        public static Route.Route LoadBlindWallsRoute()
        {
            throw new NotImplementedException();
        }

    }
}
