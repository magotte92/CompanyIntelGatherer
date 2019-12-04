using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CompanyIntelGatherer.Data
{
    class ScrapeLogic
    {
        public ScrapeLogic()
        {
            Parts = new List<ScrapeLogicPart>();
        }
        public string Data { get; set; }
        public string Regex { get; set; }
        public RegexOptions RegexOption { get; set; }
        public List<ScrapeLogicPart> Parts { get; set; }
    }
}
