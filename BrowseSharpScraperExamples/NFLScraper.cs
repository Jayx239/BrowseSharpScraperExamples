﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AngleSharp.Dom;
using BrowseSharp;
using IDocument = BrowseSharp.IDocument;

namespace BrowseSharpScraperExamples
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
        public async Task<ScheduleModel> GetSchedule(string scheduleDate, int year)
        {
            ScheduleModel scheduleModel =  new ScheduleModel();

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
            IDocument document = await _browser.NavigateAsync("http://www.nfl.com/schedules/" + year.ToString() + "/" + scheduleDate );
            return document;
        }

        /// <summary>
        /// Schedule Data Keys used in url for searching came week
        /// </summary>
        public static Dictionary<string,string> ScheduleDates = new Dictionary<string, string>()
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
        public async Task<ScheduleModel> ScrapeSchedule(IDocument scheduleDocument)
        {
            IHtmlCollection<IElement> matchupContainers = scheduleDocument.HtmlDocument.QuerySelectorAll(".schedules-list .schedules-table");
            foreach (var matchupContainer in matchupContainers) 
            {
                Regex regex = new Regex("(?:<!--).*(-->)");
                var results = regex.Matches(matchupContainer.InnerHtml.ToString());
                foreach (var result in results)
                {
                    Console.WriteLine(result.ToString());
                }
                
            }
            return new ScheduleModel(); // TODO: Create model and inject data

        }
    }
}