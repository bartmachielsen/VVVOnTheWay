using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVVOnTheWay.NotificationSystem
{
    /// <summary>
    /// The test driver for the notification system.
    /// </summary>
    static class NotificationSystemTestDriver
    {
        public static async void TestRun()
        {
            var file = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(@"Assets\Netherlands.png");
            Notification testNotification = new Notification("Test 1", "Test 1");
            PoiNotification poiNotification = new PoiNotification("Test2", file.Path, "Test2");

            Debug.WriteLine("Started the test");
            Test1(testNotification);
            Test2(testNotification);
            Test3(poiNotification);
            Debug.WriteLine("Finished the test");
        }

        public static async void Test1(Notification n)
        {
            Debug.WriteLine("First test");
            await NotificationSystem.SendPopUpNotificationAsync(n);
        }

        public static void Test2(Notification n)
        {
            Debug.WriteLine("Second test");
            NotificationSystem.SenToastificationAsync(n);
        }

        public static void Test3(PoiNotification n)
        {
            Debug.WriteLine("Third test");
            NotificationSystem.SenToastificationAsync(n);
        }
    }
}
