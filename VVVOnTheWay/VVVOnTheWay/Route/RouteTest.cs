// Created by Bart Machielsen

#region

using System.Collections.Generic;
using Windows.Devices.Geolocation;

#endregion

namespace VVVOnTheWay.Route
{
    internal class RouteTest
    {
        public List<Point> PointsOfInterest;

        public RouteTest()
        {
            PointsOfInterest = new List<Point>();
            //TODO: Christiaan
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
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5925000, Longitude = 4.7793883})));
            PointsOfInterest.Add(new PointOfInterest(new[] {"The Light House", "The Light House"}, new[] {"", ""}, false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.5928333, Longitude = 4.7784717})));
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5926667, Longitude = 4.7779167})));
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5906117, Longitude = 4.7770000})));
            PointsOfInterest.Add(new PointOfInterest(new[] {"Castle of Breda", "Kasteel van Breda"}, new[] {"", ""},
                false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.5906117, Longitude = 4.7761667})));
            PointsOfInterest.Add(new PointOfInterest(new[] {"Regentgate", "Stadshouderspoort"}, new[] {"", ""},
                false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.5896950, Longitude = 4.7761383})));
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5903333, Longitude = 4.7760000})));
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5903883, Longitude = 4.7750000})));
            PointsOfInterest.Add(new PointOfInterest(new[] {"Huis van Brecht", "Huis van Brecht"}, new[] {"", ""},
                false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.5896950, Longitude = 4.7761383})));
            PointsOfInterest.Add(new PointOfInterest(new[] {"Spanjaardsgat", "Spanjaardsgat"}, new[] {"", ""},
                false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.5896950, Longitude = 4.7761383})));
            PointsOfInterest.Add(new PointOfInterest(new[] {"Vismarkt", "Vismarkt"}, new[] {"", ""},
                false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.5898333, Longitude = 4.7733333})));
            PointsOfInterest.Add(new PointOfInterest(new[] {"Havermarkt", "Havermarkt"}, new[] {"", ""},
                false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.5893617, Longitude = 4.7744450})));
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5887783, Longitude = 4.7748883})));
            PointsOfInterest.Add(new PointOfInterest(new[] {"Grote kerk", "Grote kerk"}, new[] {"", ""},
                false,
                new[] { "null", "null" }, null,
                new Geopoint(new BasicGeoposition { Latitude = 51.5888333, Longitude = 4.7752783 })));



            //TODO: Bart
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5887783, Longitude = 4.7748883})));
            PointsOfInterest.Add(new PointOfInterest(new[] { "The Red Gate", "Het Rode Poortje" }, 
                new[]
                {
                    "On the left you see a red gate. At the stone gate are sheep heads and see the coat of arms of Breda. Behind the doors of the gate is a lane that leads to the back of the Grand Place. Earlier this gate served as the deterioration of the meat market which was located on the Grand Place. The gate was designed in 1614 by stonemason Melchior of Herbach. Until 1995 the Breda Museum was confirmed at this property.",
                     "Hier links zie je een rood poortje. Op de stenen poort zijn schapenkoppen en het wapen van Breda te zien. Achter de deuren van het poortje ligt een steeg die naar de achterkant van de Grote Markt leidt. Vroeger diende dit poortje als achteruitgang van de Vleeshal die zich op de Grote Markt bevond. Het poortje is in 1614 gemaakt door steenhouwer Melchior van Herbach. Tot 1995 was het Breda's Museum in dit pand bevestigd. "
                },
                false,
                null, "http://upload.wikimedia.org/wikipedia/commons/4/42/RM10234_Breda_-_Karrestraat_bij_7.jpg",
                new Geopoint(new BasicGeoposition {Latitude = 51.5881950, Longitude = 4.7751383})));

            PointsOfInterest.Add(new PointOfInterest(new[] {"Ridderstraat", "Ridderstraat"}, 
                new[] {  "Ridderstraat mall entrance near the Baroness in Breda Centre", "Ridderstraat nabij ingang winkelcentrum de Barones in Breda Centrum" },
                false,
                null, "https://upload.wikimedia.org/wikipedia/commons/e/eb/Ridderstraat_Breda_Centrum_DSCF2871.JPG",
                new Geopoint(new BasicGeoposition {Latitude = 51.5870833, Longitude = 4.7757500})));

            PointsOfInterest.Add(new PointOfInterest(new[] {"Large Market", "Grote Markt" },
                 new[]
                 {
                     "The nightlife mainly takes place in the city of Breda. Also Breda Breda City Centre or called. There are many trade-located around the Havermarkt and the Grote Markt in Breda.",
                     "Het uitgaansleven speelt zich voornamelijk af in de binnenstad van Breda. Ook wel Breda Centrum of Breda City genaamd. Er zijn vele horeca-gelegen rond de Havermarkt en de Grote Markt in Breda."

                 },
                false,
                null, "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fe/Grote_Markt_Breda_DSCF2843.JPG/800px-Grote_Markt_Breda_DSCF2843.JPG",
                new Geopoint(new BasicGeoposition {Latitude = 51.5874167, Longitude = 4.7765550})));

            PointsOfInterest.Add(new PointOfInterest(new[] { "liberation Monument", "Bevrijdingsmonument" },
                new[]
                {
                    "The monument stands at the intersection of the avenue claudius prince and Wilhelmina canal. Text on the monument: Built In gratitude for liberation in 1944 maria 1954",
                    "Het monument staat op de kruising van de claudius prinsenlaan en de wilhelminasingel. Tekst op het monument: Uit dank voor bevrijding 1944 gebouwd in mariajaar 1954"
                },
                false,
                null, "https://nl.tracesofwar.com/upload/1378100430130014.jpg",
                new Geopoint(new BasicGeoposition {Latitude = 51.5880283, Longitude = 4.7763333})));

            PointsOfInterest.Add(new PointOfInterest(new[] { "Breda city hall", "Stadshuis" }, 
                new[] {"The Breda City Hall on the Grote Markt in the center of Breda. This historic building has a stairway at the front. Find weddings of the Breda public place and official receptions of the mayor and aldermen of Breda. The town hall has a stone landing stage on the railing, lions bearing the arms of Breda and Brabant.",
                    "Het stadhuis van Breda staat op de Grote Markt in het centrum van Breda. Dit historische gebouw heeft een trap aan de voorkant. Hier vinden trouwerijen van de Bredase burgers plaats en ook officiële ontvangsten van het College van burgemeester en wethouders van Breda. Het stadhuis heeft een stenen bordestrap met op de balustrade, leeuwen die de wapens van Breda en Brabant dragen. "
                },
                false,
                null, "https://www.breda.nl/data/files/imagecache/eigen_keuze/450px-p1030219oude_stadhuis_breda.jpg",
                new Geopoint(new BasicGeoposition {Latitude = 51.5887500, Longitude = 4.7761117})));

            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5879717, Longitude = 4.7763617})));
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5875, Longitude = 4.776555})));

            PointsOfInterest.Add(new PointOfInterest(new[] { "Anthony of Padua Church", "Antonius van Paduakerk" },
                new[]
                {
                    "St. Anthony Cathedral (also called St. Anthony Church) is the cathedral church of the diocese of Breda in St. Jansstraat in Breda. The cathedral is dedicated to St. Anthony of Padua. The cathedral is located in the center of Breda, near the Grote Markt.",
                    "De Sint-Antoniuskathedraal (ook Sint-Antoniuskerk genoemd) is de kathedrale kerk van het bisdom Breda in de Sint-Jansstraat in Breda. De kathedraal is gewijd aan de heilige Antonius van Padua. De kathedraal bevindt zich in het centrum van Breda niet ver van de Grote Markt.\r\n"
                },
                false,
                null, "https://upload.wikimedia.org/wikipedia/commons/thumb/3/37/P1000965copySint-Antoniuskathedraal.jpg/266px-P1000965copySint-Antoniuskathedraal.jpg",
                new Geopoint(new BasicGeoposition {Latitude = 51.5876383, Longitude = 4.77725})));

            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5882783, Longitude = 4.7785})));

            PointsOfInterest.Add(new PointOfInterest(new[] {"Library", "Bibliotheek"}, new[] {"", ""},
                false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.588, Longitude = 4.778945})));

            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5873617, Longitude = 4.7802217})));

            PointsOfInterest.Add(new PointOfInterest(new[] {"Kloosterkazerne", "Kloosterkazerne"}, new[] {"", ""},
                false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.5877217, Longitude = 4.7810283})));

            PointsOfInterest.Add(new PointOfInterest(new[] {"Chasse theater", "Chasse theater"}, new[] {"", ""},
                false,
                new[] { "null", "null" }, null,
                new Geopoint(new BasicGeoposition { Latitude = 51.58775, Longitude = 4.782 })));


            //TODO: Menno
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.58775, Longitude = 4.78125})));
            PointsOfInterest.Add(new PointOfInterest(new[] {"Binding van Isaac", "Binding van Isaac"}, new[] {"", ""},
                false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.5886117, Longitude = 4.7808883})));
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5895, Longitude = 4.780445})));
            PointsOfInterest.Add(new PointOfInterest(new[] {"Beyerd", "Beyerd"}, new[] {"", ""},
                false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.5896667, Longitude = 4.781})));
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5895, Longitude = 4.780445})));
            PointsOfInterest.Add(new PointOfInterest(new[] {"Gasthuispoort", "Gasthuispoort"}, new[] {"", ""},
                false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.589555, Longitude = 4.78})));
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5894167, Longitude = 4.7798617})));
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5890283, Longitude = 4.779695})));
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.588555, Longitude = 4.7783333})));
            PointsOfInterest.Add(new PointOfInterest(new[] {"Willem Merkxtuin", "Willem Merkxtuin"}, new[] {"", ""},
                false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.5891117, Longitude = 4.777945})));
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5896667, Longitude = 4.777805})));
            PointsOfInterest.Add(new PointOfInterest(new[] {"Begijnenhof", "Begijnenhof"}, new[] {"", ""},
                false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.589695, Longitude = 4.7783617})));
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5896667, Longitude = 4.777805})));
            PointsOfInterest.Add(new PointOfInterest(new[] {"End point", "Einde punt"}, new[] {"", ""},
                false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.5895, Longitude = 4.77625})));
            HistoricRoute = new Route(PointsOfInterest);
        }

        public Route HistoricRoute { get; set; }
    }
}