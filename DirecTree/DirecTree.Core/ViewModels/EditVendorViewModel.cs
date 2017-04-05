using System.Collections.Generic;
using System.Windows.Input;
using DirecTree.Core.Models;
using DirecTree.Core.ViewModels.Base;
using MvvmCross.Core.ViewModels;

namespace DirecTree.Core.ViewModels
{
    public class EditVendorViewModel : BaseViewModel
    {
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
    }
}
