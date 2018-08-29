using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AngleSharp.Dom;
using BrowseSharp;
using BrowseSharpScraperExamples.NFLScraper.Schedule;
using IDocument = BrowseSharp.IDocument;

namespace BrowseSharpScraperExamples.NFLScraper
{
    /// <summary>
    /// A webscraper for scraping content from NFL.com
    /// </summary>
    public class NFLScraper
    {
        /// <summary>
        /// Default Initializer
        /// </summary>
        public NFLScraper()
        {
            _browser = new Browser();
        }

        private Browser _browser;

        /// <summary>
        /// Go to home page
        /// </summary>
        /// <returns>Home page document</returns>
        public async Task<IDocument> GoHome()
        {
            IDocument document = await _browser.NavigateAsync("https://www.nfl.com/");
            return document;
        }


        /// <summary>
        /// Scrapes the schedule for the given year and week
        /// </summary>
        /// <param name="scheduleDate">Schedule date from ScheduleDates dictionary</param>
        /// <param name="year">Schedule Year</param>
        /// <returns>Scraped SchedultModel</returns>
        public async Task<Schedule.Schedule> GetSchedule(string scheduleDate, int year)
        {
            Schedule.Schedule scheduleModel = new Schedule.Schedule();

            IDocument scheduleDoc = await LoadSchedule(scheduleDate, year);
            scheduleModel = await ScrapeSchedule(scheduleDoc);

            return scheduleModel;
        }

        /// <summary>
        /// Loads document for specified date
        /// </summary>
        /// <param name="scheduleDate">Schedule date from ScheduleDates dictionary</param>
        /// <param name="year">Schedule Year</param>
        /// <returns>Document cotaining schedule</returns>
        public async Task<IDocument> LoadSchedule(string scheduleDate, int year)
        {
            IDocument document = await _browser.NavigateAsync("http://www.nfl.com/schedules/" + year.ToString() + "/" + scheduleDate);
            return document;
        }

        /// <summary>
        /// Schedule Data Keys used in url for searching came week
        /// </summary>
        public static Dictionary<string, string> ScheduleDates = new Dictionary<string, string>()
        {
            {"PRE1","PRE1"},
            {"PRE2","PRE2"},
            {"PRE3","PRE3"},
            {"REG1","REG1"},
            {"REG2","REG2"},
            {"REG3","REG3"},
            {"REG4","REG4"},
            {"REG5","REG5"},
            {"REG6","REG6"},
            {"REG7","REG7"},
            {"REG8","REG8"},
            {"REG9","REG9"},
            {"REG10","REG10"},
            {"REG11","REG11"},
            {"REG12","REG12"},
            {"REG13","REG13"},
            {"REG14","REG14"},
            {"REG15","REG15"},
            {"REG16","REG16"},
            {"REG17","REG17"},

        };

        /// <summary>
        /// Scrapes a document for schedule
        /// </summary>
        /// <param name="scheduleDocument">Schedule document to be scraped</param>
        /// <returns>Scraped ScheduleModel</returns>
        public async Task<Schedule.Schedule> ScrapeSchedule(IDocument scheduleDocument)
        {
            IHtmlCollection<IElement> matchupContainers = scheduleDocument.HtmlDocument.QuerySelectorAll(".schedules-list .schedules-table");
            Schedule.Schedule scheduleModel = new Schedule.Schedule();

            foreach (var matchupContainer in matchupContainers)
            {
                Regex regex = new Regex("(?:<!--).*(-->)");
                MatchCollection results = regex.Matches(matchupContainer.InnerHtml.ToString());
                foreach (var result in results)
                {
                    scheduleModel.RawElements.Add(result);
                    Console.WriteLine(result.ToString());
                }

            }

            scheduleModel.ScheduleDays = GetGameDays(scheduleModel.RawElements);

            foreach (Day scheduleDay in scheduleModel.ScheduleDays)
            {
                scheduleDay.Games = GetGames(scheduleDay);
            }

            return scheduleModel;

        }

        private List<Day> GetGameDays(List<object> matchupDays)
        {
            List<Day> scheduleDays = new List<Day>();
            Day scheduleDay = null;

            foreach (Object element in matchupDays)
            {
                string elementString = element.ToString();
                if (elementString.Contains("gameKey.key"))
                {
                    if (scheduleDay != null)
                        scheduleDays.Add(scheduleDay);
                    scheduleDay = new Day();
                    scheduleDay.Key = ScrapeCommentContent(elementString);
                }
                if (scheduleDay != null)
                    scheduleDay.RawElements.Add(element);
            }

            if (scheduleDay != null)
                scheduleDays.Add(scheduleDay);

            return scheduleDays;
        }

        private string ScrapeCommentContent(string commentContent)
        {
            Regex scriptScrapeRegex = new Regex("(?=:).*(?=-->)");
            return CleanScrapedContent(scriptScrapeRegex.Match(commentContent).ToString());
        }

        private string CleanScrapedContent(string dirtyContent)
        {
            return dirtyContent.Replace(":", "").Trim();
        }

        private List<Game> GetGames(Day scheduleDay)
        {
            List<Game> days = new List<Game>();
            Game game = null;

            foreach (object element in scheduleDay.RawElements)
            {


                string elementString = element.ToString();
                if (elementString.Contains("game.week"))
                {
                    if (game != null)
                        days.Add(game);
                    game = new Game();
                    game.GameWeek = int.Parse(ScrapeCommentContent(elementString));
                }
                else if (game == null)
                {
                    continue;
                }
                else if (elementString.Contains("formattedDate"))
                {
                    game.FormattedDate = ScrapeCommentContent(elementString);
                }
                else if (elementString.Contains("time"))
                {
                    game.Time = ScrapeCommentContent(elementString);
                }
                else if (elementString.Contains("formattedTime"))
                {
                    game.FormattedDateTime = ScrapeCommentContent(elementString);

                }
                else if (elementString.Contains("awayAbbr"))
                {
                    game.AwayAbbreviation = ScrapeCommentContent(elementString);
                }
                else if (elementString.Contains("homeAbbr"))
                {
                    game.HomeAbbreviation = ScrapeCommentContent(elementString);
                }
                else if (elementString.Contains("awayName"))
                {
                    game.AwayName = ScrapeCommentContent(elementString);
                }
                else if (elementString.Contains("homeName"))
                {
                    game.HomeName = ScrapeCommentContent(elementString);
                }
                else if (elementString.Contains("awayCityName"))
                {
                    game.AwayCityName = ScrapeCommentContent(elementString);
                }
                else if (elementString.Contains("homeCityName"))
                {
                    game.HomeCityName = ScrapeCommentContent(elementString);
                }
                game.RawElements.Add(element);
            }
            if (game != null)
                days.Add(game);

            return days;
        }
    }
}