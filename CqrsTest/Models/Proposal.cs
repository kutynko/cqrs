using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CqrsTest.Models
{
	public class Proposal
	{
		public int Id { get; set; }
		public string Student { get; set; }
		public List<string> Actions { get; set; }
		public List<string> Reasons { get; set; }
	}
}