using Foobar.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;

namespace Foobar.Web.Controllers
{
    public class ProductsController : ODataController
    {
        private readonly IRepository<Product> _productsRepository;

        public ProductsController(
            IRepository<Product> productsRepository)
        {
            Contract.Requires<ArgumentNullException>(productsRepository != null);
                
            _productsRepository = productsRepository;
        }

        [EnableQuery(PageSize = 100)]
        public IQueryable<Product> Get()
        {
            return _productsRepository.Entities;
        }

        [EnableQuery]
        public SingleResult<Product> Get([FromODataUri] int productId)
        {
            return
                SingleResult.Create(
                    _productsRepository
                    .Entities
                    .Where(x => x.Id == productId));
        }
    }
}
