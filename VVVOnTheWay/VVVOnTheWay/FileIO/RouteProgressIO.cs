// Created by Bart Machielsen

#region

using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Newtonsoft.Json;

#endregion

namespace VVVOnTheWay.FileIO
{
    /// <summary>
    ///     Saves and loads the last route with user progress to and from a file
    /// </summary>
    internal static class RouteProgressIO
    {
        /// <summary>
        ///     The filepath of the last saved route with user progresss
        /// </summary>
        public static readonly string LastSavedRouteFileName = "LastSavedRouteProgress";

        /// <summary>
        ///     Saves a route with user progress to a file
        /// </summary>
        /// <param name="routeInProgress">The Route object to save to a file</param>
        public static async void SaveRouteProgressToFile(Route.Route routeInProgress)
        {
            var folder = ApplicationData.Current.LocalFolder;
            var json = JsonConvert.SerializeObject(routeInProgress,
                new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.All});
            var file = await folder.CreateFileAsync($"{LastSavedRouteFileName}.json", CreationCollisionOption.ReplaceExisting);
            await Windows.Storage.FileIO.WriteTextAsync(file, json);

        }

        /// <summary>
        ///     Checks if a route can be resumed
        /// </summary>
        /// <returns>Whether there is a saved route available to resume</returns>
        public static async Task<bool> CheckIfLastSavedRouteExists()
        {
            try
            {
                var lastSavedRouteFile =
                    await ApplicationData.Current.LocalFolder.GetFileAsync($"{LastSavedRouteFileName}.json");
                return true;
            }
            catch (FileNotFoundException)
            {
                return false;
            }
        }

        /// <summary>
        ///     Loads the last saved route with user progress from a file, which can be retrieved via this class' attributes
        /// </summary>
        /// <returns>Route object of the last saved Route with user progress</returns>
        /// <remarks>
        ///     Before calling this method, use the method CheckIfLastSavedRouteExists() to prevent for a
        ///     FileNotFoundException
        /// </remarks>
        public static async Task<Route.Route> LoadLastSavedRouteFromFile()
        {
            try
            {
                var lastSavedRouteFile =
                    await ApplicationData.Current.LocalFolder.GetFileAsync($"{LastSavedRouteFileName}.json");
                var json = await Windows.Storage.FileIO.ReadTextAsync(lastSavedRouteFile);
                var retrievedRoute = JsonConvert.DeserializeObject<Route.Route>(json,
                    new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.All});
                return retrievedRoute;
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return null;
            }
        }
    }
}