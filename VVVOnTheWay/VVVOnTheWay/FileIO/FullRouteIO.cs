using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using VVVOnTheWay.Route;

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
        /// Creates a new Blind Walls or Historical Kilometer Route
        /// </summary>
        /// <param name="routeFileName">Available via this class its attributes</param>
        /// <returns>The requested Route via the routeFileName</returns>
        public static async Task<Route.Route> LoadRouteAsync(string routeFileName)
        {
            StorageFolder datafolder = ApplicationData.Current.LocalFolder;
            StorageFile routeFile;
            try
            {
                routeFile = await datafolder.GetFileAsync($"{routeFileName}.json");
            }
            catch (FileNotFoundException)
            {

                return await LoadRouteFromAssetsAsync(routeFileName);
            }
            string json = await Windows.Storage.FileIO.ReadTextAsync(routeFile);
            if (json == "") return await LoadRouteFromAssetsAsync(routeFileName);
            Route.Route retrievedRoute = JsonConvert.DeserializeObject<Route.Route>(json, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
            return retrievedRoute;
        }

        private static async Task<Route.Route> LoadRouteFromAssetsAsync(string routeFileName)
        {
            StorageFolder datafolder = ApplicationData.Current.LocalFolder;
            StorageFile routeFile = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync($@"Assets\{routeFileName}.json");
            await routeFile.CopyAsync(datafolder, $"{routeFileName}.json", NameCollisionOption.ReplaceExisting);
            string json = await Windows.Storage.FileIO.ReadTextAsync(routeFile);

            Route.Route retrievedRoute = JsonConvert.DeserializeObject<Route.Route>(json, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
            return retrievedRoute;
        }

    }
}
