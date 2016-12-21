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

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace VVVOnTheWay.Pages
{
    public sealed partial class SettingsPage : ContentDialog
    {
        public SettingsPage()
        {
            this.InitializeComponent();
            LanguageSwitchButton.Content = Settings.Language == VVVOnTheWay.Language.ENGLISH ? "Switch language" : "Verander taal";
            BackTextBlock.Text = Settings.Language == VVVOnTheWay.Language.ENGLISH ? "Back" : "Terug";
            CurrentLanguageText.Text = Settings.Language == VVVOnTheWay.Language.ENGLISH ? "Current language: English" : "Huidige taal: Nederlands";
            
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void LanguageSwitchButton_Click(object sender, RoutedEventArgs e)
        {
            Settings.Language = Settings.Language == VVVOnTheWay.Language.DUTCH ? VVVOnTheWay.Language.ENGLISH : VVVOnTheWay.Language.DUTCH;
            if (Settings.Language == VVVOnTheWay.Language.ENGLISH)
            {
                LanguageSwitchButton.Content = "Switch language";
                BackTextBlock.Text = "Back";
                CurrentLanguageText.Text = "Current language: English";
                
            }
            else
            {
                LanguageSwitchButton.Content = "Verander taal";
                BackTextBlock.Text = "Terug";
                CurrentLanguageText.Text = "Huidige taal: Nederlands";
            }
        }
    }
}
