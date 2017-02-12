using Android.Content;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using DirecTree.Core.ViewModels.Base;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.Fragging.Fragments;

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

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId) {
                case Resource.Id.action_Settings:
                    ((BaseViewModel) ViewModel).NavigateToSettings.Execute(this);
                    break;
                case Resource.Id.action_Recenter:
                    ((BaseViewModel) ViewModel).NavigateToLocationSync.Execute(this);
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }

        public void ShowFragment(MvxFragment fragment, FrameLayout frameLayout)
        {
            var transaction = SupportFragmentManager.BeginTransaction();
            transaction.Add(frameLayout.Id, fragment);
            transaction.Commit();
        }
    }
}