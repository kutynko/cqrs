using System.Collections.Generic;
using System.IO;
using System.Web.Hosting;
using Newtonsoft.Json;

namespace CqrsTest.Models
{
	public class ProposalsProjection
	{
		private readonly List<Proposal> _proposals = new List<Proposal>();
		private readonly DirectoryInfo _store;

		public ProposalsProjection()
		{
			var storePath = HostingEnvironment.MapPath("~/App_Data/Proposals");
			_store = new DirectoryInfo(storePath);
			if (!_store.Exists)
			{
				_store.Create();
			}
		}

		public List<Proposal> GetProposals()
		{
			var result = new List<Proposal>();
			var serializer = new JsonSerializer();
			foreach (var proposal in _store.GetFiles())
			{
				using (var reader = proposal.OpenRead())
				{
					using (var text = new JsonTextReader(new StreamReader(reader)))
					{
						result.Add(serializer.Deserialize<Proposal>(text));
					}
				}
			}
			return result;
		}

		public void SaveProposal(Proposal data)
		{
			using (var writer = File.OpenWrite(Path.Combine(_store.FullName, data.Id.ToString())))
			{
				using (var text = new JsonTextWriter(new StreamWriter(writer)))
				{
					var serializer = new JsonSerializer();
					serializer.Serialize(text, data);
				}
			}
		}
	}
}