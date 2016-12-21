// Created by Bart Machielsen

#region

using System.Diagnostics;
using System.Threading.Tasks;

#endregion

namespace VVVOnTheWay.FileIO
{
    /// <summary>
    ///     Unit Test class for class FullRouteIO
    /// </summary>
    internal class FullRouteIOTest
    {
        public FullRouteIOTest()
        {
            TestMethod();
        }

        public Route.Route RetrievedRoute { get; set; }

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