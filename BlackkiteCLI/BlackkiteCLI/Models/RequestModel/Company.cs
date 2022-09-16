using System;
using System.Collections.Generic;
using System.Text;

namespace BlackkiteCLI.Models.RequestModel
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string MainDomainValue { get; set; }
        public string CompanyName { get; set; }
        public int EcosystemId { get; set; }
        public string LicenseType { get; set; }
        public bool IsSubsidiary { get; set; } = false;
        public bool IsCloudProvider { get; set; } = false;
    }
}
