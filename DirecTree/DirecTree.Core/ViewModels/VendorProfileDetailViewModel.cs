using DirecTree.Core.Models;
using DirecTree.Core.Util;
using DirecTree.Core.ViewModels.Base;
using System.Collections.Generic;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace DirecTree.Core.ViewModels
{
    public class VendorProfileDetailViewModel
        : BaseViewModel
    {
        private Vendor CurrentUser => StaticUtils.currentUser;
        public VendorProfileDetailViewModel(){
            if (CurrentUser != null)
            {
                CompanyName = CurrentUser.CompanyName;
                VendorName = CurrentUser.VendorName;
                VendorSurname = CurrentUser.VendorSurname;
                Address = CurrentUser.Address;
                Email = CurrentUser.Email;
                ProfilePic = CurrentUser.ProfilePic;
                ProfileBackground = CurrentUser.ProfileBackground;
                ProfileBackgroundColor = CurrentUser.ProfileBackgroundColor;
                VendorLocation = CurrentUser.VendorLocation;
                ServiceList = CurrentUser.ServiceList;
            }
            else
            {
                CompanyName = "NoSignedInUser";
            }
        }

        public string CompanyName { get; set; }
        public string VendorName { get; set; }
        public string VendorSurname { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string ProfilePic { get; set; }
        public string ProfileBackground { get; set; }
        public int ProfileLayout { get; set; }
        public string ProfileBackgroundColor { get; set; }
        public Location VendorLocation { get; set; }
        public List<VendorService> ServiceList { get; set; }

        public ICommand EditVendorCommand => new MvxCommand(NavigateToEditVendorView);

        public void NavigateToEditVendorView()
        {
            // Todo: this needs to be an ID once the DB stuff is done
            ShowViewModel<VendorEditViewModel>(new { Id = CompanyName});
        }
    }
}
