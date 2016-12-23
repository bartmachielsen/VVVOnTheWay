// Created by Bart Machielsen

#region

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Newtonsoft.Json;
using VVVOnTheWay.Route;

#endregion

namespace VVVOnTheWay.FileIO
{
    internal class BlindwallsRetriever
    {
        private readonly HttpClient http;

        public BlindwallsRetriever()
        {
            http = new HttpClient();
        }

        public async Task<Route.Route> GetJson()
        {
            var poiList = new List<Point>();
            var url = new Uri("http://blindwalls.gallery/?json=get_posts");
            var response = await http.GetStringAsync(url);

            dynamic data = JsonConvert.DeserializeObject(response);
            foreach (var post in data.posts)
            {
                string title = post.title.ToString();
                string slug = post.slug.ToString();
                var customFields = post.custom_fields;
                string location = customFields.blokken_2_kaart_rechts[0].ToString();
                string description;
                try
                {
                    description = customFields.blokken_3_tekstblok[0].ToString();
                }
                catch (Exception)
                {
                    description = "MISSING";
                }

                location = Regex.Replace(location, "[:;]", "");
                var stringarray = Regex.Split(location, "\"");
                var latitude = stringarray[7];
                var longitude = stringarray[11];
                poiList.Add(new PointOfInterest(new[] {title, title}, new[] {description, description}, false,
                    new[] {"null", "null"}, @"" + slug + ".jpg",
                    new Geopoint(new BasicGeoposition
                    {
                        Latitude = Convert.ToDouble(latitude),
                        Longitude = Convert.ToDouble(longitude)
                    })));
            }
            return new Route.Route(poiList);
        }
    }
}