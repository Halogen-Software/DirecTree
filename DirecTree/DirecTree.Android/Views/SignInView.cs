using Android.App;
using Android.OS;
using DirecTree.Android.Views.Base;

namespace DirecTree.Android.Views.Fragments
{
    [Activity(Label = "Sign In", Icon = "@drawable/Icon2", Theme = "@style/MyTheme.MainTheme")]
    public class SignInView : BaseView
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.SignInView);
        }
    }
}