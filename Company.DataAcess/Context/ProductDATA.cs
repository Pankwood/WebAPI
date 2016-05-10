#region Licence
//===================================================================================
// Danilo Debiazi Vicente
//===================================================================================
// Copyright (c) 2016, Danilo Debiazi Vicente  All Rights Reserved.
//===================================================================================
#endregion[

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
            new Product { Id = 1, Name = "Keyboard", IDCategory = 1, Price = 1, Brands = new Brand[]{ new Brand {Id=1, Name="Microsoft"}, new Brand {Id=2, Name="Apple"}, new Brand {Id=2, Name="Amazon"}}},
            new Product { Id = 2, Name = "Mouse", IDCategory = 2, Price = 3.75M, Brands = new Brand[]{ new Brand {Id=1, Name="Microsoft"}, new Brand {Id=2, Name="Apple"}, new Brand {Id=2, Name="Amazon"}}},
            new Product { Id = 3, Name = "Headset", IDCategory = 3, Price = 16.99M, Brands = new Brand[]{new Brand{Id=1, Name="Microsoft"}}} 
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

        public override IEnumerable<Brand> getBrand(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);

            return product.Brands;
        }

        public override IEnumerable<Product> getProductByName(string name)
        {
            var product = products.Where(p => p.Name.Contains(name)).ToList();

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