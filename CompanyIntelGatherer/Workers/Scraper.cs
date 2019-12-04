using CompanyIntelGatherer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CompanyIntelGatherer.Workers
{
    class Scraper
    {
        public List<string> Scrape(ScrapeLogic scrapeLogic)
        {
            List<string> scraped = new List<string>();
            MatchCollection matches = Regex.Matches(scrapeLogic.Data, scrapeLogic.Regex, scrapeLogic.RegexOption);

            foreach (Match match in matches)
            {
                if (!scrapeLogic.Parts.Any())
                {
                    scraped.Add(match.Groups[0].Value);
                }
                else
                {
                    foreach (var part in scrapeLogic.Parts)
                    {
                        Match matchedPart = Regex.Match(match.Groups[0].Value, part.Regex, part.RegexOption);

                        if (matchedPart.Success) scraped.Add(matchedPart.Groups[1].Value);
                    }
                }
            }

            return scraped;
        }
    }
}
