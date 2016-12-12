using System.Collections.Generic;
using Windows.Devices.Geolocation;

namespace VVVOnTheWay.Route
{
    internal class RouteTest
    {
        public RouteTest()
        {
            var pointsOfInterest = new List<PointOfInterest>();
            pointsOfInterest.Add(new PointOfInterest(new[] {"VVV", "VVV"}, new[] {"", ""}, false,
                new[] {"null", "null"}, null, new Geopoint(new BasicGeoposition {Latitude = 2.0, Longitude = 3.0})));
            pointsOfInterest.Add(new PointOfInterest(new[] {"Liefdezuster", "Liefdezuster" }, new[] {"", ""}, false,
                new[] {"null", "null"}, null, new Geopoint(new BasicGeoposition {Latitude = 2.0, Longitude = 3.0})));
            pointsOfInterest.Add(new PointOfInterest(new[] { "Nassau Baronie Monument", "Nassau Baronie Monument" }, new[] {"", ""}, false,
                new[] {"null", "null"}, null, new Geopoint(new BasicGeoposition {Latitude = 2.0, Longitude = 3.0})));
            pointsOfInterest.Add(new PointOfInterest(new[] {"VVV", "VVV"}, new[] {"", ""}, false,
                new[] {"null", "null"}, null, new Geopoint(new BasicGeoposition {Latitude = 2.0, Longitude = 3.0})));
            pointsOfInterest.Add(new PointOfInterest(new[] { "VVV", "VVV" }, new[] { "", "" }, false,
                new[] { "null", "null" }, null, new Geopoint(new BasicGeoposition { Latitude = 2.0, Longitude = 3.0 })));
        }

        public Route HistoricRoute { get; set; }
    }
}