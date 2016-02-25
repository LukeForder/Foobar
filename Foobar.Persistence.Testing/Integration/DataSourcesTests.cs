using Foobar.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Foobar.Persistence.Testing.Integration
{
    public class DataSourcesTests
    {
        const string connectionString = @"
            Data Source=.\SQLEXPRESS;
            Initial Catalog=northwind;
            Integrated Security=True;
            MultipleActiveResultSets=True";

        [Fact] public async Task it_can_fetch_products()
        {
            IRepository<Product> repository = new DataSources(connectionString);
            
            var products =
                await
                    repository
                        .Entities
                        .ToListAsync();

            
        }

        [Fact]
        public async Task it_can_fetch_suppliers()
        {
            IRepository<Supplier> repository = new DataSources(connectionString);

            var suppliers =
                await
                    repository
                        .Entities
                        .ToListAsync();


        }

        [Fact]
        public async Task it_can_fetch_categories()
        {
            IRepository<Category> repository = new DataSources(connectionString);

            var categories =
                await
                    repository
                        .Entities
                        .ToListAsync();


        }
    }
}
