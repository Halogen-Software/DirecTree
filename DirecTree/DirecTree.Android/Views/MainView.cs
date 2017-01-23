using Android.App;
using Android.Gms.Maps;
using Android.OS;
using MvvmCross.Droid.Support.V7.AppCompat;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;

namespace DirecTree.Android.Views
{
    [Activity(Label = "DirecTree", Theme = "@style/MyTheme.MainTheme")]
    public class MainView : MvxAppCompatActivity, IOnMapReadyCallback
    {
        private SupportToolbar _supportToolbar;
        private GoogleMap _map;
        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MainView);
            SetupMap();
            _supportToolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            SetSupportActionBar(_supportToolbar);
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
    }
}
