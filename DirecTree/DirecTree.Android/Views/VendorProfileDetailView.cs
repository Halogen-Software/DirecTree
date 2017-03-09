using Android.App;
using Android.OS;
using Android.Widget;
using DirecTree.Android.Views.Base;
using DirecTree.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Views;

namespace DirecTree.Android.Views.Fragments
{
    [Activity(Label = "You Profile", Theme = "@style/MyTheme.MainTheme")]
    public class VendorProfileDetailView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            SetContentView(Resource.Layout.VendorProfileDetailView);
        }
    }
}