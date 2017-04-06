using MvvmCross.Core.ViewModels;
using System.Collections.Generic;
using System.Windows.Input;

namespace DirecTree.Core.ViewModels.Base
{
    public class BaseViewModel : MvxViewModel
    {
        public ICommand NavigateToSettings => new MvxCommand(LaunchSettingsActivity);

        public void LaunchSettingsActivity() {
            ShowViewModel<SettingsViewModel>();
        }

        public ICommand NavigateToLocationSync => new MvxCommand(LaunchLocationSyncActivity);

        private void LaunchLocationSyncActivity() {
            ShowViewModel<LocationSyncViewModel>();
        }

        public ICommand NavigateToSignIn => new MvxCommand(LaunchSignInActivity);

        private void LaunchSignInActivity() {
            ShowViewModel<SignInViewModel>();
        }

        public ICommand NavigateToProfileView => new MvxCommand(LaunchProfileViewActivity);

        private void LaunchProfileViewActivity() {
            ShowViewModel<VendorProfileDetailViewModel>();
        }

        private List<string> _sideBarListItems;
        public List<string> SideBarListItems
        {
            get { return _sideBarListItems; }
            set { SetProperty(ref _sideBarListItems, value); }
        }
    }
}
