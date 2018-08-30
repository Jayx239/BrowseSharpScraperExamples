using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowseSharpScraperExamples.NFLScraper.Schedule
{
    /// <summary>
    /// An object built from regex match objects
    /// </summary>
    public interface IRaw
    {
        /// <summary>
        /// Regex match objects
        /// </summary>
        List<Object> RawElements { get; set; }
    }
}
