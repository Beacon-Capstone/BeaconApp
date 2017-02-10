using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Plugin.Permissions;

using Xamarin.Forms.Maps;
using Android.Support.V4.Content;
using Android;
using Android.Support.V4.App;
using Android.Gms.Common;
using System.Threading.Tasks;
using Android.Util;

namespace BeaconApp.Droid
{
    [Activity(Label = "BeaconApp.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public sealed class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        const int RequestAccessFineLocation = 1;
        bool wasInitialized = false;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            Xamarin.FormsMaps.Init(this, bundle);

            // check for permissions in Runtime
            var permissionCheck = ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessFineLocation);
            if (!permissionCheck.Equals(Permission.Granted))
                ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.AccessFineLocation }, RequestAccessFineLocation);
            else InitApp();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            if (requestCode != RequestAccessFineLocation) return;

            // If request is cancelled, the result arrays are empty.
            if (grantResults.Length > 0 && grantResults[0] == Permission.Granted)
            {
                // permission was granted
                // Start app
                wasInitialized = true;
                InitApp();
            }
            else Finish();
        }

        public override bool OnPrepareOptionsMenu(IMenu menu)
        {
            return wasInitialized && base.OnPrepareOptionsMenu(menu);
        }

        private async void InitApp()
        {
            if (IsGooglePlayServicesInstalled())
            {
                Plugin.Geolocator.Abstractions.Position position = await GetLocation();
                if (position != null) LoadApplication(new App(position));
                else Finish();
            }
            else Toast.MakeText(this, "Google Play Service is not installed", ToastLength.Long).Show();
        }

        private bool IsGooglePlayServicesInstalled()
        {
            var googleApiAvailability = GoogleApiAvailability.Instance;
            var status = googleApiAvailability.IsGooglePlayServicesAvailable(this);
            return status == ConnectionResult.Success;
        }

        private async Task<Plugin.Geolocator.Abstractions.Position> GetLocation()
        {
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;

                return await locator.GetPositionAsync(timeoutMilliseconds: 60000).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Log.Debug("MainActivity", "Unable to get location, may need to increase timeout: " + ex);
                return null;
            }
        }
    }
}

