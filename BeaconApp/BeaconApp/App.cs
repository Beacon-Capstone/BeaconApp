using BeaconApp.Pages;
using Plugin.Geolocator;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace BeaconApp
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            MainPage = new MapPage();
        }
    }
}
