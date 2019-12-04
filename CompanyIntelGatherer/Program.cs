using CompanyIntelGatherer.Builders;
using CompanyIntelGatherer.Data;
using CompanyIntelGatherer.Workers;
using System;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("CompanyIntelGatherer.Test.Unit")]

namespace CompanyIntelGatherer
{
    class Program
    {
        
        private const string Method = "θέσεις-εργασίας?utf8=✓&q=";
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please enter the position you're interested in:");
                var jobDescription = Console.ReadLine() ?? string.Empty;
                Console.WriteLine("Please enter the city you would like to search:");
                var companyCountry = Console.ReadLine() ?? string.Empty;

                using (WebClient client = new WebClient())
                {
                    string content = client.DownloadString($"https://www.kariera.gr/{Method}{jobDescription.Replace(" ", "+")}&loc={companyCountry.Replace(" ", "+")}");
                    ScrapeLogic scrapeLogic = new ScrapeLogicBuilder()
                        .WithData(content)
                        .WithRegex(@"<a class=\""job-title\"" href=\""(.*?)\"">(.*?)</a>")
                        .WithRegexOption(RegexOptions.Singleline)
                        .WithPart(new ScrapeLogicPartBuilder()
                            .WithRegex(@">(.*?)</a>")
                            .WithRegexOptions(RegexOptions.Singleline)
                            .Build())
                        .WithPart(new ScrapeLogicPartBuilder()
                            .WithRegex(@"href=\""(.*?)\""")
                            .WithRegexOptions(RegexOptions.Singleline)
                        .Build())
                    .Build();

                    Scraper scraper = new Scraper();

                    var scraped = scraper.Scrape(scrapeLogic);

                    if (scraped.Any())
                    {
                        foreach (var scrape in scraped)
                        {
                            Console.WriteLine(scrape);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"No results for {jobDescription} at {companyCountry}");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}