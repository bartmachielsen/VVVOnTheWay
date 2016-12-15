using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVVOnTheWay.Route
{
    class Route
    {   
        /// <summary>
        /// The list of POI that are on this route.
        /// </summary>
        public List<Point> RoutePoints { get; set; }
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="pointsOfInterest">sets <seealso cref="PointsOfInterest"/></param>
        public Route(List<Point> routePoints)
        {
            RoutePoints = routePoints;
        }
        /// <summary>
        /// Saves the route into a file located at the specified location.
        /// </summary>
        /// <param name="path"> File path</param>
        public void SaveRouteProgress(string path)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Loads the route from a file located at the specified location.
        /// </summary>
        /// <param name="path"> File path</param>
        public void LoadRouteProgress(string path)
        {
            throw new NotImplementedException();
        }

    }
}
