using System.Collections.Generic;
using System.Web.Http;
using BLL;

namespace Course_Work_Internet_Shop.Controllers
{
    /// <summary>
    /// Контроллер товаров
    /// </summary>
    public class ProductController : ApiController
    {
        // GET: api/Product
        public IEnumerable<MProduct> Get()
        {
            ProductActions p1 = new ProductActions();
            return p1.GetProducts();
        }

        // GET: api/Product/5
        public MProduct Get(int id)
        {
            ProductActions p1 = new ProductActions();
            return p1.GetProductById(id);
        }

        // POST: api/Product
        [HttpPost]
        public void Post([FromBody]MProduct mProduct)
        {
            ProductActions p1 = new ProductActions();
            p1.AddProduct(mProduct);
        }

        // PUT: api/Product/5
        [HttpPut]
        public void Put(int id, [FromBody]MProduct value)
        {
            ProductActions p1 = new ProductActions();
            p1.ChangeProduct(value);
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
            ProductActions p1 = new ProductActions();

            p1.DeleteProductByID(id);
        }
    }
}
