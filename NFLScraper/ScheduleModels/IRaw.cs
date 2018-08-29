using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowseSharpScraperExamples.NFLScraper.Schedule
{
    public interface IRaw
    {
        List<Object> RawElements { get; set; }
    }
}
