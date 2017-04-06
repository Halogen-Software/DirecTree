using System.Collections.Generic;
using System.Windows.Input;
using DirecTree.Core.DevTests;
using DirecTree.Core.Models;
using DirecTree.Core.Util;
using DirecTree.Core.ViewModels.Base;
using MvvmCross.Core.ViewModels;

namespace DirecTree.Core.ViewModels
{
    public class VendorEditViewModel : BaseViewModel
    {
        private Vendor CurrentVendor;
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

        public ICommand SaveVendorCommand => new MvxCommand(SaveVendor);

        public void SaveVendor()
        {
            Vendor newVendor = new Vendor();
            newVendor.CompanyName = CompanyName;
            newVendor.VendorName = VendorName;
            newVendor.VendorSurname = VendorSurname;
            newVendor.Address = Address;
            newVendor.Email = Email;
            newVendor.ProfilePic = ProfilePic;
            newVendor.ProfileBackground = ProfileBackground;
            newVendor.ProfileBackgroundColor = ProfileBackgroundColor;
            newVendor.VendorLocation = VendorLocation;
            newVendor.ServiceList = ServiceList;
        }

        // Todo: once db stuff done, this needs to be long Id instead of string
        public void Init(string Id)
        {
            foreach (Vendor vendor in DevOptions.DevVendorList)
            {
                if (Id.ToLower() == vendor.CompanyName.ToLower())
                {
                    CurrentVendor = vendor;
                    CompanyName = CurrentVendor.CompanyName;
                    VendorName = CurrentVendor.VendorName;
                    VendorSurname = CurrentVendor.VendorSurname;
                    Address = CurrentVendor.Address;
                    Email = CurrentVendor.Email;
                    ProfilePic = CurrentVendor.ProfilePic;
                    ProfileBackground = CurrentVendor.ProfileBackground;
                    ProfileBackgroundColor = CurrentVendor.ProfileBackgroundColor;
                    VendorLocation = CurrentVendor.VendorLocation;
                    ServiceList = CurrentVendor.ServiceList;
                }
            }
        }
    }
}
