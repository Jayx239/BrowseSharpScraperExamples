using System.Collections.Generic;

namespace BrowseSharpScraperExamples.NFLScraper.Schedule
{
    /// <summary>
    /// A model for storing schedule data
    /// </summary>
    public class Schedule : IRaw
    {
        /// <summary>
        /// Default initializer
        /// </summary>
        public Schedule()
        {
            _rawElements = new List<object>();
        }
        
        public List<object> RawElements { get => _rawElements; set => _rawElements = value; }
        public List<Day> ScheduleDays { get => _scheduleDays; set => _scheduleDays = value; }

        private List<object> _rawElements;
        private List<Day> _scheduleDays;
    }
}