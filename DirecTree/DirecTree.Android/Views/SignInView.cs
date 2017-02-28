using Android.App;
using Android.OS;
using Android.Widget;
using DirecTree.Android.Views.Base;
using DirecTree.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
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
            SetupBindings();
        }

        private bool _isCredentialsValid = false;
        public bool IsCredentialsValid
        {
            get { return _isCredentialsValid; }
            set
            {
                _isCredentialsValid = value;
                if (_isCredentialsValid)
                    CloseActivityOnSuccess();
            }
        }

        private void CloseActivityOnSuccess() {
            var _linearLayout = this.FindViewById<LinearLayout>(Resource.Id.SignInLinearLayout);
            _linearLayout.SetBackgroundResource(Resource.Drawable.zero);
            this.Finish();
        }

        private void SetupBindings()
        {
            var _signInBindingSet = this.CreateBindingSet<SignInView, SignInViewModel>();
            _signInBindingSet.Bind(this).For(v => v.IsCredentialsValid).To(vm => vm.IsCredentialsValid).OneWay();
            _signInBindingSet.Apply();
        }
    }
}