using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Views;

namespace DirecTree.Android.Views
{
    [Activity(Label = "Your Profile", Theme = "@style/MyTheme.MainTheme")]
    public class VendorProfileDetailView : MvxActivity
    {
        private TextView _companyName;
        private LinearLayout _companyNameLayout;
        private LinearLayout _vendorNameLayout;
        private LinearLayout _vendorSurnameLayout;
        private LinearLayout _addressLayout;
        private LinearLayout _emailLayout;
        private LinearLayout _profilePicLayout;
        private LinearLayout _backgroundPicLayout;
        private LinearLayout _gpsLayout;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            SetContentView(Resource.Layout.VendorProfileDetailView);

            _companyName = FindViewById<TextView>(Resource.Id.CompanyNameLabel);
            _companyNameLayout = FindViewById<LinearLayout>(Resource.Id.CompanyNameLayout);
            _vendorNameLayout = FindViewById<LinearLayout>(Resource.Id.VendorNameLayout);
            _vendorSurnameLayout = FindViewById<LinearLayout>(Resource.Id.VendorSurnameLayout);
            _addressLayout = FindViewById<LinearLayout>(Resource.Id.AddressLayout);
            _emailLayout = FindViewById<LinearLayout>(Resource.Id.EmailLayout);
            _profilePicLayout = FindViewById<LinearLayout>(Resource.Id.ProfilePicLayout);
            _backgroundPicLayout = FindViewById<LinearLayout>(Resource.Id.BackgroundPicLayout);
            _gpsLayout = FindViewById<LinearLayout>(Resource.Id.GpsLayout);
            SetViewVisibilities();
        }

        private void SetViewVisibilities() {
            if (_companyName.Text.Equals("NoSignedInUser"))
            {
                _companyNameLayout.Visibility = ViewStates.Gone;
                _vendorNameLayout.Visibility = ViewStates.Gone;
                _vendorSurnameLayout.Visibility = ViewStates.Gone;
                _addressLayout.Visibility = ViewStates.Gone;
                _emailLayout.Visibility = ViewStates.Gone;
                _profilePicLayout.Visibility = ViewStates.Gone;
                _backgroundPicLayout.Visibility = ViewStates.Gone;
                _gpsLayout.Visibility = ViewStates.Gone;

                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("No vendor currently signed in");
                alert.SetMessage("Guests do not have access to the details page, please sign in.");
                alert.SetPositiveButton("Ok", (senderAlert, args) => {
                    Finish();
                });

                Dialog dialog = alert.Create();
                dialog.Show();

            }
            else
            {
                _companyNameLayout.Visibility = ViewStates.Visible;
                _vendorNameLayout.Visibility = ViewStates.Visible;
                _vendorSurnameLayout.Visibility = ViewStates.Visible;
                _addressLayout.Visibility = ViewStates.Visible;
                _emailLayout.Visibility = ViewStates.Visible;
                _profilePicLayout.Visibility = ViewStates.Visible;
                _backgroundPicLayout.Visibility = ViewStates.Visible;
                _gpsLayout.Visibility = ViewStates.Visible;
            }
        }
    }
}