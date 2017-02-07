using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using DirecTree.Android.Views.Base;
using DirecTree.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Views;

namespace DirecTree.Android.Views
{
    [Activity(Label = "Settings", Icon = "@drawable/Icon2", Theme = "@style/MyTheme.MainTheme")]
    public class SettingsView : MvxActivity
    {
        public static string DefaultPreferences => "defaultPreferences";
        public static string RETRIEVE_LOCATION_ON_STARTUP => "RLOS";
        private ISharedPreferences _preferences;
        private ISharedPreferencesEditor _editor;
        private CheckBox _syncLocationCheckBox;
        public bool RetrieveLocationOnStartUp {
            get {
                return _preferences.GetBoolean(RETRIEVE_LOCATION_ON_STARTUP, false);
            }
            set {
            }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.SettingsView);
            _preferences = GetSharedPreferences(DefaultPreferences, 0);
            _editor = _preferences.Edit();
            _syncLocationCheckBox = FindViewById<CheckBox>(Resource.Id.syncLocationToggle);
            SetupBindings();
            SetupUserSettings();
        }

        protected override void OnPause()
        {
            base.OnPause();
            SetupBindings();
            SetupUserSettings();
        }

        private void SetupBindings() {
            this.CreateBinding(this)
                .For(view => view.RetrieveLocationOnStartUp)
                .To<SettingsViewModel>(vm => vm.RetrieveLocationOnStartUp)
                .Apply();
        }

        private void SetupUserSettings() {
            if (_preferences.GetBoolean(RETRIEVE_LOCATION_ON_STARTUP, false))
                _syncLocationCheckBox.Checked = true;
            else
                _syncLocationCheckBox.Checked = false;
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();

            if (_syncLocationCheckBox.Checked)
            {
                _editor.PutBoolean(RETRIEVE_LOCATION_ON_STARTUP, true);
            }
            else
            {
                _editor.PutBoolean(RETRIEVE_LOCATION_ON_STARTUP, false);
            }
        }
    }

}