using Plugin.Geolocator;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace BeaconApp.Pages
{
    public class MapPage : ContentPage
    {
        View mapView;
        Map map;

        public MapPage()
        {
            map = new Map()
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            mapView = map;

            this.Content = new StackLayout
            {
                Children = { mapView }
            };
        }
    }
}
