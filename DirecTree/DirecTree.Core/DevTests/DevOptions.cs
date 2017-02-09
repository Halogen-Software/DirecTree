using DirecTree.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirecTree.Core.DevTests
{
    public class DevOptions
    {
        public static List<Vendor> DevVendorList { get; set; }

        public DevOptions() {
            DevVendorList = CreateDevVendorList();
        }

        public List<Vendor> CreateDevVendorList() {
            Vendor vendor = new Vendor();
            vendor.Id = 1;
            vendor.CompanyName = "Awesome Dev Company";
            vendor.Email = "dev@mail.com";
            vendor.VendorName = "John";
            vendor.VendorSurname = "Smith";
            vendor.Username = "John";
            vendor.Password = "password";
            Location vendorLocation = new Location();
            vendorLocation.GpsLatitude = -33.947825;
            vendorLocation.GpsLongitude = 18.473835;
            vendor.VendorLocation = vendorLocation;
            vendor.ServiceList = CreateDevVendorServiceList();

            var vendorList = new List<Vendor>();
            vendorList.Add(vendor);

            return vendorList;       
        }

        public List<VendorService> CreateDevVendorServiceList() {
            List<VendorService> services = new List<VendorService>();

            VendorService cleaningService = new VendorService();
            cleaningService.ServiceName = "Cleaning";
            cleaningService.ServiceDescription = "We provide you with the best cleaning services that money can buy.";
            cleaningService.Price = 119.90M;

            VendorService paintingService = new VendorService();
            paintingService.ServiceName = "Painting";
            paintingService.ServiceDescription = "Any color you want, we will paint.";
            paintingService.Price = 249.90M;

            services.Add(cleaningService);
            services.Add(paintingService);

            return services;
        }
    }
}
