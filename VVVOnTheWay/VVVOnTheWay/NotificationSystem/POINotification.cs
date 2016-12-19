using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace VVVOnTheWay.NotificationSystem
{
    /// <summary>
    /// A implementation of the INotification interface for specific use with the PointOfInterest class
    /// </summary>
    public class PoiNotification : INotification
    {
        /// <summary>
        /// The following property's are in order (from top to botton):
        /// Title: the title of the notification
        /// Audiopath: A filepath leading to the location of the audio file to be used in this notification.
        /// Image: The image this notification should display.
        /// Description: A description to be used with this notification.
        /// </summary>
        public string Title { get; }
        public string ImagePath { get; }
        public string Description { get; }

        /// <summary>
        /// Creates a Poi notification
        /// </summary>
        /// <param name="title">The name of the notification</param>
        /// <param name="imagePath">The path to the image file that needs to be shown</param>
        /// <param name="description">The description of the POI</param>
        public PoiNotification(string title, string imagePath, string description)
        {
            Title = title;
            if (File.Exists(imagePath)) { ImagePath = imagePath; }
            Description = description;
        }
    }
}
