using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Storage;
using Newtonsoft.Json;

namespace VVVOnTheWay.Route.Storage
{
    class SaveRoute
    {

        public static async void ToFile(Route route, string filename)
        {
            var folder = ApplicationData.Current.LocalFolder;
            var json = JsonConvert.SerializeObject(route,
                new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
            var file = await folder.CreateFileAsync($"{filename}.json", CreationCollisionOption.ReplaceExisting);
            await Windows.Storage.FileIO.WriteTextAsync(file, json);
        }
    }
}
