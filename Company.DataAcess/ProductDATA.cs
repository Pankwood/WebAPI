#region Licence
//===================================================================================
// Danilo Debiazi Vicente
//===================================================================================
// Copyright (c) 2016, Danilo Debiazi Vicente  All Rights Reserved.
//===================================================================================
#endregion

#region Referencies
using Company.DomainModel;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace Company.DataAcess
{
    public class ProductDATA
    {
        Product[] products = new Product[] 
        { 
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 }, 
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M }, 
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M } 
        };

        public IEnumerable<Product> getProduct()
        {
            return products;
        }

        public Product getProductByID(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);

            return product;
        }

        public IEnumerable<Product> postProduct(Product pValue)
        {
            Product product = new Product();
            product.Id = pValue.Id;
            product.Name = pValue.Name;
            product.Category = pValue.Category;
            product.Price = pValue.Price;

            return products.Concat(new Product[] { product });
        }

        public IEnumerable<Product> putProduct(int id, Product pValue)
        {
            var productList = products.ToList();

            productList.Remove(products.FirstOrDefault((p) => p.Id == id));

            pValue.Id = id;

            Product product = new Product();
            product.Id = pValue.Id;
            product.Name = pValue.Name;
            product.Category = pValue.Category;
            product.Price = pValue.Price;

            return productList.Concat(new Product[] { product });
        }

        public IEnumerable<Product> deleteProduct(int id)
        {
            var productList = products.ToList();

            productList.Remove(products.FirstOrDefault((p) => p.Id == id));

            return productList;
        }
    }
}