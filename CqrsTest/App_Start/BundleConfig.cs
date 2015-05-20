using System.Web;
using System.Web.Optimization;

namespace CqrsTest
{
	public class BundleConfig
	{
		// For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
						"~/Scripts/jquery-{version}.js",
						"~/Scripts/jquery.unobtrusive*",
						"~/Scripts/jquery.validate*"));

			bundles.Add(new StyleBundle("~/Content/proposals").Include("~/Content/site.css", "~/Content/proposals.css"));

		}
	}
}