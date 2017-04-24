using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using DirecTree.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Views;
using DirecTree.Core.Util;

namespace DirecTree.Android.Views.Fragments
{
    [Activity(Label = "Sign In", Theme = "@style/MyTheme.MainTheme")]
    public class SignInView : MvxActivity
    {
        
        private ISharedPreferences _preferences;
        private ISharedPreferencesEditor _editor;
        private CheckBox _rememberMeCheckBox;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            SetContentView(Resource.Layout.SignInView);

            _preferences = Application.Context.GetSharedPreferences(SettingsView.DefaultPreferences, FileCreationMode.Private);
            _editor = _preferences.Edit();
            _rememberMeCheckBox = FindViewById<CheckBox>(Resource.Id.RememberMeCheckBox);
            SetupRememberMe();
            SetupBindings();
        }

        protected override void OnPause()
        {
            base.OnPause();
            SetupRememberMe();
        }

        private void SetupRememberMe()
        {
            if (_preferences.GetBoolean(SettingsView.KEEP_USER_SIGNED_IN, false))
                _rememberMeCheckBox.Checked = true;
            else
                _rememberMeCheckBox.Checked = false;
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

            if (_rememberMeCheckBox.Checked)
            {
                _editor.PutBoolean(SettingsView.KEEP_USER_SIGNED_IN, true);
                SettingsView.PreviouslySignedInUser = StaticUtils.currentUser;
                _editor.PutString(SettingsView.SIGNED_IN_USER, StaticUtils.currentUser.Username);
                _editor.Apply();
            }
            else
            {
                _editor.PutBoolean(SettingsView.KEEP_USER_SIGNED_IN, false);
                SettingsView.PreviouslySignedInUser = null;
                _editor.PutString(SettingsView.SIGNED_IN_USER, String.Empty);
                _editor.Apply();
            }
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