using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ProductManage
{
    public class MyDbContext:DbContext
    {
        public virtual DbSet<ProductManage.Models.ProductInfo> ProductInfos { get; set; }
        public virtual DbSet<ProductManage.Models.LoginModel> LoginModels { get; set; }
    }
}