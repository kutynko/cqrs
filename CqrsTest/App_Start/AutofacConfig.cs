using System;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using CqrsTest.Models;

namespace CqrsTest
{
	public static class AutofacConfig
	{
		public static void Register()
		{
			var builder = new ContainerBuilder();
			builder.RegisterControllers(AppDomain.CurrentDomain.GetAssemblies());
			builder.RegisterInstance(new ProposalsProjection());

			DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
		}
	}
}