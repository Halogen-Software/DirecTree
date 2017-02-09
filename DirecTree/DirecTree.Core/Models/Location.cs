using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirecTree.Core.Models
{
    public class Location
    {
        public long Id { get; set; }
        public long VendorId { get; set; }
        public double GpsLongitude { get; set; }
        public double GpsLatitude { get; set; }
    }
}
