using System;
using System.Collections.Generic;
using System.Text;

namespace BlackkiteCLI.Models.RequestModel
{
    public class Search
    {
        public string GenericSearchText { get; set; }
        public List<int?> EcosystemIds { get; set; }
        public List<int?> IndustryIds { get; set; }
        public List<string> CountryCodes { get; set; }
        public List<int?> TagIds { get; set; }
        public List<int?> ProductGroupIds { get; set; }
        public List<string> GradeLetters { get; set; }
        public List<string> ControlCodes { get; set; }
        public List<string> CveOrCweCodes { get; set; }
        public bool HasCriticalVuln { get; set; } = false;
        public bool HasLeakIn90Days { get; set; } = false;
        public bool HasPoorSsl { get; set; } = false;
        public bool HasPoorDdos { get; set; } = false;
        public bool HasPoorSmtp { get; set; } = false;
        public bool HasPoorDns { get; set; } = false;
        public int? CwssCvssBiggerThanValue { get; set; }
    }
}
