using Foobar.Service.Interfaces;
using Microsoft.Owin;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

[assembly: OwinStartup(typeof(Foobar.Web.Infrastructure.StartUp))]

namespace Foobar.Web.Infrastructure
{
    public class StartUp
    {
        public void Configuration(IAppBuilder app)
        {
            var configuration = new HttpConfiguration();
            
            var builder = new ODataConventionModelBuilder();

            builder.EntitySet<Product>("Products");

            configuration.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: null,
                model: builder.GetEdmModel());
            
            app.UseNinjectMiddleware(KernelInitializer.Bootstrap).UseNinjectWebApi(configuration);

        }
    }
}
