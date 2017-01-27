using System;
using System.Threading;
using System.Threading.Tasks;
using Android;
using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using Plugin.Geolocator;

namespace DirecTree.Android.Views
{
    [Activity(Label = "DirecTree", Icon = "@drawable/Icon2", Theme = "@style/MyTheme.MainTheme")]
    public class MainView : MvxAppCompatActivity, IOnMapReadyCallback
    {
        private GoogleMap _map;
        private MvxActionBarDrawerToggle _drawerToggle;
        private DrawerLayout _drawerLayout;
        private LinearLayout _isBusyOverlay;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MainView);
            _drawerLayout = FindViewById<DrawerLayout>(Resource.Id.leftDrawerLayout);
            _isBusyOverlay = FindViewById<LinearLayout>(Resource.Id.isBusyOverlay);
            _drawerToggle = new MvxActionBarDrawerToggle(this, _drawerLayout, Resource.String.Drawer,
                Resource.String.Drawer);
            _drawerLayout.SetDrawerListener(_drawerToggle);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(true);
            _drawerToggle.SyncState();
            SetupMap();
            NavigateToLocation();
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
            var position = await locator.GetPositionAsync(10000);
            _map.MoveCamera(CameraUpdateFactory.NewLatLng(new LatLng(position.Latitude, position.Longitude)));
            _map.AnimateCamera(CameraUpdateFactory.ZoomTo(15));
            MarkerOptions currentLocationMarker = new MarkerOptions()
                .SetPosition(new LatLng(position.Latitude, position.Longitude))
                .SetTitle("My Location");
            _map.AddMarker(currentLocationMarker);
            _isBusyOverlay.Visibility = ViewStates.Gone;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            _drawerToggle.OnOptionsItemSelected(item);
            return base.OnOptionsItemSelected(item);
        }
    }
}