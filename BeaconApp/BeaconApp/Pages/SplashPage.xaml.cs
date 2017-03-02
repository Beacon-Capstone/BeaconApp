using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace BeaconApp.Pages
{
    public partial class SplashPage : ContentPage
    {
        bool _ShouldDelayForSplash = true;

        public SplashPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            Debug.WriteLine("Here");
            base.OnAppearing();

            if (_ShouldDelayForSplash) {
                // delay for a few seconds on the splash screen
                await Task.Delay(3000);

                // create a new NavigationPage, with a new AcquaintanceListPage set as the Root
                var navPage = new NavigationPage(
                    new MapPage()
                    {
                        Title = "Map",
                    });

                navPage.BarTextColor = Color.White;

                // set the MainPage of the app to the navPage
                Application.Current.MainPage = navPage;
            }
        }
    }
}
