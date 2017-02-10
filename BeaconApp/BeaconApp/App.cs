using BeaconApp.Pages;
using Plugin.Geolocator;

using Xamarin.Forms;
using Plugin.Geolocator.Abstractions;

namespace BeaconApp
{
    public class App : Application
    {
        public App(Position position)
        {
            // The root page of your application
            MainPage = new MapPage(position);
        }
    }
}
