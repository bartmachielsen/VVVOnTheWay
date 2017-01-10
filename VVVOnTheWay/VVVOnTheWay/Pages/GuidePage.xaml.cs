// Created by Bart Machielsen

#region

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

#endregion

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace VVVOnTheWay.Pages
{
    public sealed partial class GuidePage : ContentDialog
    {
        public GuidePage()
        {
            InitializeComponent();
            if (Settings.Language == VVVOnTheWay.Language.ENGLISH)
                GuideText.Text = "Password page: \nHere you fill in the password.\n\n" +
                                 "Route selection page: \nHere you choose which route will be walk.\n\n" +
                                 "Language selection page: \nHere you choose which language you want to use.\n\n" +
                                 "Map page: \nHere you can see the route you are walking, the route you still have to walk is blue and the route you have already walked " +
                                 "is green. The tourist attractions are shown as a small bulb and the color is blue if you still have to visit one and green if " +
                                 "you have already been there. The distance and time to the next attraction are in the top right of the screen. With the button in the bottom " +
                                 "left you can go to the settings page.\n\n" +
                                 "Settings page: \nHere you can change the language the application is currently running on." +
                                 "Information page: \nHere you can see information about and pictures from the point of interest.";
            else
                GuideText.Text = "Wachtwoord pagina: \nHier kunt u het wachtwoord invullen.\n\n" +
                                 "Selecteer route pagina: \nHier kunt u kiezen welke route gelopen gaat worden.\n\n" +
                                 "Selecteer taal pagina: \nHier kunt u kiezen welke taal u wil gebruiken\n\n" +
                                 "Kaart pagina: \nHier kunt u de route zien die u aan het lopen bent, de route die u nog moet lopen is blauw en de route die u al gelopen " +
                                 "heeft is groen. De bezienswaardigheden zijn afgebeeld als kleine belletjes en de kleur is blauw wanneer u het punt nog steeds moet bezoeken " +
                                 "en groen wanneer u er al bent geweest. De afstand en tijd naar het volgende punt zijn in de rechterbovenhoek te zien. Met de knop in de hoek " +
                                 "linksonder gaat u naar de instellingen.\n\n" +
                                 "instellingen: \nHier kunt u de taal veranderen waar de applicatie nu op draait." +
                                 "Informatie pagina: \nHier kunt u de informatie over en de afbeeldingen van de bezienswaardigheid zien.";
            BackTextBlock.Text = Settings.Language == VVVOnTheWay.Language.ENGLISH ? "Back" : "Terug";
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }
    }
}