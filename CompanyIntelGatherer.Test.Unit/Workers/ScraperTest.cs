using CompanyIntelGatherer.Builders;
using CompanyIntelGatherer.Data;
using CompanyIntelGatherer.Workers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace CompanyIntelGatherer.Test.Unit
{
    [TestClass]
    public class ScraperTest
    {
        private readonly Scraper _scraper = new Scraper();

        [TestMethod]
        public void FindCollectionWithNoParts()
        {
            var content = "Some False Data <a class=\"job-title\" href=\"http://test.com\">Test Job</a> more unessesary data";
            ScrapeLogic scrapeLogic = new ScrapeLogicBuilder()
                .WithData(content)
                .WithRegex(@"<a class=\""job-title\"" href=\""(.*?)\"">(.*?)</a>")
                .WithRegexOption(RegexOptions.Singleline)
                .Build();
            var foundScraped = _scraper.Scrape(scrapeLogic);

            Assert.IsTrue(foundScraped.Count == 1);
            Assert.IsTrue(foundScraped[0] == "<a class=\"job-title\" href=\"http://test.com\">Test Job</a>");
        }
        [TestMethod]
        public void FindCollectionWithTwoParts()
        {
            var content = "Some False Data <a class=\"job-title\" href=\"http://test.com\">Test Job</a> more unessesary data";
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
            var foundScraped = _scraper.Scrape(scrapeLogic);

            Assert.IsTrue(foundScraped.Count == 2);
            Assert.IsTrue(foundScraped[0] == "Test Job");
            Assert.IsTrue(foundScraped[1] == "http://test.com");
        }
    }
    
}
