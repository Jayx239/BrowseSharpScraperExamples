using BrowseSharp;

namespace BrowseSharpScraperExamples
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            NFLScraper.NFLScraper nflScraper = new NFLScraper.NFLScraper();
            NFLScraper.Schedule.Schedule scheduleModel = nflScraper.GetSchedule(NFLScraper.NFLScraper.ScheduleDates["REG1"], 2018).GetAwaiter().GetResult();
            
        }
    }
}