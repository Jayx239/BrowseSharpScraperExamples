using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowseSharpScraperExamples.NFLScraper.Schedule
{
    /// <summary>
    /// A model containing details about game schedule
    /// </summary>
    public class Day : IRaw
    {
        public Day()
        {
            _rawElements = new List<object>();
        }
        
        /// <summary>
        /// Raw regex matches
        /// </summary>
        private List<object> _rawElements;
        
        
        /// <summary>
        /// Raw regex matches
        /// </summary>
        public List<object> RawElements { get => _rawElements; set => _rawElements = value; }
        
        /// <summary>
        /// Game key
        /// </summary>
        public string Key { get; set; }
        
        /// <summary>
        /// Games in day
        /// </summary>
        public List<Game> Games { get; set; }
        
    }
}
