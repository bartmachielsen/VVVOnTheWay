using System.Collections.Generic;
using Windows.Devices.Geolocation;

namespace VVVOnTheWay.Route
{
    internal class RouteTest
    {
        public List<Point> PointsOfInterest;

        public RouteTest()
        {
            PointsOfInterest = new List<Point>();
            PointsOfInterest.Add(new PointOfInterest(new[] { "VVV", "VVV" }, new[] { "null", "null" }, false,
                new[] { "null", "null" }, null,
                new Geopoint(new BasicGeoposition { Latitude = 51.594119, Longitude = 4.779405 })));
            PointsOfInterest.Add(new PointOfInterest(new[] { "Liefdezuster", "Liefdezuster" }, new[] { "", "" }, false,
                new[] { "null", "null" }, null,
                new Geopoint(new BasicGeoposition { Latitude = 51.5932783, Longitude = 4.7793883 })));
            PointsOfInterest.Add(new PointOfInterest(new[] { "Nassau Baronie Monument", "Nassau Baronie Monument" },
                new[] { "", "" }, false,
                new[] { "null", "null" }, null,
                new Geopoint(new BasicGeoposition { Latitude = 51.5925000, Longitude = 4.7796950 })));
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition { Latitude = 51.5925000, Longitude = 4.7793883 })));
            PointsOfInterest.Add(new PointOfInterest(new[] { "The Light House", "The Light House" }, new[] { "", "" }, false,
                new[] { "null", "null" }, null,
                new Geopoint(new BasicGeoposition { Latitude = 51.5928333, Longitude = 4.7784717 })));
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition { Latitude = 51.5926667, Longitude = 4.7779167 })));
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition { Latitude = 51.5906117, Longitude = 4.7770000 })));
            PointsOfInterest.Add(new PointOfInterest(new[] { "Castle of Breda", "Kasteel van Breda" }, new[] { "", "" },
                false,
                new[] { "null", "null" }, null,
                new Geopoint(new BasicGeoposition { Latitude = 51.5906117, Longitude = 4.7761667 })));
            PointsOfInterest.Add(new PointOfInterest(new[] { "Regentgate", "Stadshouderspoort" }, new[] { "", "" },
                false,
                new[] { "null", "null" }, null,
                new Geopoint(new BasicGeoposition { Latitude = 51.5896950, Longitude = 4.7761383 })));
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition { Latitude = 51.5903333, Longitude = 4.7760000 })));
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition { Latitude = 51.5903883, Longitude = 4.7750000 })));
            PointsOfInterest.Add(new PointOfInterest(new[] { "Huis van Brecht", "Huis van Brecht" }, new[] { "", "" },
                false,
                new[] { "null", "null" }, null,
                new Geopoint(new BasicGeoposition { Latitude = 51.5896950, Longitude = 4.7761383 })));
            PointsOfInterest.Add(new PointOfInterest(new[] { "Spanjaardsgat", "Spanjaardsgat" }, new[] { "", "" },
                false,
                new[] { "null", "null" }, null,
                new Geopoint(new BasicGeoposition { Latitude = 51.5896950, Longitude = 4.7761383 })));
            PointsOfInterest.Add(new PointOfInterest(new[] { "Vismarkt", "Vismarkt" }, new[] { "", "" },
                false,
                new[] { "null", "null" }, null,
                new Geopoint(new BasicGeoposition { Latitude = 51.5898333, Longitude = 4.7733333 })));
            PointsOfInterest.Add(new PointOfInterest(new[] { "Havermarkt", "Havermarkt" }, new[] { "", "" },
                false,
                new[] { "null", "null" }, null,
                new Geopoint(new BasicGeoposition { Latitude = 51.5893617, Longitude = 4.7744450 })));
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition { Latitude = 51.5887783, Longitude = 4.7748883 })));
            PointsOfInterest.Add(new PointOfInterest(new[] { "Grote kerk", "Grote kerk" }, new[] { "", "" },
                false,
                new[] { "null", "null" }, null,
                new Geopoint(new BasicGeoposition { Latitude = 51.5888333, Longitude = 4.7752783 })));
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition { Latitude = 51.5887783, Longitude = 4.7748883 })));
            PointsOfInterest.Add(new PointOfInterest(new[] { "Het Poortje", "Het Poortje" }, new[] { "", "" },
                false,
                new[] { "null", "null" }, null,
                new Geopoint(new BasicGeoposition { Latitude = 51.5881950, Longitude = 4.7751383 })));
            PointsOfInterest.Add(new PointOfInterest(new[] { "Ridderstraat", "Ridderstraat" }, new[] { "", "" },
                false,
                new[] { "null", "null" }, null,
                new Geopoint(new BasicGeoposition { Latitude = 51.5870833, Longitude = 4.7757500 })));
            PointsOfInterest.Add(new PointOfInterest(new[] { "Grote Markt", "Grote Markt" }, new[] { "", "" },
                false,
                new[] { "null", "null" }, null,
                new Geopoint(new BasicGeoposition { Latitude = 51.5874167, Longitude = 4.7765550 })));
            PointsOfInterest.Add(new PointOfInterest(new[] { "Bevrijdingsmonument", "Bevrijdingsmonument" },
                new[] { "", "" },
                false,
                new[] { "null", "null" }, null,
                new Geopoint(new BasicGeoposition { Latitude = 51.5880283, Longitude = 4.7763333 })));
            PointsOfInterest.Add(new PointOfInterest(new[] { "Stadshuis", "Stadshuis" }, new[] { "", "" },
                false,
                new[] { "null", "null" }, null,
                new Geopoint(new BasicGeoposition { Latitude = 51.5887500, Longitude = 4.7761117 })));
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition { Latitude = 51.5879717, Longitude = 4.7763617 })));
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition { Latitude = 51.5875, Longitude = 4.776555 })));
            PointsOfInterest.Add(new PointOfInterest(new[] { "Antonius van Paduakerk", "Antonius van Paduakerk" },
                new[] { "", "" },
                false,
                new[] { "null", "null" }, null,
                new Geopoint(new BasicGeoposition { Latitude = 51.5876383, Longitude = 4.77725 })));
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition { Latitude = 51.5882783, Longitude = 4.7785 })));
            PointsOfInterest.Add(new PointOfInterest(new[] { "Library", "Bibliotheek" }, new[] { "", "" },
                false,
                new[] { "null", "null" }, null,
                new Geopoint(new BasicGeoposition { Latitude = 51.588, Longitude = 4.778945 })));
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition { Latitude = 51.5873617, Longitude = 4.7802217 })));
            PointsOfInterest.Add(new PointOfInterest(new[] { "Kloosterkazerne", "Kloosterkazerne" }, new[] { "", "" },
                false,
                new[] { "null", "null" }, null,
                new Geopoint(new BasicGeoposition { Latitude = 51.5877217, Longitude = 4.7810283 })));
            PointsOfInterest.Add(new PointOfInterest(new[] { "Chasse theater", "Chasse theater" }, new[] { "", "" },
                false,
                new[] { "null", "null" }, null,
                new Geopoint(new BasicGeoposition { Latitude = 51.58775, Longitude = 4.782 })));
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition { Latitude = 51.58775, Longitude = 4.78125 })));
            PointsOfInterest.Add(new PointOfInterest(new[] { "Binding van Isaac", "Binding van Isaac" }, new[] { "", "" },
                false,
                new[] { "null", "null" }, null,
                new Geopoint(new BasicGeoposition { Latitude = 51.5886117, Longitude = 4.7808883 })));
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition { Latitude = 51.5895, Longitude = 4.780445 })));
            PointsOfInterest.Add(new PointOfInterest(new[] { "Beyerd", "Beyerd" }, new[] { "", "" },
                false,
                new[] { "null", "null" }, null,
                new Geopoint(new BasicGeoposition { Latitude = 51.5896667, Longitude = 4.781 })));
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition { Latitude = 51.5895, Longitude = 4.780445 })));
            PointsOfInterest.Add(new PointOfInterest(new[] { "Gasthuispoort", "Gasthuispoort" }, new[] { "", "" },
                false,
                new[] { "null", "null" }, null,
                new Geopoint(new BasicGeoposition { Latitude = 51.589555, Longitude = 4.78 })));
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition { Latitude = 51.5894167, Longitude = 4.7798617 })));
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition { Latitude = 51.5890283, Longitude = 4.779695 })));
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition { Latitude = 51.588555, Longitude = 4.7783333 })));
            PointsOfInterest.Add(new PointOfInterest(new[] { "Willem Merkxtuin", "Willem Merkxtuin" }, new[] { "", "" },
                false,
                new[] { "null", "null" }, null,
                new Geopoint(new BasicGeoposition { Latitude = 51.5891117, Longitude = 4.777945 })));
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition { Latitude = 51.5896667, Longitude = 4.777805 })));
            PointsOfInterest.Add(new PointOfInterest(new[] { "Begijnenhof", "Begijnenhof" }, new[] { "", "" },
                false,
                new[] { "null", "null" }, null,
                new Geopoint(new BasicGeoposition { Latitude = 51.589695, Longitude = 4.7783617 })));
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition { Latitude = 51.5896667, Longitude = 4.777805 })));
            PointsOfInterest.Add(new PointOfInterest(new[] { "End point", "Einde punt" }, new[] { "", "" },
                false,
                new[] { "null", "null" }, null,
                new Geopoint(new BasicGeoposition { Latitude = 51.5895, Longitude = 4.77625 })));
        }


        public Route HistoricRoute { get; set; }
    }
}