using System;
using System.Threading.Tasks;
using Windows.Phone.Devices.Notification;
using Windows.UI.Notifications;
using Windows.UI.Popups;
using Microsoft.Toolkit.Uwp.Notifications;

namespace VVVOnTheWay.NotificationSystem
{
    /// <summary>
    ///     The function of this class is create tasks to send notifications to the device.
    /// </summary>
    internal static class NotificationSystem
    {
        /// <summary>
        ///     Creates a task to send a push notification. In windows phone, this type of notification that is in the top bar of
        ///     the screen is called
        ///     a toast (yes, that is spelled correctly).
        /// </summary>
        /// <param name="notification"> A notification implementing the <see cref="INotification" /> interface.</param>
        /// <returns> A task to send a push notification. </returns>
        public static async Task SendSystemNotificationAsync(INotification notification)
        {
            ToastNotificationManager.CreateToastNotifier().Show(CreateToastNofitication(notification));
        }


        /// <summary>
        ///     Creates a task to send a sound notification.
        /// </summary>
        /// <returns> The task to send a sound notification. </returns>
        //TODO add a way to send the sound notifiction. This will probably become toasts with sound
        public static async Task SendSoundNotificationAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Creates a task to send a sound notification.
        /// </summary>
        /// <returns> The task to send a vibration notification. </returns>
        //TODO add a way to send the vibration notifiction.
        public static async Task SendVibrationNotificationAsync()
        {
            VibrationDevice.GetDefault().Vibrate(TimeSpan.FromSeconds(2));
        }

        /// <summary>
        ///     Creates a task to send a push notification
        /// </summary>
        /// <param name="notification"> A notification implementing the <see cref="INotification" /> interface.</param>
        /// <returns> A task to send a pop up notification. </returns>
        public static async Task SendPopUpNotificationAsync(Notification notification)
        {
            await new MessageDialog(notification.Description, notification.Title).ShowAsync();
        }

        /// <summary>
        ///     Creates a toast notification displaying text
        /// </summary>
        /// <param name="n">the notification that should be displayed</param>
        /// <returns> a toast notification based on the notification provided</returns>
        private static ToastNotification CreateToastNofitication(INotification n)
        {
            var generic = new ToastBindingGeneric
            {
                Children =
                {
                    new AdaptiveText
                    {
                        Text = n.Title
                    },
                    new AdaptiveText
                    {
                        Text = n.Description
                    }
                }
            };
            if (n.GetType() == typeof(PoiNotification))
                generic.Children.Add(new AdaptiveImage
                {
                    Source = ((PoiNotification) n).ImagePath
                });
            return new ToastNotification(new ToastContent
            {
                Visual = new ToastVisual {BindingGeneric = generic},
                Actions = new ToastActionsCustom
                {
                    Buttons =
                    {
                        new ToastButton("Pause", "pause")
                        {
                            ActivationType = ToastActivationType.Background
                        },
                        new ToastButton("Close", "close")
                        {
                            ActivationType = ToastActivationType.Background
                        }
                    }
                }
            }.GetXml());
        }
    }
}