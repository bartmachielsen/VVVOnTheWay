using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using VVVOnTheWay.FileIO;
using VVVOnTheWay.NotificationSystem;
using VVVOnTheWay.Pages;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace VVVOnTheWay
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PasswordPage : Page
    {
        public PasswordPage()
        {
            this.InitializeComponent();
        }

        private async void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            //NotificationSystemTestDriver.TestRun();
            //var g = new GuidePage();
            //await g.ShowAsync();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO Remove Test password
            if (PasswordBox.Password == ""+Settings.Password || PasswordBox.Password == "")
            {
                PasswordFrame.Navigate(typeof(RouteSelectionPage));
            }
            else
            {
                PasswordError.Opacity = 1.0;
                PasswordWrongAnimation.Begin();
            }
        }
    }
}
