// Created by Bart Machielsen

#region

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.Phone.Devices.Notification;
using Windows.UI.Notifications;
using Windows.UI.Popups;
using Microsoft.Toolkit.Uwp.Notifications;

#endregion

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
        public static void SenToastificationAsync(INotification notification)
        {
            ToastNotificationManager.CreateToastNotifier().Show(CreateCompleteToastNotification(notification));
        }

        /// <summary>
        ///     Creates a task to send a sound notification.
        /// </summary>
        /// <returns> The task to send a vibration notification. </returns>
        public static void SendVibrationNotificationAsync()
        {
            try
            {
                VibrationDevice.GetDefault().Vibrate(TimeSpan.FromSeconds(5));
            }
            catch (Exception e)
            {
                Debug.WriteLine(
                    "BRRRRRRRRRRRRRRRRRRRRRRRRRRRR BRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR BRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR");
            }
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
        /// </summary>
        /// <param name="n"> The notification on which the toast is based. </param>
        /// <returns>The toast notification.</returns>
        private static ToastNotification CreateCompleteToastNotification(INotification n)
        {
            var preGeneric = new ToastBindingGeneric();

            if (!string.IsNullOrEmpty(n.Title))
                preGeneric.Children.Add(new AdaptiveText
                {
                    Text = n.Title
                });

            if (!string.IsNullOrEmpty(n.Description))
                preGeneric.Children.Add(new AdaptiveText
                {
                    Text = n.Description
                });

            if (n.GetType() == typeof(PoiNotification))
            {
                var poi = (PoiNotification) n;
                if (!string.IsNullOrEmpty(poi.ImagePath))
                    preGeneric.Children.Add(new AdaptiveImage
                    {
                        Source = poi.ImagePath
                    });
            }

            return new ToastNotification(new ToastContent
            {
                Visual = new ToastVisual {BindingGeneric = preGeneric},
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
                },
                Audio = new ToastAudio
                {
                    Src = new Uri("ms-winsoundevent:Notification.Reminder")
                },
                Duration = ToastDuration.Short
            }.GetXml());
        }
    }
}