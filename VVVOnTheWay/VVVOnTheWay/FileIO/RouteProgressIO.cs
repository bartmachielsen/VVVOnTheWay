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
    /// Saves and loads the last route with user progress to and from a file
    /// </summary>
    static class RouteProgressIO
    {
        /// <summary>
        /// The filepath of the last saved route with user progresss
        /// </summary>
        public readonly static string LastSavedRouteFileName = "LastSavedRouteProgress";

        /// <summary>
        /// Saves a route with user progress to a file
        /// </summary>
        /// <param name="routeInProgress">The Route object to save to a file</param>
        public static async void SaveRouteProgressToFile(Route.Route routeInProgress)
        {
            StorageFolder folder = ApplicationData.Current.LocalFolder;
            string json = JsonConvert.SerializeObject(routeInProgress, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
            await folder.CreateFileAsync($"{LastSavedRouteFileName}.json", CreationCollisionOption.ReplaceExisting);
        }

        /// <summary>
        /// Checks if a route can be resumed
        /// </summary>
        /// <returns>Whether there is a saved route available to resume</returns>
        public static async Task<bool> CheckIfLastSavedRouteExists()
        {
            try
            {
                StorageFile lastSavedRouteFile = await ApplicationData.Current.LocalFolder.GetFileAsync($"{LastSavedRouteFileName}.json");
                return true;
            }
            catch (FileNotFoundException)
            {
                return false;
            }
        }

        /// <summary>
        /// Loads the last saved route with user progress from a file, which can be retrieved via this class' attributes
        /// </summary>
        /// <returns>Route object of the last saved Route with user progress</returns>
        /// <remarks>Before calling this method, use the method CheckIfLastSavedRouteExists() to prevent for a FileNotFoundException</remarks>
        public static async Task<Route.Route> LoadLastSavedRouteFromFile()
        {
            try
            {
                StorageFile lastSavedRouteFile = await ApplicationData.Current.LocalFolder.GetFileAsync($"{LastSavedRouteFileName}.json");
                string json = await Windows.Storage.FileIO.ReadTextAsync(lastSavedRouteFile);
                Route.Route retrievedRoute = JsonConvert.DeserializeObject<Route.Route>(json, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                return retrievedRoute;
            }
            catch
            {
                return null;
            }
        }
    }
}
