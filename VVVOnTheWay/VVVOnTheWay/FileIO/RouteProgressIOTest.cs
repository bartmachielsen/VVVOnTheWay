using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVVOnTheWay.FileIO
{
    class RouteProgressIOTest
    {
        public Route.Route RetrievedRoute1 { get; set; }
        public Route.Route RetrievedRoute2 { get; set; }

        public RouteProgressIOTest()
        {
            TestMethod();
        }

        public async void TestMethod()
        {
            if (await RouteProgressIO.CheckIfLastSavedRouteExists())
            {
                RetrievedRoute1 = await RouteProgressIO.LoadLastSavedRouteFromFile();
                Debug.WriteLine($"RetrievedRoute1 loaded");
            }
            RouteProgressIO.SaveRouteProgressToFile(await FullRouteIO.LoadRouteAsync(FullRouteIO.BlindWallsFileName));
            if(await RouteProgressIO.CheckIfLastSavedRouteExists())
            {
                RetrievedRoute2 = await RouteProgressIO.LoadLastSavedRouteFromFile();
                Debug.WriteLine($"RetrievedRoute2 loaded");
            }
        }
    }
}
