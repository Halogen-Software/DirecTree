using System;
using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Droid.Support.V7.AppCompat;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using DirecTree.Android.Views.Base;
using Android.Content;
using Android.Support.V4.Widget;
using DirecTree.Core.DevTests;
using DirecTree.Core.Models;
using DirecTree.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using DirecTree.Core.Util;

namespace DirecTree.Android.Views
{
    [Activity(Label = "DirecTree", Theme = "@style/MyTheme.MainTheme")]
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
        private FrameLayout _fragmentHolder;
        private bool hasSignedIn { get; set; } = false;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MainView);
            HomeViewModel = DataContext as MainViewModel;
            SetupBindings();

            _drawerLayout = FindViewById<DrawerLayout>(Resource.Id.leftDrawerLayout);
            _isBusyOverlay = FindViewById<LinearLayout>(Resource.Id.isBusyOverlay);
            _sideBarMenu = FindViewById<MvxListView>(Resource.Id.sideBarMenuList);
            _fragmentHolder = FindViewById<FrameLayout>(Resource.Id.fragmentHolder);
            _drawerToggle = new MvxActionBarDrawerToggle(this, _drawerLayout, Resource.String.Drawer,
                Resource.String.Drawer);
            _drawerLayout.SetDrawerListener(_drawerToggle);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(true);
            _drawerToggle.SyncState();
            SetupMap();
            _preferences = GetSharedPreferences(SettingsView.DefaultPreferences, FileCreationMode.Private);
            if (!_preferences.GetBoolean(SettingsView.RETRIEVE_LOCATION_ON_STARTUP, false))
                NavigateToLocation();
            _longitude = LocationSyncView._longitude;
            _latitude = LocationSyncView._latitude;
            _sideBarMenu.ItemClick += NavigateSideBarCommand;
        }

        private bool IsUserSignedIn()
        {
            if (!_preferences.GetString(SettingsView.SIGNED_IN_USER, string.Empty).Equals(string.Empty))
            {
                SetCurrentUser();
            }

            return !_preferences.GetString(SettingsView.SIGNED_IN_USER, string.Empty).Equals(string.Empty);
        }

        private void SetCurrentUser()
        {
            // Todo: This will change when we implement actual DB

            foreach (Vendor vendor in DevOptions.DevVendorList)
            {
                if (vendor.Username.Equals(_preferences.GetString(SettingsView.SIGNED_IN_USER, string.Empty)))
                {
                    StaticUtils.currentUser = vendor;
                }
            }
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
            ApplySignedInUser();
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

        protected override void OnResume()
        {
            base.OnResume();

        }

        private void NavigateToLocation(Position position)
        {
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

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            _drawerToggle.OnOptionsItemSelected(item);
            return base.OnOptionsItemSelected(item);
        }

        private void NavigateSideBar(int menuItem)
        {
            switch (menuItem)
            {
                case 0:
                    if(_fragmentHolder.Visibility != ViewStates.Gone)
                        _fragmentHolder.Visibility = ViewStates.Gone;
                    break;
                case 1:
                    HomeViewModel.NavigateToProfileView.Execute(null);
                    
                    break;
                case 2:
                    HomeViewModel.NavigateToSignIn.Execute(null);
                    break;
            }
        }

        private void ApplySignedInUser() {
            // ToDo: apply user properties to MainView
            // ToDo: Add user as item in the side drawer

            if (IsUserSignedIn())
            {
                Position location = new Position();
                location.Latitude = StaticUtils.currentUser.VendorLocation.GpsLatitude;
                location.Longitude = StaticUtils.currentUser.VendorLocation.GpsLongitude;

                // Centers in on the signed in persons stored location
                NavigateToLocation(location);

                // Sets title bar to name of the signed in users company
                SupportActionBar.Title = StaticUtils.currentUser.CompanyName;

                // Closes side bar
                _drawerLayout.CloseDrawer((int) GravityFlags.Left);
            }
        }

        private void SetupBindings() {
            var _signInBindingSet = this.CreateBindingSet<MainView, SignInViewModel>();
            _signInBindingSet.Apply();
        }

        protected override void OnPostResume()
        {
            base.OnPostResume();

            if (!hasSignedIn)
            {
                if (StaticUtils.currentUser != null)
                {
                    ApplySignedInUser();

                    hasSignedIn = true;
                }
            }

        }
    }
    
}