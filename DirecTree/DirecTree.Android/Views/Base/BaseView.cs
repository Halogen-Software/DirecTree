using Android.Content;
using Android.OS;
using Android.Views;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Views;

namespace DirecTree.Android.Views.Base
{
    public class BaseView : MvxAppCompatActivity
    {
        public Context context;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            context = this;
            InvalidateOptionsMenu();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater inflater = MenuInflater;
            inflater.Inflate(Resource.Menu.menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }
    }
}