using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowseSharpScraperExamples.NFLScraper.Schedule
{
    public class Day : IRaw
    {
        public Day()
        {
            _rawElements = new List<object>();
        }
        private List<object> _rawElements;
        public List<object> RawElements { get => _rawElements; set => _rawElements = value; }
        public string Key { get; set; }
        public List<Game> Games { get; set; }
        
    }
}
