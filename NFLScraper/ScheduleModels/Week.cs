using System.Collections.Generic;

namespace BrowseSharpScraperExamples.NFLScraper.Schedule
{
    /// <summary>
    /// A model for storing schedule data
    /// </summary>
    public class Week : IRaw
    {
        /// <summary>
        /// Default initializer
        /// </summary>
        public Week()
        {
            _rawElements = new List<object>();
        }
        
        /// <summary>
        /// Raw regex matches
        /// </summary>
        public List<object> RawElements { get => _rawElements; set => _rawElements = value; }
        
        /// <summary>
        /// Schedule Days in the schedule week
        /// </summary>
        public List<Day> ScheduleDays { get => _scheduleDays; set => _scheduleDays = value; }

        /// <summary>
        /// Raw regex matches
        /// </summary>
        private List<object> _rawElements;
        
        /// <summary>
        /// Schedule Days in the schedule week
        /// </summary>
        private List<Day> _scheduleDays;
    }
}