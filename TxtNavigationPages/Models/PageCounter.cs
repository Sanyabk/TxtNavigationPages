using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxtNavigationPages.Models
{
    public class PagesCounter
    {
        public static int GetPagesCount(IEnumerable<string> strings, int blocksPerPage, int stringsInBlock)
        {
            double stringsCount = strings.Count();
			var blocksCount = Math.Ceiling(stringsCount / stringsInBlock);
			var pagesCount = Math.Ceiling(blocksCount / blocksPerPage);

            return (int)Math.Ceiling(pagesCount);
        }
    }
}
