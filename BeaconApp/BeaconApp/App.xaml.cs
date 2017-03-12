using BeaconApp.Pages;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeaconApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            if (Device.OS == TargetPlatform.Android)
            {
                // if this is an Android device, set the MainPage to a new SplashPage
                Debug.WriteLine("Here 2");
                //MainPage = new SplashPage();
                MainPage = new LoginPage();
            } else
            {
                var navPage = new NavigationPage(
                    new MapPage()
                    {
                        Title = "Map",
                    });

                navPage.BarTextColor = Color.White;

                // set the MainPage of the app to the navPage
                MainPage = navPage;
            }
        }
    }
}
