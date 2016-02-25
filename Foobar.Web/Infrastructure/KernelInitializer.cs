using Foobar.Persistence;
using Foobar.Service.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foobar.Web.Infrastructure
{
    public class KernelInitializer
    {
        public static IKernel Bootstrap()
        {
            IKernel kernel = new StandardKernel();

            kernel
                .Bind<IRepository<Product>, IRepository<Supplier>, IRepository<Category>>()
                .To<DataSources>()
                .WithConstructorArgument(typeof(string), (ctx) => ConfigurationManager.ConnectionStrings["datasource"]?.ConnectionString);

            return kernel;
        }
    }
}
