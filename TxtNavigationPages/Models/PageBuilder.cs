using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TxtNavigationPages.Models;

namespace TxtNavigationPages.Models
{
    public class PageBuilder
    {
        public static Page GetPage(IEnumerable<string> strings, int blocksPerPage, int stringsPerBlock, int pageNumber)
        {
            int elementToSkipCount = 0;
            int stringsPerPage = stringsPerBlock * blocksPerPage;
            for (int i = 0; i < pageNumber; i++)
            {
                elementToSkipCount += stringsPerPage;
            }

            var pageStrings = strings.Skip(elementToSkipCount).Take(stringsPerPage);
            Page result = new Page(pageStrings, stringsPerBlock);
            return result;
        }
    }
}
