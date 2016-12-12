using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVVOnTheWay.FileIO
{
    /// <summary>
    /// Saves and loads the last route with user progress to and from a file
    /// </summary>
    static class RouteProgressIO
    {
        /// <summary>
        /// The filepath of the last saved route with user progresss
        /// </summary>
        public readonly static string LastSavedRouteFilePath;

        /// <summary>
        /// Saves a route with user progress to a file
        /// </summary>
        /// <param name="routeInProgress">The Route object to save to a file</param>
        public static void SaveRouteProgressToFile(Route.Route routeInProgress)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Loads the last saved route with user progress from a file, which can be retrieved via this class' attributes
        /// </summary>
        /// <returns>Route object of the last saved Route with user progress</returns>
        public static Route.Route LoadLastSavedRouteFromFile()
        {
            throw new NotImplementedException();
        }

    }
}
