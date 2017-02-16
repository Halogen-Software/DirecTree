using Android.OS;
using Android.Runtime;
using Android.Views;
using DirecTree.Android.Views.Base;
using DirecTree.Core.ViewModels;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace DirecTree.Android.Views.Fragments
{
    public class SignInView : BaseView
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.SignInView);
        }
    }
}