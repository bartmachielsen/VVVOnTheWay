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
        private JsonSerializerSettings settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All };

        public FullRouteIOTest()
        {
            TestMethod(new RouteTest().PointsOfInterest);
        }

        public void TestMethod(List<Point> totest)
        {
            string s = JsonConvert.SerializeObject(totest, settings);
            WriteJson(s);
            ReadJson();
        }

        public async void WriteJson(string s)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile sampleFile = await localFolder.CreateFileAsync($"jsontest.json", CreationCollisionOption.ReplaceExisting);
            await Windows.Storage.FileIO.WriteTextAsync(sampleFile, s);
        }

        public async void ReadJson()
        {
            try
            {
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                StorageFile sampleFile = await localFolder.GetFileAsync("jsontest.json");
                string json = await Windows.Storage.FileIO.ReadTextAsync(sampleFile);
                List<Point> list = JsonConvert.DeserializeObject<List<Point>>(json, settings);
            } 
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }
    }
}
