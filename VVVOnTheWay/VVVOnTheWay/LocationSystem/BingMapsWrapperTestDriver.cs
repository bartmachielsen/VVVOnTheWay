using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationSystem
{
    static class BingMapsWrapperTestDriver
    {
        public static async void TestBingMapsWrapper()
        {
            System.Diagnostics.Debug.WriteLine("Getting current location to check!");
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

            
        }
    }
}
