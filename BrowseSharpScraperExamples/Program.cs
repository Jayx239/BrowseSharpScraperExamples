using BrowseSharp;

namespace BrowseSharpScraperExamples
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            NFLScraper nflScraper = new NFLScraper();
            //IDocument homePage = nflScraper.GoHome().GetAwaiter().GetResult();
            nflScraper.GetSchedule(NFLScraper.ScheduleDates["REG1"], 2018).GetAwaiter().GetResult();
            
        }
    }
}