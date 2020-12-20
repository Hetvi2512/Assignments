using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Product_Management.Models;
namespace Product_Management.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            var product = new Product()
            {
                product_name = "Product1"
            };
            return View(product);

        }
    }
}