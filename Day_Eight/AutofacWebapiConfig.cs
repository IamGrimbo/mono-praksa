using University.Model;
using University.Model.Common;
using University.Repository;
using University.Repository.Common;
using University.Service;
using University.Service.Common;
using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;

namespace University.WebApi.App_start
{
    public class AutofacWebapiConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterModule(new ServiceDIModule());
            builder.RegisterModule(new RepositoryDIModule());
            builder.RegisterModule(new ModelDIModule());

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            Container = builder.Build();

            return Container;

            return Container;
        }
    }
}