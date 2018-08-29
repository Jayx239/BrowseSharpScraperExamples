using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowseSharpScraperExamples.NFLScraper.Schedule
{
    public class Game : IRaw
    {
        public Game()
        {
            _rawElements = new List<object>();
        }
        private List<object> _rawElements;
        public List<object> RawElements { get => _rawElements; set => _rawElements = value; }
        public int GameWeek { get; set; }
        public string FormattedDate { get; set; }
        public string Time { get; set; }
        public string FormattedDateTime { get; set; }
        public string AwayAbbreviation { get; set; }
        public string HomeAbbreviation { get; set; }
        public string AwayName { get; set; }
        public string HomeName { get; set; }
        public string AwayCityName { get; set; }
        public string HomeCityName { get; set; }

    }
}
