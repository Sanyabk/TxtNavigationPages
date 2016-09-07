using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TxtNavigationPages.Models;
using System.Web.Hosting;

namespace TxtNavigationPages.Controllers
{
    public class PagesController : ApiController
    {
		[Route("api/pages")]
		public IHttpActionResult Get([FromUri]PagesViewModel viewModel)
        {
			//pages are zero-based and it CAN be equal zero
			if (viewModel.blocksPerPage <= 0 || 
				viewModel.stringsPerBlock <= 0 || 
				viewModel.pageNumber < 0) 
			{
				return BadRequest("Parameters can not be negative!");
			}

			var path = HostingEnvironment.MapPath("~/Content/data.txt");
            var strings = FileStringsGetter.GetStrings(path);

            var page = PageBuilder.GetPage(
				strings, viewModel.blocksPerPage, 
				viewModel.stringsPerBlock, viewModel.pageNumber);
            return Json(page);
        }
    }
}
