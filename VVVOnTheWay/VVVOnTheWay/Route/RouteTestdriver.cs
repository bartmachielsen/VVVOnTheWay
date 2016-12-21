// Created by Bart Machielsen

#region

using System.Collections.Generic;
using Windows.Devices.Geolocation;

#endregion

namespace VVVOnTheWay.Route
{
    internal class RouteTestDriver
    {
        public RouteTestDriver()
        {
            var pointsOfInterest = new List<Point>();
            pointsOfInterest.Add(new PointOfInterest(new[] {"VVV", "VVV"}, new[] {"VVV Kantoor", "null"}, false,
                new[] {"null", "null"}, @"Assets\BlindWalls\" + "staynice" + ".jpg",
                new Geopoint(new BasicGeoposition {Latitude = 51.594119, Longitude = 4.779405})));
            pointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5906117, Longitude = 4.7770000})));
            var testRoute = new Route(pointsOfInterest);
            var pointOfInterest = testRoute.RoutePoints[0] as PointOfInterest;
            if (pointOfInterest != null)
                NotificationSystem.NotificationSystem.SenToastificationAsync(pointOfInterest.GetNotification());
        }
    }
}