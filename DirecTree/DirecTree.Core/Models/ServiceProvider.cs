using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator.Abstractions;

namespace DirecTree.Core.Models
{
    public class ServiceProvider
    {
        public long Id { get; set; }
        public string CompanyName { get; set; }
        public string ServiceProviderName { get; set; }
        public string ServiceProviderSirname { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ProfilePic { get; set; }
        public string ProfileBackground { get; set; }
        public int ProfileLayout { get; set; }
        public string ProfileBackgroundColor { get; set; }
    }
}
