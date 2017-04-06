using DirecTree.Core.DevTests;
using DirecTree.Core.Models;
using DirecTree.Core.ViewModels.Base;
using MvvmCross.Core.ViewModels;
using System;
using System.Windows.Input;
using DirecTree.Core.Util;

namespace DirecTree.Core.ViewModels
{
    public class SignInViewModel
        : BaseViewModel
    {
        private long vendorId;

        private string _userName;
        public string Username {
            get { return _userName; }
            set {
                _userName = value;
                RaisePropertyChanged(() => Username);
            }
        }

        private string _authText;
        public string AuthText
        {
            get { return _authText; }
            set
            {
                _authText = value;
                RaisePropertyChanged(() => AuthText);
            }
        }

        private string _password;
        public string Password {
            get { return _password; }
            set {
                _password = value;
                RaisePropertyChanged(() => Password);
            }
        }
        private bool _isCredentialsValid = false;
        public bool IsCredentialsValid {
            get { return _isCredentialsValid; }
            set {
                _isCredentialsValid = value;
                RaisePropertyChanged(() => IsCredentialsValid);
            }
        }

        public ICommand ValidateCredentialsCommand => new MvxCommand(ValidateCredentials);

        // This method needs to change when we implement an actual DB.
        public void ValidateCredentials() {
            foreach (Vendor vendor in DevOptions.DevVendorList) {
                if ((Username.ToLower() == vendor.Email.ToLower() || Username.ToLower() == vendor.Username.ToLower()) && Password == vendor.Password) {
                    vendorId = vendor.Id;
                    StaticUtils.currentUser = vendor;
                    IsCredentialsValid = true;
                }
            }

            if (IsCredentialsValid)
            {
                // Do something
                AuthText = "Login is valid";

            }
            else {
                // Throw validation message
                AuthText = "Username or password incorrect";
            }
        }
    }
}
