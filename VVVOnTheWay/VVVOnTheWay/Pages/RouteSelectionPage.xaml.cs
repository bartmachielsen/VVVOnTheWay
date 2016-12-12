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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace VVVOnTheWay
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RouteSelectionPage : Page
    {
        public RouteSelectionPage()
        {
            this.InitializeComponent();
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            RouteSelectionFrame.Navigate(typeof(LanguageSelectionPage));
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            RouteSelectionFrame.Navigate(typeof(MainPage));
            //#TODO: Make GuidePage
        }

        private void English_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Dutch_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
