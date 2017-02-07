using MvvmCross.Core.ViewModels;
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

        public void LaunchLocationSyncActivity() {
            ShowViewModel<LocationSyncViewModel>();
        }
    }
}
