#region Licence
//===================================================================================
// Danilo Debiazi Vicente
//===================================================================================
// Copyright (c) 2016, Danilo Debiazi Vicente  All Rights Reserved.
//===================================================================================
#endregion

#region Referencies
using System;
using System.Collections.Generic;
#endregion

namespace Company.DomainModel
{
    public class Product
    {
        public Product()
        {
            DateAcquired = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            isActive = true;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int IDCategory { get; set; }
        public virtual Category Category { get; set; }
        public decimal Price { get; set; }
        public DateTime DateAcquired { get; set; }
        public bool isActive { get; set; }
        public ICollection<Brand> Brands { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
