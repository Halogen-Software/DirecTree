using System;
using Android.App;
using Android.OS;
using MvvmCross.Droid.Support.V7.AppCompat;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using MvvmCross.Droid.Views;

namespace DirecTree.Android.Views
{
    [Activity(Label = "DirecTree", Icon = "@drawable/Icon2", Theme = "@style/MyTheme.MainTheme", NoHistory = true)]
    public class LocationSyncView : MvxActivity
    {
        private bool _hasGpsEnabled = false;
        public static double _latitude;
        public static double _longitude;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.LocationSyncView);
            GetPosition();
        }

        private async void GetPosition()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 15;
            Position position = new Position();
            try
            {
                position = await locator.GetPositionAsync(10000);
                _latitude = position.Latitude;
                _longitude = position.Longitude;
                _hasGpsEnabled = true;
            }
            catch (Exception e)
            {
                _hasGpsEnabled = false;
            }

            if (!_hasGpsEnabled)
            {
                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("GPS Offline");
                alert.SetMessage("Please ensure GPS has been turned on and try again.");
                alert.SetPositiveButton("Try Again", (senderAlert, args) =>
                {
                    _hasGpsEnabled = false;
                    GetPosition();
                    OnBackPressed();
                });
                alert.SetNegativeButton("Not Now", (senderAlert, args) =>
                {
                    _hasGpsEnabled = false;
                    OnBackPressed();
                });

                Dialog dialog = alert.Create();
                dialog.Show();
            }
            else
            {
                OnBackPressed();
            }
        }
    }
}