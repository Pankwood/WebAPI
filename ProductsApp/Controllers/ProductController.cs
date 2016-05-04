#region Licence
//===================================================================================
// Danilo Debiazi Vicente
//===================================================================================
// Copyright (c) 2016, Danilo Debiazi Vicente  All Rights Reserved.
//===================================================================================
#endregion

#region Referencies
using Company.Business.Context;
using Company.DomainModel;
using System.Collections.Generic;
using System.Web.Http;
#endregion

namespace ProductsApp.Controllers
{
    [RoutePrefix("product")]
    public class ProductController : ApiController
    {
        public IEnumerable<Product> Get()
        {
            ProductBUS product = new ProductBUS();

            return product.Get();
        }

        public Product Get(int id)
        {
            ProductBUS product = new ProductBUS();

            return product.GetByID(id);
        }

        public IEnumerable<Product> Post([FromBody]Product pProduct)
        {
            ProductBUS product = new ProductBUS();

            return product.Post(pProduct);
        }

        public IEnumerable<Product> Put(int id, [FromBody]Product pProduct)
        {
            ProductBUS product = new ProductBUS();

            return product.Put(id, pProduct);
        }

        public IEnumerable<Product> Delete(int id)
        {
            ProductBUS product = new ProductBUS();

            return product.Delete(id);
        }
    }
}
