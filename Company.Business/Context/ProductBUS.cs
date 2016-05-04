#region Licence
//===================================================================================
// Danilo Debiazi Vicente
//===================================================================================
// Copyright (c) 2016, Danilo Debiazi Vicente  All Rights Reserved.
//===================================================================================
#endregion

#region Referencies
using Company.Business.Entity;
using Company.DataAcess;
using Company.DomainModel;
using System.Collections.Generic;
#endregion

namespace Company.Business.Context
{
    public class ProductBUS : IProductBUS
    {
        /// <summary>Get all products.
        /// <seealso cref="ProductBUS.cs"/>
        /// </summary>
        public override IEnumerable<Product> Get()
        {

            ProductDATA vData = new ProductDATA();

            var product = vData.getProduct();

            return product;

        }

        /// <summary>Get a product by id.
        /// <param name="id"></param>
        /// <seealso cref="ProductBUS.cs"/>
        /// </summary>
        public override Product GetByID(int id)
        {
            ProductDATA vData = new ProductDATA();

            var product = vData.getProductByID(id);

            return product;
        }

        /// <summary>Post a new product.
        /// <param name="pProduct"></param>
        /// <seealso cref="ProductBUS.cs"/>
        /// </summary>
        public override IEnumerable<Product> Post(Product pProduct)
        {
            ProductDATA vData = new ProductDATA();

            var product = vData.postProduct(pProduct);

            return product;
        }

        /// <summary>Update a product by id.
        /// <param name="id"></param>        
        /// <param name="pProduct"></param>
        /// <seealso cref="ProductBUS.cs"/>
        /// </summary>
        public override IEnumerable<Product> Put(int id, Product pProduct)
        {
            ProductDATA vData = new ProductDATA();

            var product = vData.putProduct(id, pProduct);

            return product;
        }

        /// <summary>Delete a product by id.
        /// <param name="id"></param>        
        /// <seealso cref="ProductBUS.cs"/>
        /// </summary>
        public override IEnumerable<Product> Delete(int id)
        {
            ProductDATA vData = new ProductDATA();

            var products = vData.deleteProduct(id);

            return products;
        }
    }
}
