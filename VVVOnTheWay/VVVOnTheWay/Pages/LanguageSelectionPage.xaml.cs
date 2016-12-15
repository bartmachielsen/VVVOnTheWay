using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using VVVOnTheWay.NotificationSystem;
using VVVOnTheWay.Pages;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace VVVOnTheWay
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LanguageSelectionPage : Page
    {
        public LanguageSelectionPage()
        {
            this.InitializeComponent();
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            if (DutchButton.BorderBrush == new SolidColorBrush(Colors.Black))
            {
                Settings.setLanguageDutch();
            }
            else
            {
                Settings.setLanguageEnglish();
            }
            LanguageSelectionFrame.Navigate(typeof(MapPage));
        }

        private async void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            NotificationSystemTestDriver.TestRun();
            //var g = new GuidePage();
            //await g.ShowAsync();
        }

        private void EnglishButton_Click(object sender, RoutedEventArgs e)
        {
            EnglishButton.BorderBrush = new SolidColorBrush(Colors.Black);
            EnglishButton.BorderThickness = new Thickness(3);
            DutchButton.BorderBrush = new SolidColorBrush(Colors.Transparent);
            DutchButton.BorderThickness = new Thickness(1);
        }

        private void DutchButton_Click(object sender, RoutedEventArgs e)
        {
            DutchButton.BorderBrush = new SolidColorBrush(Colors.Black);
            DutchButton.BorderThickness = new Thickness(3);
            EnglishButton.BorderBrush = new SolidColorBrush(Colors.Transparent);
            EnglishButton.BorderThickness = new Thickness(1);
        }

        
    }
}
