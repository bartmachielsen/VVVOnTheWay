using System.Collections.Generic;
using Windows.Devices.Geolocation;

namespace VVVOnTheWay.Route
{
    internal class RouteTest
    {
        public RouteTest()
        {
            var pointsOfInterest = new List<Point>();
            pointsOfInterest.Add(new PointOfInterest(new[] {"VVV", "VVV"}, new[] {"", ""}, false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.594119, Longitude = 4.779405})));
            pointsOfInterest.Add(new PointOfInterest(new[] {"Liefdezuster", "Liefdezuster"}, new[] {"", ""}, false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.5932783, Longitude = 4.7793883})));
            pointsOfInterest.Add(new PointOfInterest(new[] {"Nassau Baronie Monument", "Nassau Baronie Monument"},
                new[] {"", ""}, false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.5925000, Longitude = 4.7796950})));
            pointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5925000, Longitude = 4.7793883})));
            pointsOfInterest.Add(new PointOfInterest(new[] {"The Light House", "The Light House"}, new[] {"", ""}, false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.5928333, Longitude = 4.7784717})));
            pointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5926667, Longitude = 4.7779167})));
            pointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5906117, Longitude = 4.7770000})));
            pointsOfInterest.Add(new PointOfInterest(new[] {"Castle of Breda", "Kasteel van Breda"}, new[] {"", ""},
                false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.5906117, Longitude = 4.7761667})));
            pointsOfInterest.Add(new PointOfInterest(new[] {"Regentgate", "Stadshouderspoort"}, new[] {"", ""},
                false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.5896950, Longitude = 4.7761383})));
            pointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5903333, Longitude = 4.7760000})));
            pointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5903883, Longitude = 4.7750000})));
            pointsOfInterest.Add(new PointOfInterest(new[] {"Huis van Brecht", "Huis van Brecht"}, new[] {"", ""},
                false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.5896950, Longitude = 4.7761383})));
            pointsOfInterest.Add(new PointOfInterest(new[] {"Spanjaardsgat", "Spanjaardsgat"}, new[] {"", ""},
                false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.5896950, Longitude = 4.7761383})));
            pointsOfInterest.Add(new PointOfInterest(new[] {"Vismarkt", "Vismarkt"}, new[] {"", ""},
                false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.5898333, Longitude = 4.7733333})));
            pointsOfInterest.Add(new PointOfInterest(new[] {"Havermarkt", "Havermarkt"}, new[] {"", ""},
                false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.5893617, Longitude = 4.7744450})));
            pointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5887783, Longitude = 4.7748883})));
            pointsOfInterest.Add(new PointOfInterest(new[] {"Grote kerk", "Grote kerk"}, new[] {"", ""},
                false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.5888333, Longitude = 4.7752783})));
            pointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5887783, Longitude = 4.7748883})));
            pointsOfInterest.Add(new PointOfInterest(new[] {"Het Poortje", "Het Poortje"}, new[] {"", ""},
                false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.5881950, Longitude = 4.7751383})));
            pointsOfInterest.Add(new PointOfInterest(new[] {"Ridderstraat", "Ridderstraat"}, new[] {"", ""},
                false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.5870833, Longitude = 4.7757500})));
            pointsOfInterest.Add(new PointOfInterest(new[] {"Grote Markt", "Grote Markt"}, new[] {"", ""},
                false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.5874167, Longitude = 4.7765550})));
            pointsOfInterest.Add(new PointOfInterest(new[] {"Bevrijdingsmonument", "Bevrijdingsmonument"},
                new[] {"", ""},
                false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.5880283, Longitude = 4.7763333})));
            pointsOfInterest.Add(new PointOfInterest(new[] {"Stadshuis", "Stadshuis"}, new[] {"", ""},
                false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.5887500, Longitude = 4.7761117})));
            pointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5879717, Longitude = 4.7763617})));
            pointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5875, Longitude = 4.776555})));
            pointsOfInterest.Add(new PointOfInterest(new[] {"Antonius van Paduakerk", "Antonius van Paduakerk"},
                new[] {"", ""},
                false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.5876383, Longitude = 4.77725})));
            pointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5882783, Longitude = 4.7785})));
            pointsOfInterest.Add(new PointOfInterest(new[] {"Library", "Bibliotheek"}, new[] {"", ""},
                false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.588, Longitude = 4.778945})));
            pointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5873617, Longitude = 4.7802217})));
            pointsOfInterest.Add(new PointOfInterest(new[] {"Kloosterkazerne", "Kloosterkazerne"}, new[] {"", ""},
                false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.5877217, Longitude = 4.7810283})));
            pointsOfInterest.Add(new PointOfInterest(new[] {"Chasse theater", "Chasse theater"}, new[] {"", ""},
                false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.58775, Longitude = 4.782})));
            pointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.58775, Longitude = 4.78125})));
            pointsOfInterest.Add(new PointOfInterest(new[] {"Binding van Isaac", "Binding van Isaac"}, new[] {"", ""},
                false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.5886117, Longitude = 4.7808883})));
            pointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5895, Longitude = 4.780445})));
            pointsOfInterest.Add(new PointOfInterest(new[] {"Beyerd", "Beyerd"}, new[] {"", ""},
                false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.5896667, Longitude = 4.781})));
            pointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5895, Longitude = 4.780445})));
            pointsOfInterest.Add(new PointOfInterest(new[] {"Gasthuispoort", "Gasthuispoort"}, new[] {"", ""},
                false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.589555, Longitude = 4.78})));
            pointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5894167, Longitude = 4.7798617})));
            pointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5890283, Longitude = 4.779695})));
            pointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.588555, Longitude = 4.7783333})));
            pointsOfInterest.Add(new PointOfInterest(new[] {"Willem Merkxtuin", "Willem Merkxtuin"}, new[] {"", ""},
                false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.5891117, Longitude = 4.777945})));
            pointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5896667, Longitude = 4.777805})));
            pointsOfInterest.Add(new PointOfInterest(new[] {"Begijnenhof", "Begijnenhof"}, new[] {"", ""},
                false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.589695, Longitude = 4.7783617})));
            pointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5896667, Longitude = 4.777805})));
            pointsOfInterest.Add(new PointOfInterest(new[] {"End point", "Einde punt"}, new[] {"", ""},
                false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.5895, Longitude = 4.77625})));
        }

        public Route HistoricRoute { get; set; }
    }
}