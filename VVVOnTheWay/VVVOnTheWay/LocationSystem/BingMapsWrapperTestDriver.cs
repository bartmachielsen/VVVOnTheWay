using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using VVVOnTheWay.Route;

namespace LocationSystem
{
    static class BingMapsWrapperTestDriver
    {
        public static async void TestBingMapsWrapper()
        {
            System.Diagnostics.Debug.WriteLine("\n\nClearing geofences! --> done");
            LocationSystem.BingMapsWrapper.ClearGeofences();
            System.Diagnostics.Debug.WriteLine("\n\nGetting current location to check!");
            var location = await LocationSystem.BingMapsWrapper.GetCurrentPosition();
            System.Diagnostics.Debug.WriteLine($"Current location is\n" +
                                               $"coordinate data:\n" +
                                               $"latitude:{location.Coordinate.Point.Position.Latitude}\n" +
                                               $"Longitude:{location.Coordinate.Point.Position.Longitude}\n" +
                                               $"Altitude:{location.Coordinate.Point.Position.Altitude}\n" +
                                               $"Speed:{location.Coordinate.Speed}\n" +
                                               $"Accuracy:{location.Coordinate.Accuracy}\n" +
                                               $"Heading:{location.Coordinate.Heading}\n" +
                                               $"Timestamp{location.Coordinate.Timestamp}");

            if(location.CivicAddress != null)
                System.Diagnostics.Debug.WriteLine($"city: {location.CivicAddress.City}\n" +
                                               $"postalcode: {location.CivicAddress.PostalCode}\n" +
                                               $"country:{location.CivicAddress.Country}\n" +
                                               $"state:{location.CivicAddress.State}\n");


            Geopoint startPoint = new Geopoint(new BasicGeoposition() {Latitude = 51.5855821, Longitude = 4.789675699999975});
            Geopoint endPoint = new Geopoint(new BasicGeoposition() {Latitude = 51.5832688, Longitude = 4.797166000000061});

            if ((await BingMapsWrapper.GetRouteTo(startPoint, endPoint)) != null)
            {
                System.Diagnostics.Debug.WriteLine($"\n\nGetting route between points:\n" +
                                                   $"Route possible: {(await BingMapsWrapper.GetRouteTo(startPoint, endPoint)) != null}" +
                                                   $"Start: {startPoint.Position.Latitude}, {startPoint.Position.Longitude}" +
                                                   $"End: {endPoint.Position.Latitude}, {endPoint.Position.Longitude}" +
                                                   $"Distance between points when walking: {await BingMapsWrapper.GetDistanceTo(startPoint, endPoint)}");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine($"\n\nGetting route between points:\n" +
                                                   $"Route possible: {(await BingMapsWrapper.GetRouteTo(startPoint, endPoint)) != null}" +
                                                   $"Start: {startPoint.Position.Latitude}, {startPoint.Position.Longitude}" +
                                                   $"End: {endPoint.Position.Latitude}, {endPoint.Position.Longitude}" +
                                                   $"Distance between points when walking: NOT POSSIBLE");
            }

            bool changed = false;
            System.Diagnostics.Debug.WriteLine("\n\nWaiting for one location change:");
            BingMapsWrapper.NotifyOnLocationUpdate((async geoposition =>
            {
                if (!changed)
                {
                    changed = true;
                    System.Diagnostics.Debug.WriteLine($"Location Changed! --> {geoposition.ToString()}");
                }
            }));
            while (!changed)
            {
                
            }
            System.Diagnostics.Debug.WriteLine("\n\nWaiting for geofence response:" +
                                               $"\nWalk to: {endPoint.Position.Longitude}, {endPoint.Position.Latitude}");
            Point targetpoint = new Point(endPoint);
            changed = false;
            BingMapsWrapper.PointOfInterestEntered(( async point =>
            {
                System.Diagnostics.Debug.WriteLine("Reached Point!!!!");
                changed = true;
            }), targetpoint);
            while (!changed) { }
            System.Diagnostics.Debug.WriteLine("Test finished!");
        }
    }
}
