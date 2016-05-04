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

#endregion

namespace Company.DataAcess.Entity
{
    public abstract class IProductData
    {
        public abstract IEnumerable<Product> getProduct();

        public abstract Product getProductByID(int id);


        public abstract IEnumerable<Product> postProduct(Product value);


        public abstract IEnumerable<Product> putProduct(int id, Product value);


        public abstract IEnumerable<Product> deleteProduct(int id);
    }
}
