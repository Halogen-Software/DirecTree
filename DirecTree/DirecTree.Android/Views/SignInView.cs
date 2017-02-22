using Android.App;
using Android.OS;
using DirecTree.Android.Views.Base;
using MvvmCross.Droid.Views;

namespace DirecTree.Android.Views.Fragments
{
    [Activity(Label = "Sign In", Theme = "@style/MyTheme.MainTheme")]
    public class SignInView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            SetContentView(Resource.Layout.SignInView);
        }
    }
}