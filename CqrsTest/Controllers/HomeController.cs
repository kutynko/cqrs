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
		private readonly ProposalsProjection _data;

		public HomeController(ProposalsProjection data)
		{
			_data = data;
		}

		[Route("")]
		public ActionResult Index()
		{
			return View(_data.GetProposals());
		}

		[Route("proposal/{id:int}")]
		public ActionResult Edit(int id)
		{
			return View(_data.GetProposals().First(p => p.Id == id));
		}

		[Route("proposal/")]
		public ActionResult Add()
		{
			return View();
		}


		[HttpPost]
		[Route("proposal/{id:int}")]
		public ActionResult Edit(int id, string student, string actions, string reasons)
		{
			var proposal = _data.GetProposals().First(p => p.Id == id);

			proposal.Student = student;
			proposal.Actions = actions.Split(',').Select(s => s.Trim()).ToList();
			proposal.Reasons = reasons.Split(',').Select(s => s.Trim()).ToList();

			_data.SaveProposal(proposal);

			return RedirectToAction("Index");
		}

		[HttpPost]
		[Route("proposal/")]
		public ActionResult Add(string student, string actions, string reasons)
		{
			var proposal = new Proposal
			{
				Id = (int)DateTime.Now.Ticks,
				Student = student,
				Actions = actions.Split(',').Select(s => s.Trim()).ToList(),
				Reasons = reasons.Split(',').Select(s => s.Trim()).ToList(),
			};

			_data.SaveProposal(proposal);

			return RedirectToAction("Index");
		}
	}
}
