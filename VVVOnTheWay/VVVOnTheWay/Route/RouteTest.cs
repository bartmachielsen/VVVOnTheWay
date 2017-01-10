// Created by Bart Machielsen

#region

using Newtonsoft.Json;
using System.Collections.Generic;
using VVVOnTheWay.Route.Storage;
using Windows.Devices.Geolocation;
using Windows.Storage;

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
            PointsOfInterest.Add(new PointOfInterest(new[] { "VVV", "VVV" },
                new[] { "Bacon ipsum dolor amet venison meatball pork chop, sirloin shankle sausage ground round tri-tip beef ribs meatloaf capicola pork belly drumstick tail. Turkey short loin tail turducken, sirloin ribeye drumstick bresaola chuck. Pork chop rump swine drumstick pastrami strip steak. Short loin shank flank alcatra short ribs.",
                "Alcatra flank jowl, pastrami jerky kielbasa tail. Flank pork belly meatloaf pork, fatback kevin tail turducken capicola strip steak leberkas alcatra. Cupim meatloaf swine frankfurter chuck pig tri-tip. Drumstick salami flank turducken sirloin short ribs. Salami brisket kevin frankfurter, rump drumstick capicola sirloin tenderloin bresaola. Short loin tri-tip sirloin jowl brisket drumstick ground round porchetta venison prosciutto." }, 
                false,
                new[] { "null", "null" }, "vvv.png",
                new Geopoint(new BasicGeoposition { Latitude = 51.594119, Longitude = 4.779405 })));
            PointsOfInterest.Add(new PointOfInterest(new[] { "Liefdezuster", "Liefdezuster" }, 
                new[] { "Hamburger prosciutto burgdoggen spare ribs beef ribs. Capicola boudin landjaeger tri-tip, brisket biltong chicken burgdoggen andouille ham hock porchetta pancetta. Beef ribs tenderloin cupim ham hock. Burgdoggen sirloin jerky, pancetta leberkas ham hock frankfurter. Cupim capicola turkey leberkas. Rump meatball pastrami, meatloaf landjaeger beef alcatra pancetta ham. Kielbasa picanha bresaola drumstick kevin ham shoulder burgdoggen pork belly.",
                "Strip steak venison turducken turkey tri-tip tenderloin ground round tongue tail chuck burgdoggen picanha spare ribs pancetta. Jowl ham chicken chuck ribeye pork loin frankfurter biltong fatback boudin beef shank capicola. Shankle burgdoggen tenderloin, pancetta shank ground round chuck doner. Brisket salami sausage, fatback ball tip t-bone hamburger burgdoggen. Hamburger tail cupim, short ribs doner flank fatback frankfurter tongue pork chop rump tri-tip shoulder strip steak alcatra. Tri-tip hamburger bacon, filet mignon short loin tenderloin t-bone pastrami ribeye kevin kielbasa pancetta flank. Tri-tip leberkas cow shankle, short loin landjaeger boudin ham t-bone." }, 
                false,
                new[] { "null", "null" }, "liefdeszuster.jpg",
                new Geopoint(new BasicGeoposition { Latitude = 51.5932783, Longitude = 4.7793883 })));
            PointsOfInterest.Add(new PointOfInterest(new[] { "Nassau Baronie Monument", "Nassau Baronie Monument" },
                new[] { "Rump tenderloin tongue shoulder pancetta boudin, ground round jerky pork chop picanha chuck pastrami strip steak ham hock meatball. Meatball tri-tip short ribs meatloaf shoulder corned beef flank jowl beef ham hock fatback pork chop ham bresaola burgdoggen. Short ribs landjaeger pork jerky. Doner tongue short ribs, pork chop capicola drumstick prosciutto ribeye sirloin. Salami shank meatball tail beef ribs hamburger. Frankfurter pork belly prosciutto, ham hock shoulder filet mignon ham landjaeger picanha kielbasa beef hamburger venison bresaola meatloaf.",
                "Short ribs tenderloin pastrami pork loin occaecat doner tempor jowl. Picanha flank strip steak non beef. Adipisicing bacon ut minim aliqua. Nisi laborum shankle lorem tongue short ribs drumstick deserunt, minim kielbasa ball tip velit kevin enim cupim. Fatback ham cow commodo bresaola ut shoulder reprehenderit fugiat landjaeger meatball chuck rump minim. Flank dolore venison qui veniam, bresaola short ribs quis porchetta." }, 
                false,
                new[] { "null", "null" }, "baronie.jpg",
                new Geopoint(new BasicGeoposition { Latitude = 51.5925000, Longitude = 4.7796950 })));
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5925000, Longitude = 4.7793883})));
            PointsOfInterest.Add(new PointOfInterest(new[] {"The Light House", "The Light House"}, 
                new[] {"Jowl leberkas bresaola meatball, laboris ut cillum nisi boudin excepteur et est. Shankle velit ham hock andouille tri-tip. Consequat dolore pork loin, tenderloin short ribs tongue pork chop cillum swine occaecat pancetta corned beef ad. Labore sunt in sed pariatur jowl hamburger frankfurter bacon pancetta biltong laboris dolore kevin mollit. Do spare ribs leberkas dolor culpa.",
                "Aliquip minim cupidatat, dolore meatball ball tip pork chop nisi biltong shoulder jerky short loin pariatur. Short ribs landjaeger beef ribs deserunt ribeye eiusmod esse kevin meatloaf swine leberkas shoulder dolore lorem pork loin. Sirloin anim meatball strip steak bacon tongue turducken rump ex consectetur. Short ribs ex magna, salami tenderloin ut lorem drumstick pastrami prosciutto jowl." }, 
                false,
                new[] {"null", "null"}, "lighthouse.jpg",
                new Geopoint(new BasicGeoposition {Latitude = 51.5928333, Longitude = 4.7784717})));
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5926667, Longitude = 4.7779167})));
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5906117, Longitude = 4.7770000})));
            PointsOfInterest.Add(new PointOfInterest(new[] {"Castle of Breda", "Kasteel van Breda"}, 
                new[] {"Alcatra ut nulla fatback pork belly dolore. Esse incididunt tail biltong fatback aliqua reprehenderit frankfurter pancetta tenderloin brisket et. Commodo non reprehenderit, id ham hock pork loin minim ex flank doner occaecat jerky fatback rump nulla. Burgdoggen eiusmod pork belly cillum, tenderloin salami nisi excepteur sausage ullamco velit ipsum labore. Minim non ut picanha prosciutto elit.",
                "Ham tail meatball, aliqua brisket burgdoggen strip steak bacon tenderloin aute shoulder biltong. In pariatur capicola biltong filet mignon hamburger meatball jowl elit ham hock cillum duis pork belly ipsum proident. Frankfurter ipsum turkey magna, strip steak et id nulla cow ribeye proident brisket. Pig tongue cow duis, prosciutto incididunt filet mignon deserunt bresaola eiusmod. Exercitation cow leberkas qui commodo, beef consequat pork belly turducken officia sint in voluptate. Prosciutto kevin cupidatat duis." },
                false,
                new[] {"null", "null"}, "kasteel.jpg",
                new Geopoint(new BasicGeoposition {Latitude = 51.5906117, Longitude = 4.7761667})));
            PointsOfInterest.Add(new PointOfInterest(new[] {"Regentgate", "Stadshouderspoort"}, 
                new[] {"Aliqua nulla laboris eiusmod id dolore. Alcatra picanha short loin eu, irure officia quis frankfurter reprehenderit porchetta burgdoggen corned beef elit pastrami pork chop. Tri-tip incididunt fugiat in aute ad alcatra beef ribs turkey qui chuck tongue flank. Qui anim ipsum ea. Deserunt duis occaecat hamburger kielbasa magna landjaeger beef cillum commodo strip steak mollit excepteur doner salami.",
                "Drumstick sed aliquip eu ex ut. Turducken shankle corned beef incididunt andouille short loin tail exercitation eu et elit aliqua bacon alcatra brisket. Voluptate cupidatat sirloin, short loin ball tip consequat ground round tenderloin anim short ribs ad. Doner non excepteur dolore exercitation, alcatra sunt shankle andouille tongue. Tongue meatloaf officia et, ball tip reprehenderit dolore boudin short ribs est kielbasa filet mignon short loin veniam tenderloin. Sausage velit consectetur aliquip bacon. Tenderloin capicola dolore commodo incididunt, jowl exercitation." },
                false,
                new[] {"null", "null"}, "stadhouderspoort.jpg",
                new Geopoint(new BasicGeoposition {Latitude = 51.5896950, Longitude = 4.7761383})));
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5903333, Longitude = 4.7760000})));
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5903883, Longitude = 4.7750000})));
            PointsOfInterest.Add(new PointOfInterest(new[] {"Huis van Brecht", "Huis van Brecht"}, 
                new[] {"Kielbasa beef ham hock, eu irure turducken ullamco shankle reprehenderit laborum. Laborum chicken ut velit swine burgdoggen prosciutto. Cow pork meatloaf cillum. Eu brisket ad jowl reprehenderit. Landjaeger ullamco turducken, turkey qui nostrud non consectetur. Ut occaecat pastrami frankfurter ullamco sirloin in pig pork non. Tongue consequat tempor shoulder anim ham ut venison.",
                "Incididunt shoulder landjaeger, enim boudin labore magna occaecat short ribs bresaola filet mignon pork belly corned beef cow kielbasa. Ad turducken beef lorem adipisicing officia irure consectetur porchetta dolore. Adipisicing doner corned beef porchetta bacon filet mignon veniam aute irure sint. Frankfurter ea excepteur ham hock ut beef prosciutto. Anim tenderloin consequat minim kielbasa, picanha adipisicing ut est esse. Aute short loin excepteur sunt pork chop pork loin t-bone ut dolore sint ut nisi ham hock." },
                false,
                new[] {"null", "null"}, "brecht.jpg",
                new Geopoint(new BasicGeoposition {Latitude = 51.5896950, Longitude = 4.7761383})));
            PointsOfInterest.Add(new PointOfInterest(new[] {"Spanjaardsgat", "Spanjaardsgat"}, 
                new[] {"Quis beef deserunt nisi magna, ut esse. Pastrami bacon salami, qui shank voluptate tempor chicken andouille consequat. Pig in corned beef fatback, turducken t-bone magna aliquip eiusmod shankle sausage drumstick nisi doner pork belly. T-bone culpa laboris, commodo pork belly boudin excepteur short loin brisket salami sint aliquip frankfurter. Biltong reprehenderit sunt ea dolore id et jowl nulla ham ipsum sed dolor commodo sirloin. Tri-tip porchetta incididunt ribeye alcatra lorem do spare ribs kevin picanha hamburger pork loin turducken cow. Ut doner cupim occaecat sausage.",
                "Bacon ut incididunt chuck proident culpa. Esse et proident tempor corned beef. Commodo occaecat quis, eiusmod jerky aliquip beef in laboris ipsum elit. Pork loin sirloin leberkas elit est. Biltong culpa drumstick boudin picanha beef in hamburger incididunt capicola mollit non. Beef ribs incididunt kevin, reprehenderit eu bacon mollit ham proident flank." },
                false,
                new[] {"null", "null"}, "spanjaardsgat.jpg",
                new Geopoint(new BasicGeoposition {Latitude = 51.5896950, Longitude = 4.7761383})));
            PointsOfInterest.Add(new PointOfInterest(new[] {"Vismarkt", "Vismarkt"}, 
                new[] {"Shoulder pork chop tongue sed officia ea hamburger. Ut adipisicing officia, bacon esse pariatur pig commodo bresaola flank. Doner tail t-bone in, veniam chuck nostrud rump nulla. Commodo chuck pork loin et shank turkey. Dolore short ribs non doner quis adipisicing filet mignon pork belly hamburger kielbasa aliqua turducken tail dolore. Cupim shank exercitation boudin. Venison ex picanha exercitation cow veniam.",
                "Pork belly velit ullamco qui beef short loin. Ball tip aliqua nisi, dolore enim pariatur ad duis. Occaecat est incididunt, pig short loin beef fugiat. Pariatur meatloaf culpa enim, tongue jerky excepteur in laborum shankle strip steak bacon cow." },
                false,
                new[] {"null", "null"}, "vismarkt.jpg",
                new Geopoint(new BasicGeoposition {Latitude = 51.5898333, Longitude = 4.7733333})));
            PointsOfInterest.Add(new PointOfInterest(new[] {"Havermarkt", "Havermarkt"}, 
                new[] {"Bacon ipsum dolor amet tail picanha proident dolore esse aliqua andouille boudin meatball, ad commodo. Prosciutto fugiat proident dolore. Ham dolore quis anim, cupim tail mollit meatball sausage alcatra kevin excepteur non. Ut sint ribeye et ham, commodo nisi pork belly ground round elit. Dolore jowl biltong, tenderloin mollit porchetta short ribs prosciutto shankle.",
                "Tempor voluptate chicken id lorem. Ball tip aliquip consectetur, id kielbasa beef ribs meatloaf frankfurter ut swine flank eu strip steak. Dolore beef ribs nostrud short ribs occaecat tenderloin. Venison short ribs boudin mollit non aliquip fatback capicola laboris do sed. Excepteur tongue ut deserunt, leberkas sirloin incididunt tempor exercitation bacon. Sed sirloin excepteur, jerky chuck reprehenderit lorem." },
                false,
                new[] {"null", "null"}, "havermarkt.jpg",
                new Geopoint(new BasicGeoposition {Latitude = 51.5893617, Longitude = 4.7744450})));
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5887783, Longitude = 4.7748883})));
            PointsOfInterest.Add(new PointOfInterest(new[] {"Grote kerk", "Grote kerk"}, 
                new[] {"Dolore turducken rump consequat, tri-tip meatball alcatra est cupidatat. Turducken ad turkey cupidatat, eiusmod bresaola cow ullamco beef ribs ball tip shoulder lorem kielbasa shank. Est prosciutto ullamco tenderloin venison cow, nostrud magna dolor pork chop. Jowl consequat fatback, in esse capicola qui commodo ullamco flank tail in turducken cow.",
                "Prosciutto pork chuck minim. Fatback deserunt strip steak, meatball mollit tail exercitation duis aliquip pork prosciutto. Boudin aliquip jowl dolore sunt tongue. Qui officia beef ribs esse veniam." },
                false,
                new[] { "GroteKlok.mp3", "GroteKlok.mp3" }, "kerk.jpg",
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
                null, "RM10234_Breda_-_Karrestraat_bij_7.jpg",
                new Geopoint(new BasicGeoposition {Latitude = 51.5881950, Longitude = 4.7751383})));

            PointsOfInterest.Add(new PointOfInterest(new[] {"Ridderstraat", "Ridderstraat"}, 
                new[] {  "Ridderstraat mall entrance near the Baroness in Breda Centre", "Ridderstraat nabij ingang winkelcentrum de Barones in Breda Centrum" },
                false,
                null, "Ridderstraat_Breda_Centrum_DSCF2871.JPG",
                new Geopoint(new BasicGeoposition {Latitude = 51.5870833, Longitude = 4.7757500})));

            PointsOfInterest.Add(new PointOfInterest(new[] {"Large Market", "Grote Markt" },
                 new[]
                 {
                     "The nightlife mainly takes place in the city of Breda. Also Breda Breda City Centre or called. There are many trade-located around the Havermarkt and the Grote Markt in Breda.",
                     "Het uitgaansleven speelt zich voornamelijk af in de binnenstad van Breda. Ook wel Breda Centrum of Breda City genaamd. Er zijn vele horeca-gelegen rond de Havermarkt en de Grote Markt in Breda."

                 },
                false,
                null, "800px-Grote_Markt_Breda_DSCF2843.JPG",
                new Geopoint(new BasicGeoposition {Latitude = 51.5874167, Longitude = 4.7765550})));

            PointsOfInterest.Add(new PointOfInterest(new[] { "liberation Monument", "Bevrijdingsmonument" },
                new[]
                {
                    "The monument stands at the intersection of the avenue claudius prince and Wilhelmina canal. Text on the monument: Built In gratitude for liberation in 1944 maria 1954",
                    "Het monument staat op de kruising van de claudius prinsenlaan en de wilhelminasingel. Tekst op het monument: Uit dank voor bevrijding 1944 gebouwd in mariajaar 1954"
                },
                false,
                null, "1378100430130014.jpg",
                new Geopoint(new BasicGeoposition {Latitude = 51.5880283, Longitude = 4.7763333})));

            PointsOfInterest.Add(new PointOfInterest(new[] { "Breda city hall", "Stadshuis" }, 
                new[] {"The Breda City Hall on the Grote Markt in the center of Breda. This historic building has a stairway at the front. Find weddings of the Breda public place and official receptions of the mayor and aldermen of Breda. The town hall has a stone landing stage on the railing, lions bearing the arms of Breda and Brabant.",
                    "Het stadhuis van Breda staat op de Grote Markt in het centrum van Breda. Dit historische gebouw heeft een trap aan de voorkant. Hier vinden trouwerijen van de Bredase burgers plaats en ook officiële ontvangsten van het College van burgemeester en wethouders van Breda. Het stadhuis heeft een stenen bordestrap met op de balustrade, leeuwen die de wapens van Breda en Brabant dragen. "
                },
                false,
                null, "450px-p1030219oude_stadhuis_breda.jpg",
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
                null, "266px-P1000965copySint-Antoniuskathedraal.jpg",
                new Geopoint(new BasicGeoposition {Latitude = 51.5876383, Longitude = 4.77725})));

            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5882783, Longitude = 4.7785})));

            PointsOfInterest.Add(new PointOfInterest(new[] {"Library", "Bibliotheek"}, 
                new[] {"New Veste, Center for the Arts, a center for various art forms located on the Molenstraat 6 in the city of Breda in the district Breda Centre. In the New Veste are four main directions in art: music, art, theater and dance. There is a lot of collaboration with the city of Breda schools. The cooperation ranges from excursions to customization.",
                    "De Nieuwe Veste, Centrum voor de Kunsten, is een centrum voor diverse kunstvormen gelegen aan de Molenstraat 6 in de binnenstad van Breda in het stadsdeel Breda Centrum. In de Nieuwe Veste staan vier kunstrichtingen centraal: muziek, beeldende kunst, theater en dans. Er vindt veel samenwerking plaats met de Bredase scholen. De samenwerking varieert van excursies tot maatwerk." },
                false,
                null, "Breda_Bibliotheek.jpg",
                new Geopoint(new BasicGeoposition {Latitude = 51.588, Longitude = 4.778945})));

            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5873617, Longitude = 4.7802217})));

            PointsOfInterest.Add(new PointOfInterest(new[] {"Kloosterkazerne", "Kloosterkazerne"}, new[] {"The Kloosterkazerne is a building in Breda to the Monastery Square and Claudius Prinsenlaan in the center of Breda. It is close to the district Chassé Park. It was originally part of a convent built by the Norbertinessenconvent St. Catharinadal.",
                "De Kloosterkazerne is een bouwwerk in Breda aan het Kloosterplein en de Claudius Prinsenlaan in het centrum van Breda. Het ligt dicht bij de wijk Chassé Park. Het maakte oorspronkelijk deel uit van een nonnenklooster gebouwd in opdracht van het Norbertinessenconvent Sint-Catharinadal." },
                false,
                null, "266px-Breda_kloosterkazerne.jpg",
                new Geopoint(new BasicGeoposition {Latitude = 51.5877217, Longitude = 4.7810283})));

            PointsOfInterest.Add(new PointOfInterest(new[] {"Chasse theater", "Chasse theater"}, new[] {"Chassé Theater is a large theater in the city of Breda, next to the old Kloosterkazerne. The theater is named after the army officer David Hendrik Chassé. It is housed in a modern building with a striking undulating roof to a design by Herman Hertzberger, dating back to 1995. The theater consists of three theaters and three cinemas with a total of 2500 seats.\r\n\r\nPrecursor of the Chassé Theater was the theater Concordia.",
                "Het Chassé Theater is a groot theater in de binnenstad van Breda, naast de oude Kloosterkazerne. Het theater is vernoemd naar de legerofficier David Hendrik Chassé. Het is gehuisvest in Een modern gebouw met Een opvallend golvend dak Naar een Ontwerp van Herman Hertzberger, Dat uit 1995 dateert. Het theater is also uit three Theater- en three filmzalen voldaan Totaal ruim 2500 zitplaatsen.Voorloper Van het Chassé Theater was de Stadsschouwburg Concordia." },
                false,
                null, "P1010936Chasse_theater.JPG",
                new Geopoint(new BasicGeoposition { Latitude = 51.58775, Longitude = 4.782 })));


            //TODO: Menno
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.58775, Longitude = 4.78125})));
            PointsOfInterest.Add(new PointOfInterest(new[] {"Binding van Isaac", "Binding van Isaac"}, new[] {"This art work depict a biblical story: The Binding of Isaac. In this story, Abraham is tasked by God to offer his son to Him. Trusting in God, he binds Isaac before laying him on the offer altar. In the last moment before Abraham can offer his son, an angel descends from the heavens." +
                                                                                                              "The angel stops Abraham and tells him: now I know you fear God. At this point Abraham sees a ram caught in some nearby bushes, and offers the ram instead of Isaac.", "Het kunstwerk Binding van Isaäc is een beeltenis van het bijbelse verhaal waarin Abraham de opdracht krijgt om zijn eigen zoon Isaac te offeren in de opdracht van God." +
                                                                                                                  "Hiervoor bind hij zijn zoon vast voordat hij deze of het offeraltaar legt. Op het laatste moment voordat Abraham zijn zoon tot offer maakt, daalt er een engel neer vanuit de hemel." +
                                                                                                                  "Deze zegt tegen Abraham dat hij nu inziet dat Abraham bang is voor God. In plaats van zijn eigen zoon mag hij dan van de engel een ram offeren."},
                false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.5886117, Longitude = 4.7808883})));
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5895, Longitude = 4.780445})));
            PointsOfInterest.Add(new PointOfInterest(new[] {"Beyerd", "Beyerd"}, new[] {
                "The Beyerd (passers-stay), is a building that is part of a guest house. This guest house will first mentioned in the will of Godfrey IV Shoten, lord of Breda. " +
"This listing, which took place in 1246, bequeaths a total of three pounds of Leuven (= +/- three rijksdaalders = +/- seven and a half guilders = +/- three euros and forty euro cents) to the Gasthuys Breda . " +
"This guest house consisted of four parts. The old men's home, a guest house chapel, cemetery and Beyerd. In the course of time a lot has happened: From 1295 to 1308 the Beyerd housed a number of sisters just the St. Catharinadal monastery after the monastery was destroyed by the St. Aagthenvloed. " +
"After the old guest house once burned down (in 1534). It then offered recidence to brothers. It also was used as a residence for people suffering from leprosy, the plague and insanity. In 1634 the building was expanded with a new facade , dining room and a room for the guesthouse masters. " +
"The facade is from 1643 and designed by Laureys Dijffhout. It is made of brick and has a classicistesche hardstone entrance gate. Atop the building is located a distinctively small tower with a bell (dating back to 1502, one of the oldest in Breda) which rings each with half hour intervals. In 1685 the neighboring farm hard to make way for a alms house. " +
"A brewery was added to the complex this year as well. After this it is modernized again. In 1854, the dormitory has been increased after the declaration of the armenwet and features iron beds." +
"In the nineteenth century the Beyerd seems to dissapear, but in 1934, the guest house is grandly renovated by J. Struyt whereby a gallery at the back is added. After that, in 1956, the guest house received an entirely different purpose. It became a cultural center named : the Beyerd. During this renovation it lost the last remnants of the old guest house chapel. " +
"After which the building was remodeled several times (in 1963, 1988, 1990 and 2005). After which the building became the Museum Of The Image is in 2008 (which formerly was know as the Graphic Design Museum).",

                "De Beyerd (passantenverblijf) is een pand dat onderdeel uitmaakt van een gasthuis. Dit gasthuis word voor het eerst vermeld in het testament van Godfried IV van Shoten, heer van Breda." +
                                                                                            "Deze vermelding, die plaats vond in 1246, schenkt een bedrag van drie Leuvense ponden (= +/- drie rijksdaalders = +/- zeven en een halve gulden = +/- drie euro en veertig euro cent) toe aan het Gasthuys te Breda." +
                                                                                            "Dit gasthuis bestond uit vier delen: het Oudemannenhuis, een gasthuiskapel, een kerkhof en de Beyerd. In de loop der tijden is er veel gebeurd: Van 1295 tot 1308 hebben er een aantal zusters gewoon van het St. Catharinadal klooster omdat het klooster was vernietigd door de Sint-Aagthenvloed." +
                                                                                            "Hierna is het oude gasthuis een keer afgebrand (in 1534). Het bood toen odnerdak aan broeders. Tevens werd het gebruit als verblijf voor mensen die leden aan lepra of de pest en krankzinnigen. Hierna is het gebouw in 1634 uitgebreid met een nieuwe voorgevel, eetzaal en een kamer voor de gasthuismeesters." +
                                                                                            "De gevel is van 1643 en ontworpen door Laureys Dijffhout. Hij is vervaardigd in baksteen en heeft een classicistesche hardstenen ingangspoort. Boven op het gebouw bevind zich een karakterestiek torentje met een klok (dateert uit 1502, een van de oudste in Breda) die elk half uur luid. In 1685 is de omliggende boerderij om plaats te maken voor provenierswoningen." +
                                                                                            "Tevens kwam er in dit jaar een brouwerij bij het complex. Hierna is het nog een keer gemoderniseerd. In 1854, na de invoer van de armen wet, is de slaapzaal vergroot en voorzien van ijzeren bedden." +
                                                                                            "In de negentiende eeuw verdween de Beyerd, maar in 1934 is het gasthuis groots verbouwd door J. Struyt waarbij er een gallerij aan de achterkant is bijgebouwd. Hierna, in 1956 kreeg het gasthuis een geheel andere bestemming. Het werd destijds een cultureel centrum genaamd: de Beyerd. Tijdens deze verbouwing verdwenen de laaste resten van de oude gasthuiskapel." +
                                                                                            "Hierna is het gebouw nog een aantal keer verbouwd (in 1963, 1988, 1990 en 2005) waarna het gebouw in 2008 het Museum Of The Image zit (wat voorheen het Graphic Design Museum heette). "},
                false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.5896667, Longitude = 4.781})));
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5895, Longitude = 4.780445})));
            PointsOfInterest.Add(new PointOfInterest(new[] {"Gasthuispoort", "Gasthuispoort"}, new[] {"The Hospital Gate is a part of the City Wall die Breda formerly encircled. Was this at the end of the Veemarktstraat. The name of this street was specifically Gasthuisstraat origin. This is the street where the former Hospital (now The Museum Of The Image) wing. "+
"The guest house gate was built around 1330, as a part of the earthen ramparts surrounding Breda. Later, a wall built by order of Duke John III of Brabant. This wall was finally completed in 1410. This wall was torn down between 1536 and 1538. After that, from 1537 to 1546 Breda was surrounded by earthen ramparts once again.",
                "De Gasthuispoort is een onderdeel van de stadsmuur die Breda vroeger omringde. Deze stond aan het einde van de Veemarktstraat. De naam van deze straat was oorsprongkelijk Gasthuisstraat. Dit is de straat waar het voormalige gasthuis (nu het Museum Of The Image) aan lag." +
                                                                                                          "De Gasthuis poort is rond 1330 gebouwd, als onderdeel van de aarden omwalling rondom Breda. Later is een muur gebouwd in opdracht van hertog Jn III van Brabant. Deze was pas in 1410 voltooid. Deze muur werd in 1536 tot 1538 gesloopt, waarna er van 1537 tot 1546 weer aarden wallen om Breda heen lagen."},
                false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.589555, Longitude = 4.78})));
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5894167, Longitude = 4.7798617})));
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5890283, Longitude = 4.779695})));
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.588555, Longitude = 4.7783333})));
            PointsOfInterest.Add(new PointOfInterest(new[] {"Willem Merkxtuin", "Willem Merkxtuin"}, new[] {"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque condimentum lacus et sollicitudin auctor. Integer varius, leo ut posuere ornare, quam ante ornare leo, nec ornare orci justo ut tellus. Duis lacinia enim ac interdum vehicula. Nunc semper semper velit at congue. Nunc tortor urna, finibus vitae tellus accumsan, efficitur interdum quam. Sed suscipit condimentum quam, et consectetur massa iaculis sit amet. Nullam interdum orci ut dignissim lobortis. Sed non odio et neque tincidunt vulputate vel a diam.",
                "De Willem Merx tuin, vernoemd naar de gelijk namige burgemeester die zetelde van 1967 tot 1983, is een 'oase'van kunst en rust in de binnenstad." +
                                                                                                                "Er zijn veertien kunstvoorwerpen te bewonderen. Deze tuin beind zich achter "},
                false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.5891117, Longitude = 4.777945})));
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5896667, Longitude = 4.777805})));
            PointsOfInterest.Add(new PointOfInterest(new[] {"Begijnenhof", "Begijnenhof"}, new[] { "Duis cursus urna lacus, et aliquam dui vehicula nec. Proin aliquam cursus interdum. Sed pellentesque arcu aliquam dui feugiat, euismod commodo turpis scelerisque. Proin faucibus erat sapien, eu dictum purus suscipit efficitur. Quisque quis lobortis odio. Sed efficitur arcu semper quam blandit facilisis. Duis malesuada ligula ante, id condimentum tortor bibendum quis. Integer mattis odio mauris, vitae molestie tortor malesuada ut. Cras vitae leo maximus libero elementum gravida. Sed vel nisi at sapien auctor vestibulum at non orci. Nulla bibendum pharetra maximus. Ut porttitor mauris venenatis, vulputate lorem vulputate, placerat sem. Cras dignissim lacus nunc, placerat pharetra est accumsan at. Suspendisse dapibus convallis urna.",
                "Fusce dui turpis, tempor quis mauris ac, pharetra varius ligula. Nullam non cursus dolor. Curabitur congue odio tellus, a blandit massa iaculis id. Maecenas at elementum lectus. Etiam imperdiet lectus non leo condimentum elementum. Nullam auctor sem tortor, at vestibulum elit blandit et. Vivamus lectus ex, venenatis sed dolor in, luctus posuere arcu. Aenean urna ligula, elementum sit amet risus non, cursus posuere orci. Sed bibendum ligula eget nibh tempor euismod. Donec eget erat ut eros euismod fringilla. Integer et lacus fermentum, consequat magna placerat, varius elit. Pellentesque egestas, dui vitae consequat viverra, erat nisi venenatis nisl, sed congue massa orci vitae felis." },
                false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.589695, Longitude = 4.7783617})));
            PointsOfInterest.Add(
                new Point(new Geopoint(new BasicGeoposition {Latitude = 51.5896667, Longitude = 4.777805})));
            PointsOfInterest.Add(new PointOfInterest(new[] {"End point", "Einde punt"}, new[] { "Duis neque magna, mollis id tellus et, viverra fringilla magna. Donec pretium purus sed placerat bibendum. Sed euismod elementum condimentum. Fusce eget tellus molestie, dictum eros a, sollicitudin ex. Maecenas rhoncus dictum sem, vel molestie sapien. Integer pharetra et quam vulputate dictum. Suspendisse at urna quis nisl vestibulum pharetra nec sed nisl. Phasellus commodo magna justo, sed fringilla mauris mattis nec. Proin tellus ipsum, finibus non posuere quis, imperdiet vel neque. Fusce aliquam fermentum ipsum vitae euismod. Ut ante mi, porta ac quam eu, aliquam faucibus metus. Sed gravida tristique ipsum quis hendrerit. Integer scelerisque diam et urna bibendum pellentesque. Quisque aliquam dolor a elementum condimentum. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.",
                "Nullam cursus ligula at venenatis iaculis. Phasellus laoreet eget augue non ultrices. Aenean lacinia velit sit amet consectetur vulputate. Fusce et rhoncus nibh. Aliquam in est eu massa consequat pulvinar vel non elit. Quisque eu metus quis elit convallis venenatis faucibus sit amet justo. Phasellus mollis neque eget dui lacinia, nec sagittis augue tincidunt. Mauris vitae dui tortor. Sed interdum id nisi ac convallis. Aenean nibh massa, auctor in libero commodo, ultrices eleifend metus. Morbi finibus velit in neque egestas, eget dictum velit fringilla. Sed pharetra, lacus sed molestie iaculis, ex tellus venenatis neque, et varius ante tortor quis sem. In tortor nibh, varius ut ultricies ac, venenatis vel purus." },
                false,
                new[] {"null", "null"}, null,
                new Geopoint(new BasicGeoposition {Latitude = 51.5895, Longitude = 4.77625})));
            HistoricRoute = new Route(PointsOfInterest);
            SaveRoute.ToFile(HistoricRoute, "newroute");
        }

        public Route HistoricRoute { get; set; }
    }
}