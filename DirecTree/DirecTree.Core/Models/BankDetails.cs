using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirecTree.Core.Models
{
    public class BankDetails
    {
        public long Id { get; set; }
        public long ServiceProviderId { get; set; }
        public string BankName { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string AccountHolderName { get; set; }
    }
}
