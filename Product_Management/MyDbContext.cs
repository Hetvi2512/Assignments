using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Product_Management
{
    public class MyDbContext: DbContext
    {
        public virtual DbSet<Product_Management.Models.Product> ProductsInfo { get; set; }

    }
}