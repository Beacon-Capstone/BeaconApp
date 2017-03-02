using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Plugin.Geolocator;

using Xamarin.Forms;
using Plugin.Geolocator.Abstractions;
using Xamarin.Forms.Maps;
using System.Diagnostics;

namespace BeaconApp.Pages
{
    public partial class MapPage : ContentPage
    {
        IGeolocator locator;

        public MapPage()
        {
            locator = CrossGeolocator.Current;
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await SetupMap();
        }

        async Task SetupMap()
        {
            Map.IsVisible = false;

            Plugin.Geolocator.Abstractions.Position position;
            try
            {
                position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);
            }
            catch (Exception)
            {
                return;
            }
            Map.IsVisible = true;
            Map.MoveToRegion(MapSpan.FromCenterAndRadius(
                new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude), Distance.FromMiles(0.3)));
        }
    }
}
