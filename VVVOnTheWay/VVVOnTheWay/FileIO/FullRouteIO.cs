using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace VVVOnTheWay.FileIO
{
    /// <summary>
    /// Retrieves and distributes the information about RoutePoints of routes
    /// </summary>
    static class FullRouteIO
    {
        /// <summary>
        /// The filepath of the Blind Walls route file
        /// </summary>
        public static readonly string BlindWallsFileName = "BlindwallsRoute";

        /// <summary>
        /// The filepath of the Historical Kilometer route file
        /// </summary>
        public static readonly string HistoricalKilometerFileName = "HistoricalKilometerRoute";

        /// <summary>
        /// Loads/creates the Historical Kilometer Route, which can be retrieved as this class' attributes
        /// </summary>
        /// <returns>The Route object for the Historical Kilometer route</returns>
        public static async Task<Route.Route> LoadHistoricalKilometerRoute()
        {
            StorageFolder datafolder = ApplicationData.Current.LocalFolder;
            StorageFile historicalKilometerFile;
            try
            {
                historicalKilometerFile = await datafolder.GetFileAsync($"{HistoricalKilometerFileName}.json");
            }
            catch (FileNotFoundException)
            {
                historicalKilometerFile = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(@"Assets\HistoricalKilometerFullRoute.json");
                await historicalKilometerFile.CopyAsync(datafolder, $"{HistoricalKilometerFileName}.json", NameCollisionOption.ReplaceExisting);
            }
            string json = await Windows.Storage.FileIO.ReadTextAsync(historicalKilometerFile);
            Route.Route retrievedRoute = JsonConvert.DeserializeObject<Route.Route>(json, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
            return retrievedRoute;
        }

        /// <summary>
        /// Loads/creates the Blind Walls Route, which can be retrieved as this class' attributes
        /// </summary>
        /// <returns>The Route object for the Blind Walls route</returns>
        public static async Task<Route.Route> LoadBlindWallsRoute()
        {
            BlindwallsRetriever bwRetriever = new BlindwallsRetriever();
            var result = await bwRetriever.GetJson();
            return result;
        }

    }
}
