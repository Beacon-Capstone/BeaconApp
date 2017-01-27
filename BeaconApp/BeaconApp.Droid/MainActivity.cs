using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.Content;
using Android.Support.V4.App;
using Android;
using Android.Gms.Common;

namespace BeaconApp.Droid
{
    [Activity(Label = "BeaconApp.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
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
            {
                // there is no granted permission to ACCESS_FINE_LOCATION. Requesting it in runtime
                ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.AccessFineLocation }, RequestAccessFineLocation);
            }
            else
            {
                // the permission was granted in the past
                InitApp();
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            if (requestCode != RequestAccessFineLocation) return;

            // If request is cancelled, the result arrays are empty.
            if (grantResults.Length > 0 && grantResults[0] == Permission.Granted)
            {
                // permission was granted, start app
                wasInitialized = true;
                InitApp();
            }
            else
            {
                // permission denied, close app
                Finish();
            }
        }

        public override bool OnPrepareOptionsMenu(IMenu menu)
        {
            return wasInitialized && base.OnPrepareOptionsMenu(menu);
        }

        private void InitApp()
        {
            if (IsGooglePlayServicesInstalled())
            {
                LoadApplication(new App());
            }
            else
            {
                Toast.MakeText(this, "Google Play Service is not installed", ToastLength.Long).Show();
            }
        }

        private bool IsGooglePlayServicesInstalled()
        {
            var googleApiAvailability = GoogleApiAvailability.Instance;
            var status = googleApiAvailability.IsGooglePlayServicesAvailable(this);
            return status == ConnectionResult.Success;
        }
    }
}

