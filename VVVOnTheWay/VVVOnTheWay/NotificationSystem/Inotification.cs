using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVVOnTheWay.NotificationSystem
{
    /// <summary>
    /// The interface every notification implements
    /// </summary>
    interface INotification
    {
        /// <summary>
        /// The title of the notification
        /// </summary>
        string Title { get; }
        string Description { get; }
    }
}
