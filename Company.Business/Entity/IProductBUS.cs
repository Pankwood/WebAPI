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
#endregion

namespace Company.Business.Entity
{
    public abstract class IProductBUS
    {
        public abstract IEnumerable<Product> Get();


        public abstract Product GetByID(int id);


        public abstract IEnumerable<Product> Post(Product value);


        public abstract IEnumerable<Product> Put(int id, Product value);


        public abstract IEnumerable<Product> Delete(int id);
    }
}
