using Android.Content;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using DirecTree.Core.ViewModels;
using DirecTree.Core.ViewModels.Base;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.Fragging.Fragments;
using MvvmCross.Platform;

namespace DirecTree.Android.Views.Base
{
    public class BaseView : MvxAppCompatActivity
    {
        public MainViewModel HomeViewModel { get; set; }
        public Context context;
        private MvxFragment _currentFragment;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            HomeViewModel = Mvx.Resolve<MainViewModel>();
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

        public void ShowFragment(int fragmentHolderId, MvxFragment fragment)
        {
            FragmentTransaction transaction = SupportFragmentManager.BeginTransaction();
            transaction.Add(fragmentHolderId, fragment);
            transaction.Commit();
            _currentFragment = fragment;
        }
    }
}