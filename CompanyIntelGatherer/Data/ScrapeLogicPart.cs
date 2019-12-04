using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CompanyIntelGatherer.Data
{
    class ScrapeLogicPart
    {
        public string Regex { get; set; }
        public RegexOptions RegexOption { get; set; }
    }
}
