using System;
using System.Collections.Generic;
using System.Text;

namespace BlackkiteCLI.Models.ResponseModel
{
    public class TokenResponse
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        // public string expires_in { get; set; }
        public int tenant_id { get; set; }
    }
}
