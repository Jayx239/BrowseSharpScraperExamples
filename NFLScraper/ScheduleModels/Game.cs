using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowseSharpScraperExamples.NFLScraper.Schedule
{
    /// <summary>
    /// A model containing game tails
    /// </summary>
    public class Game : IRaw
    {
        public Game()
        {
            _rawElements = new List<object>();
        }
        
        /// <summary>
        /// Raw regex matches
        /// </summary>
        private List<object> _rawElements;
        
        /// <summary>
        /// 
        /// </summary>
        public List<object> RawElements { get => _rawElements; set => _rawElements = value; }
        
        /// <summary>
        /// Game week number
        /// </summary>
        public int GameWeek { get; set; }
        
        /// <summary>
        /// Formatted date
        /// </summary>
        public string FormattedDate { get; set; }
        
        /// <summary>
        /// Game time
        /// </summary>
        public string Time { get; set; }
        
        /// <summary>
        /// Formatted date time
        /// </summary>
        public string FormattedDateTime { get; set; }
        
        /// <summary>
        /// Away team abbreviation
        /// </summary>
        public string AwayAbbreviation { get; set; }
        
        /// <summary>
        /// Home team abbreviation
        /// </summary>
        public string HomeAbbreviation { get; set; }
        
        /// <summary>
        /// Away team name
        /// </summary>
        public string AwayName { get; set; }
        
        /// <summary>
        /// Home team name
        /// </summary>
        public string HomeName { get; set; }
        
        /// <summary>
        /// Away team city
        /// </summary>
        public string AwayCityName { get; set; }
        
        /// <summary>
        /// Home city name
        /// </summary>
        public string HomeCityName { get; set; }

    }
}
