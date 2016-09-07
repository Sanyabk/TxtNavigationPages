using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using TxtNavigationPages.Models;

namespace TxtNavigationPages.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult ViewText(int blocksPerPage = 6, int stringsPerBlock = 3)
        {
			if (blocksPerPage <= 0 || stringsPerBlock <= 0) 
			{
				ViewBag.ErrorMessage = "Parameters can not be negative!";
				return View("_Error", 
					new ViewTextLayoutParameters 
					{
						BlockPerPage = blocksPerPage,
						StringsPerBlock = stringsPerBlock
					}
				);
			}

            var path = HostingEnvironment.MapPath("~/Content/data.txt");
            var strings = FileStringsGetter.GetStrings(path);

            //last parameter is zero to return first page.
            var page = PageBuilder.GetPage(strings, blocksPerPage, stringsPerBlock, 0);
            var pagesCount = PagesCounter.GetPagesCount(strings, blocksPerPage, stringsPerBlock);

            var viewModel = new ViewTextViewModel()
            {
                Page = page,
                PagesCount = pagesCount,
				ViewTextLayoutParameters = new ViewTextLayoutParameters
				{
					BlockPerPage = blocksPerPage,
					StringsPerBlock = stringsPerBlock
				}
            };
            
            return View(viewModel);
        }
    }
}