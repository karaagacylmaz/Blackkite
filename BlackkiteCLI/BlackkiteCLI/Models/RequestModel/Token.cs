using System;
using System.Collections.Generic;
using System.Text;

namespace BlackkiteCLI.Models.RequestModel
{
    public class Token
    {
        public string grant_type { get; set; }
        public string client_id { get; set; }
        public string client_secret { get; set; }
    }
}
