using BlackkiteCLI.Models.RequestModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackkiteCLI.Models.Environment
{
    public class Environments
    {
        public string ApiBaseUrl { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string GrantType { get; set; }
        public Company Company { get; set; }
    }
}
