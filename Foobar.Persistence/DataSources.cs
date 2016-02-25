using Foobar.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foobar.Persistence
{
    public class DataSources : 
        DbContext,
        IRepository<Supplier>,
        IRepository<Product>,
        IRepository<Category>
    {
        public DataSources(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Contract.Requires<ArgumentNullException>(nameOrConnectionString != null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);            
        }

        IQueryable<Category> IRepository<Category>.Entities
        {
            get
            {
                return Set<Category>();
            }
        }

        IQueryable<Product> IRepository<Product>.Entities
        {
            get
            {
                return
                    Set<Product>()
                    .Include(x => x.Category)
                    .Include(x => x.Supplier);
            }
        }

        IQueryable<Supplier> IRepository<Supplier>.Entities
        {
            get
            {
                return
                    Set<Supplier>();
            }
        }
    }
}
