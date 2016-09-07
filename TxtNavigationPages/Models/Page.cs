using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxtNavigationPages.Models
{
    public class Page
    {
        public List<Block> Blocks { get; set; }
        public Page(IEnumerable<string> pageStrings, int stringsPerBlock)
        {
            Blocks = new List<Block>();

			//for division below, not to be int a/int b = 0, if a < b.
			double stringsCount = pageStrings.Count(); 
            var blocksCount = (int)Math.Ceiling(stringsCount / stringsPerBlock);

            for (int i = 0; i < blocksCount; i++)
            {
                Block b = new Block();
                b.Strings = pageStrings.Take(stringsPerBlock).ToList();
                pageStrings = pageStrings.Skip(stringsPerBlock);
                Blocks.Add(b);
            }
        }
    }
}
