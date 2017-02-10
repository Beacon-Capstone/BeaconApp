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

        public MapPage(Plugin.Geolocator.Abstractions.Position position)
        {
            map = new Map(
            MapSpan.FromCenterAndRadius(
                    new Position(position.Latitude, position.Longitude), Distance.FromMiles(0.3)))
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
