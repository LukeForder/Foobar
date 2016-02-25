using Foobar.Service.Interfaces;
using Microsoft.Owin.Hosting;
using Simple.OData.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Foobar.Web.Testing.Integration
{
    public class ProductControllerTests
    {
        [Fact]
        public async Task it_hosts_a_odata_product_controller()
        {
            const string url = "http://localhost:9871";

            using (WebApp.Start<Foobar.Web.Infrastructure.StartUp>(url))
            {
                var client = 
                    new ODataClient(url)
                        .For<Product>()
                        .Expand(x => x.Supplier)
                        .Expand(x => x.Category);

                var annotations = new ODataFeedAnnotations();

                var allProducts = new List<Product>();

                do
                {
                    var entries =
                        annotations.NextPageLink != null
                        ? await client.FindEntriesAsync(annotations.NextPageLink, annotations)
                        : await client.FindEntriesAsync(annotations);

                    allProducts.AddRange(entries);
                }
                while (annotations.NextPageLink != null);

                Assert.NotEmpty(allProducts);
                    
            }

        }
    }
}
