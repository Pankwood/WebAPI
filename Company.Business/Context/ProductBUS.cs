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
using Company.DataAcess.Entity;
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
        /// <seealso cref="ProductBUS.cs"/>
        /// </summary>
        /// <param name="id">The ID of the product.</param>
        public override Product GetByID(int id)
        {
            ProductDATA vData = new ProductDATA();

            var product = vData.getProductByID(id);

            return product;
        }

        /// <summary>Get a brand by product.
        /// <seealso cref="ProductBUS.cs"/>
        /// </summary>
        /// <param name="id">The ID of the product.</param>
        public override IEnumerable<Brand> GetBrand(int id)
        {
            ProductDATA vData = new ProductDATA();

            var product = vData.getBrand(id);

            return product;
        }

        /// <summary>Get a product by name.
        /// <seealso cref="ProductBUS.cs"/>
        /// </summary>
        /// <param name="name">The name of the product.</param>
        public override IEnumerable<Product> FindByName(string name)
        {
            ProductDATA vData = new ProductDATA();

            var product = vData.getProductByName(name);

            return product;
        }

        /// <summary>Post a new product.
        /// <seealso cref="ProductBUS.cs"/>
        /// </summary>
        /// <param name="pProduct">The product that you want to input</param>
        public override IEnumerable<Product> Post(Product pProduct)
        {
            ProductDATA vData = new ProductDATA();

            var product = vData.postProduct(pProduct);

            return product;
        }

        /// <summary>Update a product by id.
        /// <seealso cref="ProductBUS.cs"/>
        /// </summary>
        /// <param name="id">The ID of the product.</param>
        /// <param name="pProduct">The product that you want to input</param>
        public override IEnumerable<Product> Put(int id, Product pProduct)
        {
            ProductDATA vData = new ProductDATA();

            var product = vData.putProduct(id, pProduct);

            return product;
        }

        /// <summary>Delete a product by id.
        /// <seealso cref="ProductBUS.cs"/>
        /// </summary>
        /// <param name="id">The ID of the product.</param>
        public override IEnumerable<Product> Delete(int id)
        {
            ProductDATA vData = new ProductDATA();

            var products = vData.deleteProduct(id);

            return products;
        }
    }
}
