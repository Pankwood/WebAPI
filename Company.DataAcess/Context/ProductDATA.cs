﻿#region Licence
//===================================================================================
// Danilo Debiazi Vicente
//===================================================================================
// Copyright (c) 2016, Danilo Debiazi Vicente  All Rights Reserved.
//===================================================================================
#endregion

#region Referencies
using Company.DataAcess.Entity;
using Company.DomainModel;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace Company.DataAcess
{
    public class ProductDATA : IProductData
    {
        Product[] products = new Product[] 
        { 
            new Product { Id = 1, Name = "Tomato Soup", IDCategory = 1, Price = 1 }, 
            new Product { Id = 2, Name = "Yo-yo", IDCategory = 2, Price = 3.75M }, 
            new Product { Id = 3, Name = "Hammer", IDCategory = 3, Price = 16.99M } 
        };

        public override IEnumerable<Product> getProduct()
        {
            return products;
        }

        public override Product getProductByID(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);

            return product;
        }

        public override IEnumerable<Product> postProduct(Product pValue)
        {
            Product product = new Product();
            product.Id = pValue.Id;
            product.Name = pValue.Name;
            product.IDCategory = pValue.IDCategory;
            product.Price = pValue.Price;

            return products.Concat(new Product[] { product });
        }

        public override IEnumerable<Product> putProduct(int id, Product pValue)
        {
            var productList = products.ToList();

            productList.Remove(products.FirstOrDefault((p) => p.Id == id));

            pValue.Id = id;

            Product product = new Product();
            product.Id = pValue.Id;
            product.Name = pValue.Name;
            product.IDCategory = pValue.IDCategory;
            product.Price = pValue.Price;

            return productList.Concat(new Product[] { product });
        }

        public override IEnumerable<Product> deleteProduct(int id)
        {
            var productList = products.ToList();

            productList.Remove(products.FirstOrDefault((p) => p.Id == id));

            return productList;
        }
    }
}