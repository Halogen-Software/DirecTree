using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace DirecTree.Android.Views
{
    [Activity(Label = "Edit Your Profile", Theme = "@style/MyTheme.MainTheme")]
    public class VendorEditView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.VendorEditView);
        }
    }
}