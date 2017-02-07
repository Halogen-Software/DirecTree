using System;
using System.Threading;
using System.Threading.Tasks;
using Android;
using Android.App;
using Android.Bluetooth;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Droid.Support.V7.AppCompat;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using DirecTree.Android.Views.Base;
using Android.Content;

namespace DirecTree.Android.Views
{
    [Activity(Label = "DirecTree", Icon = "@drawable/Icon2", Theme = "@style/MyTheme.MainTheme")]
    public class MainView : BaseView, IOnMapReadyCallback
    {
        private GoogleMap _map;
        private MvxActionBarDrawerToggle _drawerToggle;
        private DrawerLayout _drawerLayout;
        private LinearLayout _isBusyOverlay;
        private ListView _sideBarMenu;
        private bool _hasGpsEnabled = false;
        private double _longitude;
        private double _latitude;
        private ISharedPreferences _preferences;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MainView);

            var actionBar = SupportActionBar;

            _drawerLayout = FindViewById<DrawerLayout>(Resource.Id.leftDrawerLayout);
            _isBusyOverlay = FindViewById<LinearLayout>(Resource.Id.isBusyOverlay);
            _sideBarMenu = FindViewById<MvxListView>(Resource.Id.sideBarMenuList);
            _drawerToggle = new MvxActionBarDrawerToggle(this, _drawerLayout, Resource.String.Drawer,
                Resource.String.Drawer);
            _drawerLayout.SetDrawerListener(_drawerToggle);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(true);
            _drawerToggle.SyncState();
            SetupMap();
            _preferences = GetSharedPreferences(SettingsView.DefaultPreferences, 0);
            if (!_preferences.GetBoolean(SettingsView.RETRIEVE_LOCATION_ON_STARTUP, false))
                NavigateToLocation();
            _longitude = LocationSyncView._longitude;
            _latitude = LocationSyncView._latitude;
            _sideBarMenu.ItemClick += NavigateSideBarCommand;

        }

        public void NavigateSideBarCommand(object sender, AdapterView.ItemClickEventArgs e)
        {
            NavigateSideBar(e.Position);
        }

        private void SetupMap()
        {
            if (_map == null)
            {
                FragmentManager.FindFragmentById<MapFragment>(Resource.Id.googleMapsFragment).GetMapAsync(this);
            }
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            _map = googleMap;
        }

        private async void NavigateToLocation()
        {
            _isBusyOverlay.Visibility = ViewStates.Visible;
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 15;
            Position position = new Position();
            try
            {
                position = await locator.GetPositionAsync(10000);
                LocationSyncView._longitude = position.Longitude;
                LocationSyncView._latitude = position.Latitude;
                _map.MoveCamera(CameraUpdateFactory.NewLatLng(new LatLng(position.Latitude, position.Longitude)));
                _map.AnimateCamera(CameraUpdateFactory.ZoomTo(15));
                MarkerOptions currentLocationMarker = new MarkerOptions()
                    .SetPosition(new LatLng(position.Latitude, position.Longitude))
                    .SetTitle("My Location");
                _map.AddMarker(currentLocationMarker);
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
                alert.SetPositiveButton("Try Again", (senderAlert, args) => {
                    _hasGpsEnabled = false;
                    NavigateToLocation();
                });
                alert.SetNegativeButton("Not Now", (senderAlert, args) => {
                    _hasGpsEnabled = false;
                });

                Dialog dialog = alert.Create();
                dialog.Show();
            }
            _isBusyOverlay.Visibility = ViewStates.Gone;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            _drawerToggle.OnOptionsItemSelected(item);
            return base.OnOptionsItemSelected(item);
        }

        private void NavigateSideBar(int position)
        {
            switch (position)
            {
                case 0:

                    StartActivity(typeof(LocationSyncView));
                    if (!LocationSyncView._longitude.Equals(_longitude) && LocationSyncView._latitude.Equals(_latitude))
                    {
                        _map.MoveCamera(CameraUpdateFactory.NewLatLng(new LatLng(_latitude, _longitude)));
                        _map.AnimateCamera(CameraUpdateFactory.ZoomTo(15));
                        MarkerOptions currentLocationMarker = new MarkerOptions()
                            .SetPosition(new LatLng(_latitude, _longitude))
                            .SetTitle("My Location");
                        _map.AddMarker(currentLocationMarker);
                        _hasGpsEnabled = true;
                    }
                    break;
            }
        }
    }
}