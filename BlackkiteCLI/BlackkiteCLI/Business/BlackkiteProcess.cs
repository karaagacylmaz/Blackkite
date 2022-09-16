using BlackkiteCLI.Services;
using BlackkiteCLI.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackkiteCLI.Business
{
    public class BlackkiteProcess
    {
        public string Start()
        {
            LogManager.Configure();
            HttpClientService service = new HttpClientService();

            service.CreateSearchOperation();
            return "";
        }
    }
}
