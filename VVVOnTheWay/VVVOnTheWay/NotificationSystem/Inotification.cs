// Created by Bart Machielsen

namespace VVVOnTheWay.NotificationSystem
{
    /// <summary>
    ///     The interface every notification implements
    /// </summary>
    internal interface INotification
    {
        /// <summary>
        ///     The title of the notification
        /// </summary>
        string Title { get; }

        string Description { get; }
    }
}