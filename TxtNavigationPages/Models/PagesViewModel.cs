using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxtNavigationPages.Models
{
    public class PagesViewModel
    {
        public int blocksPerPage { get; set; }
        public int stringsPerBlock { get; set; }
        public int pageNumber { get; set; }    
    }
}
