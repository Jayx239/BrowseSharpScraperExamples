using System.Collections.Generic;

namespace BrowseSharpScraperExamples.NFLScraper.Schedule
{
    /// <summary>
    /// A model for storing schedule data
    /// </summary>
    public class ScheduleModel : IRawSchedule
    {
        /// <summary>
        /// Default initializer
        /// </summary>
        public ScheduleModel()
        {
            _rawElements = new List<object>();
        }
        
        public List<object> RawElements { get => _rawElements; set => _rawElements = value; }
        public List<ScheduleDay> ScheduleDays { get => _scheduleDays; set => _scheduleDays = value; }

        private List<object> _rawElements;
        private List<ScheduleDay> _scheduleDays;
    }
}