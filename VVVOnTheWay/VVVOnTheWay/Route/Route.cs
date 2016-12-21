// Created by Bart Machielsen

#region

using System;
using System.Collections.Generic;

#endregion

namespace VVVOnTheWay.Route
{
    public class Route
    {
        /// <summary>
        ///     Default constructor.
        /// </summary>
        /// <param name="routePoints">sets <seealso cref="RoutePoints" /></param>
        public Route(List<Point> routePoints)
        {
            RoutePoints = routePoints;
        }

        /// <summary>
        ///     The list of POI that are on this route.
        /// </summary>
        public List<Point> RoutePoints { get; set; }

        /// <summary>
        ///     Saves the route into a file located at the specified location.
        /// </summary>
        /// <param name="path"> File path</param>
        public void SaveRouteProgress(string path)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Loads the route from a file located at the specified location.
        /// </summary>
        /// <param name="path"> File path</param>
        public void LoadRouteProgress(string path)
        {
            throw new NotImplementedException();
        }
    }
}