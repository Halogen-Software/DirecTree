using Android.App;
using Android.Content;
using Android.OS;
using DirecTree.Android.Views.Base;

namespace DirecTree.Android.Views
{
    [Activity(Label = "Settings", Icon = "@drawable/Icon2", Theme = "@style/MyTheme.MainTheme")]
    public class SettingsView : BaseView
    {
        public static string DefaultPreferences => "defaultPreferences";
        private string RETRIEVE_LOCATION_ON_STARTUP => "RLOS";
        private ISharedPreferences _preferences;
        private ISharedPreferencesEditor _editor;
        private bool RetrieveLocationOnStartUp {
            get {
                return _preferences.GetBoolean(RETRIEVE_LOCATION_ON_STARTUP, false);
            }
            set {
                if (!_preferences.GetBoolean(RETRIEVE_LOCATION_ON_STARTUP, false))
                    _editor.PutBoolean(RETRIEVE_LOCATION_ON_STARTUP, true);
                else
                    _editor.PutBoolean(RETRIEVE_LOCATION_ON_STARTUP, false);
            }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.SettingsView);
            _preferences = GetSharedPreferences(DefaultPreferences, 0);
            _editor = _preferences.Edit();
            SetupBindings();
        }

        private void SetupBindings() {

        }

        private void SetupUserSettings() {

        }
    }

}