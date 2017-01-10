// Created by Bart Machielsen

#region

using System;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using VVVOnTheWay.Pages;

#endregion

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace VVVOnTheWay
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PasswordPage : Page
    {
        private Route.Route _selectedRoute;
        public PasswordPage()
        {
            InitializeComponent();
        }

        private async void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            var g = new GuidePage();
            await g.ShowAsync();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            ValidatePassword(PasswordBox.Password);
        }

        private void ValidatePassword(string password)
        {
            if (password == $"{Settings.Password}")
                PasswordCorrect();
            else
                PasswordFalse();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _selectedRoute = e.Parameter as Route.Route;

        }

        private void PasswordCorrect()
        {
            PasswordFrame.Navigate(typeof(LanguageSelectionPage), _selectedRoute);
        }

        private void PasswordFalse()
        {
            PasswordWrongAnimation.Begin();
        }

        private void PasswordBox_OnKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
                LoginButton_Click(sender, e);
        }
    }
}