// Created by Bart Machielsen

#region

using Windows.Devices.Geolocation;
using Newtonsoft.Json;
using VVVOnTheWay.NotificationSystem;

#endregion

namespace VVVOnTheWay.Route
{
    public class Point
    {
        //This constructor is needed for JSON
        public Point()
        {
        }

        public Point(Geopoint location)
        {
            jsonPosition = new[] {location.Position.Latitude, location.Position.Longitude};
            Location = location;
        }

        /// <summary>
        ///     The Geoposition from the POI's location.
        /// </summary>
        [JsonIgnore]
        public Geopoint Location
        {
            get { return new Geopoint(new BasicGeoposition {Latitude = jsonPosition[0], Longitude = jsonPosition[1]}); }
            set { jsonPosition = new[] {Location.Position.Latitude, Location.Position.Longitude}; }
        }

        public double[] jsonPosition { get; set; }

        /// <summary>
        ///     Whether the POI is visited or not.
        /// </summary>
        public bool IsVisited { get; set; }
    }

    /// <summary>
    ///     - Point on the route with data about this point.
    ///     - Title, Description, Audiofile, Imagefile and Location.
    ///     - If the point has been visited or not.
    ///     - Get a notification with the information.
    /// </summary>
    public class PointOfInterest : Point
    {
        //JSON loves this
        public PointOfInterest()
        {
        }


        /// <summary>
        ///     Default constructor.
        /// </summary>
        /// <param name="title">sets <seealso cref="Title" /></param>
        /// <param name="description">sets <seealso cref="Description" /></param>
        /// <param name="isVisited">sets <seealso cref="IsVisited" /></param>
        /// <param name="audioPath">sets <seealso cref="AudioPath" /></param>
        /// <param name="imagePath">sets <seealso cref="ImagePath" /></param>
        /// <param name="location">sets <seealso cref="Point.Location" /></param>
        public PointOfInterest(string[] title, string[] description, bool isVisited, string[] audioPath,
            string imagePath, Geopoint location) : base(location)
        {
            Title = title;
            Description = description;
            IsVisited = isVisited;
            AudioPath = audioPath;
            ImagePath = imagePath;
        }

        /// <summary>
        ///     Title of the POI in 2 language's.
        /// </summary>
        public string[] Title { get; set; }

        /// <summary>
        ///     Description of the POI in 2 language's.
        /// </summary>
        public string[] Description { get; set; }

        /// <summary>
        ///     The path to get the audio file associated with the POI in both languages.
        /// </summary>
        public string[] AudioPath { get; set; }

        /// <summary>
        ///     The path to get the image file associated with the POI.
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        ///     Get the notification with all the information about this POI.
        /// </summary>
        /// <returns>A Point Of Interest notification for this point.</returns>
        public PoiNotification GetNotification()
        {
            return new PoiNotification(Title[(int) Settings.Language], ImagePath, Description[(int) Settings.Language]);
        }
    }
}