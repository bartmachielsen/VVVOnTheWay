using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVVOnTheWay.NotificationSystem
{
    /// <summary>
    /// The function of this class is create tasks to send notifications to the device.
    /// </summary>
    static class NotificationSystem
    {
        

        /// <summary>
        /// Creates a task to send a push notification
        /// </summary>
        /// <param name="notification"> A notification implementing the <see cref="INotification"/> interface.</param>
        /// <returns> A task to send a push notification. </returns>
        //TODO add a way to send the vibration notifiction
        public static Task SendPushNotificationAsync(INotification notification)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a task to send a sound notification.
        /// </summary>
        /// <returns> The task to send a sound notification. </returns>
        //TODO add a way to send the vibration notifiction
        public static Task SendSoundNotificationAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a task to send a sound notification.
        /// </summary>
        /// <returns> The task to send a vibration notification. </returns>
        //TODO add a way to send the vibration notifiction
        public static Task SendVibrationNotificationAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a task to send a push notification
        /// </summary>
        /// <param name="notification"> A notification implementing the <see cref="INotification"/> interface.</param>
        /// <returns> A task to send a pop up notification. </returns>
        //TODO add a way to send the pop up notifiction
        public static Task SendPopUpNotificationAsync(INotification notification)
        {
            throw new NotImplementedException();
        }
    }
}
