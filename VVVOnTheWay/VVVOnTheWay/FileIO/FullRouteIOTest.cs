using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVVOnTheWay.Route;
using Windows.Storage;

namespace VVVOnTheWay.FileIO
{
    /// <summary>
    /// Unit Test class for class FullRouteIO
    /// </summary>
    class FullRouteIOTest
    {
        public Route.Route RetrievedRoute { get; set; }

        public FullRouteIOTest()
        {
            TestMethod();
        }

        public async void TestMethod()
        {
            RetrievedRoute = await TestRoute(FullRouteIO.BlindWallsFileName);
            Debug.WriteLine("Retrieved BlindWallsRoute");
            RetrievedRoute = await TestRoute(FullRouteIO.HistoricalKilometerFileName);
            Debug.WriteLine("Retrieved HistoricalKilometerRoute");
        }

        public async Task<Route.Route> TestRoute(string routename)
        {
            return await FullRouteIO.LoadRouteAsync(routename);
        }

    }
}
