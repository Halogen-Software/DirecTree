using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirecTree.Core.Models
{
    public class VendorService
    {
        public long Id { get; set; }
        public long ServiceProviderId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public decimal Price { get; set; }
    }
}
