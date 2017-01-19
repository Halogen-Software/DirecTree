using Android.App;
using Android.Gms.Maps;
using Android.OS;
using MvvmCross.Droid.Views;

namespace DirecTree.Android.Views
{
    [Activity(Label = "View for MainViewModel")]
    public class MainView : MvxActivity, IOnMapReadyCallback
    {
        private GoogleMap _map;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.MainView);

            SetupMap();
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
