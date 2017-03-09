using DirecTree.Core.Models;
using DirecTree.Core.Util;
using DirecTree.Core.ViewModels.Base;
using System.Collections.Generic;

namespace DirecTree.Core.ViewModels
{
    public class VendorProfileDetailViewModel
        : BaseViewModel
    {
        private Vendor CurrentUser => StaticUtils.currentUser;
        public VendorProfileDetailViewModel(){
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
    }
}
