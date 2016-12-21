// Created by Bart Machielsen

#region

using System;
using System.IO;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;
using Newtonsoft.Json;

#endregion

namespace VVVOnTheWay.FileIO
{
    /// <summary>
    ///     Retrieves and distributes the information about RoutePoints of routes
    /// </summary>
    internal static class FullRouteIO
    {
        /// <summary>
        ///     The filepath of the Blind Walls route file
        /// </summary>
        public static readonly string BlindWallsFileName = "BlindwallsRoute";

        /// <summary>
        ///     The filepath of the Historical Kilometer route file
        /// </summary>
        public static readonly string HistoricalKilometerFileName = "HistoricalKilometerRoute";

        /// <summary>
        ///     Creates a new Blind Walls or Historical Kilometer Route
        /// </summary>
        /// <param name="routeFileName">Available via this class its attributes</param>
        /// <returns>The requested Route via the routeFileName</returns>
        public static async Task<Route.Route> LoadRouteAsync(string routeFileName)
        {
            var datafolder = ApplicationData.Current.LocalFolder;
            StorageFile routeFile;
            try
            {
                routeFile = await datafolder.GetFileAsync($"{routeFileName}.json");
            }
            catch (FileNotFoundException)
            {
                return await loadRouteFromAssetsAsync(routeFileName);
            }
            var json = await Windows.Storage.FileIO.ReadTextAsync(routeFile);
            if (json == "") return await loadRouteFromAssetsAsync(routeFileName);
            var retrievedRoute = JsonConvert.DeserializeObject<Route.Route>(json,
                new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.All});
            return retrievedRoute;
        }

        private static async Task<Route.Route> loadRouteFromAssetsAsync(string routeFileName)
        {
            var datafolder = ApplicationData.Current.LocalFolder;
            var routeFile = await Package.Current.InstalledLocation.GetFileAsync($@"Assets\{routeFileName}.json");
            await routeFile.CopyAsync(datafolder, $"{routeFileName}.json", NameCollisionOption.ReplaceExisting);
            var json = await Windows.Storage.FileIO.ReadTextAsync(routeFile);

            var retrievedRoute = JsonConvert.DeserializeObject<Route.Route>(json,
                new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.All});
            return retrievedRoute;
        }
    }
}