using CompanyIntelGatherer.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CompanyIntelGatherer.Builders
{
    class ScrapeLogicPartBuilder
    {
        //public string Regex { get; set; }
        //public RegexOptions RegexOption { get; set; }

        private string _regex;
        private RegexOptions _regexOption;

        public ScrapeLogicPartBuilder()
        {
            SetDefaults();
        }

        private void SetDefaults()
        {
            _regex = string.Empty;
            _regexOption = RegexOptions.None;
        }

        public ScrapeLogicPartBuilder WithRegex(string regex)
        {
            _regex = regex;
            return this;
        }

        public ScrapeLogicPartBuilder WithRegexOptions(RegexOptions regexOptions)
        {
            _regexOption = regexOptions;
            return this;
        }
        public ScrapeLogicPart Build()
        {
            ScrapeLogicPart scrapeLogicPart = new ScrapeLogicPart();
            scrapeLogicPart.Regex = _regex;
            scrapeLogicPart.RegexOption = _regexOption;
            return scrapeLogicPart;
        }
    }
}
