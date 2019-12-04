using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using CompanyIntelGatherer.Data;

namespace CompanyIntelGatherer.Builders
{
    class ScrapeLogicBuilder
    {
        private string _data;
        private string _regex;
        private RegexOptions _regexOption;
        private List<ScrapeLogicPart> _parts;

        public ScrapeLogicBuilder()
        {
            SetDefaults();
        }

        private void SetDefaults()
        {
            _data = string.Empty;
            _regex = string.Empty;
            _regexOption = RegexOptions.None;
            _parts = new List<ScrapeLogicPart>();
        }

        public ScrapeLogicBuilder WithData (string data)
        {
            _data = data;
            return this;
        }
        public ScrapeLogicBuilder WithRegex(string regex)
        {
            _regex = regex;
            return this;
        }

        public ScrapeLogicBuilder WithRegexOption(RegexOptions regexOption)
        {
            _regexOption = regexOption;
            return this;
        }
        public ScrapeLogicBuilder WithPart(ScrapeLogicPart scrapeLogicPart)
        {
            _parts.Add(scrapeLogicPart);
            return this;
        }

        public ScrapeLogic Build()
        {
            ScrapeLogic scrapeLogic = new ScrapeLogic();
            scrapeLogic.Data = _data;
            scrapeLogic.Regex = _regex;
            scrapeLogic.RegexOption = _regexOption;
            scrapeLogic.Parts = _parts;
            return scrapeLogic;


        }
    }
}
