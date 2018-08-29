using BrowseSharp;

namespace BrowseSharpScraperExamples
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            NFLScraper.NFLScraper nflScraper = new NFLScraper.NFLScraper();
            //IDocument homePage = nflScraper.GoHome().GetAwaiter().GetResult();
            NFLScraper.Schedule.ScheduleModel scheduleModel = nflScraper.GetSchedule(NFLScraper.NFLScraper.ScheduleDates["REG1"], 2018).GetAwaiter().GetResult();
            
        }
    }
}