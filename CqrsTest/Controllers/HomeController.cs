using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CqrsTest.Models;

namespace CqrsTest.Controllers
{
    public class HomeController : Controller
    {
		[Route("")]
        public ActionResult Index()
        {
			var data = new ProposalsProjection();

            return View(data.GetProposals());
        }

		[Route("proposal/{id:int?}")]
		public ActionResult Edit(int? id)
		{

			return View();
		}

    }
}
