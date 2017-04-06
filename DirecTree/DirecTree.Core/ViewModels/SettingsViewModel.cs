using System.Collections.Generic;
using DirecTree.Core.ViewModels.Base;
using MvvmCross.Core.ViewModels;
using System.Windows.Input;

namespace DirecTree.Core.ViewModels
{
    public class SettingsViewModel 
        : BaseViewModel
    {
        public SettingsViewModel()
        {
        }

        private bool _retrieveLocationOnStartUp;
        public bool RetrieveLocationOnStartUp {
            get {
                return _retrieveLocationOnStartUp;
            }
            set {
                _retrieveLocationOnStartUp = value;
                RaisePropertyChanged(() => RetrieveLocationOnStartUp);
            }
        }
    }
}
