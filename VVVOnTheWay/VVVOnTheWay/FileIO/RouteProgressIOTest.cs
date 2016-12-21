// Created by Bart Machielsen

#region

using System.Diagnostics;

#endregion

namespace VVVOnTheWay.FileIO
{
    internal class RouteProgressIOTest
    {
        public RouteProgressIOTest()
        {
            TestMethod();
        }

        public Route.Route RetrievedRoute1 { get; set; }
        public Route.Route RetrievedRoute2 { get; set; }

        public async void TestMethod()
        {
            if (await RouteProgressIO.CheckIfLastSavedRouteExists())
            {
                RetrievedRoute1 = await RouteProgressIO.LoadLastSavedRouteFromFile();
                Debug.WriteLine($"RetrievedRoute1 loaded");
            }
            RouteProgressIO.SaveRouteProgressToFile(await FullRouteIO.LoadRouteAsync(FullRouteIO.BlindWallsFileName));
            if (await RouteProgressIO.CheckIfLastSavedRouteExists())
            {
                RetrievedRoute2 = await RouteProgressIO.LoadLastSavedRouteFromFile();
                Debug.WriteLine($"RetrievedRoute2 loaded");
            }
        }
    }
}