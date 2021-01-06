 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductManage.Models;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Net.Http;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
using log4net;

namespace ProductManage.Controllers
{


    public class ProductController : Controller
    {
        private MyDbContext context;

        public ProductController()
        {

            context = new MyDbContext();
        }
        private static log4net.ILog Log
        {

            get;

            set;

        }

        ILog log = log4net.LogManager.GetLogger(typeof(HomeController)); //type of class

        public ViewResult Welcome()
        {
            return View();
        }

        // GET: Product
        public ViewResult Index()
        {
            //if we want to add functionality without API
            /* var products = context.ProductInfos.ToList(); */


            IEnumerable<ProductInfo> productlist;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("products").Result;
            productlist = response.Content.ReadAsAsync<IEnumerable<ProductInfo>>().Result;

            return View(productlist);
        }

        public ActionResult New(int id = 0)
        {
            if (id == 0)
            { return View(new ProductInfo()); }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("products/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<ProductInfo>().Result);

            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ProductInfo productInfo)
        {
            if (!ModelState.IsValid)
            {
                return View("New");
            }
            if (productInfo.product_Id == 0)
            {
                //if we want to add functionality without API
                // context.ProductInfos.Add(productInfo);

                // setting imagename and getting imagepath
                string imgName = "productInfo_" + productInfo.product_name + DateTime.Now.ToString("ddMMyyHHmmssfff") + Path.GetExtension(productInfo.ImageFile.FileName);
                productInfo.ImageFile.SaveAs(Path.Combine(Server.MapPath("~/Images/Smallimages"), imgName));
                productInfo.ImagePath = "~/Images/Smallimages/" + imgName;

                string bigImgName = "productInfobig_" + productInfo.product_name + DateTime.Now.ToString("ddMMyyHHmmssfff") + Path.GetExtension(productInfo.BigImageFile.FileName);
                productInfo.BigImageFile.SaveAs(Path.Combine(Server.MapPath("~/Images/BigImages"), bigImgName));
                productInfo.BigImagePath = "~/Images/BigImages/" + bigImgName;
                log.Info("Product" + productInfo.product_name + "saved by " + Session["email"]);

                //  Sends a POST request as an asynchronous operation to the specified Uri with the given value serialized as JSON.
                //Uri specified in globalsvariables. 
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("products", productInfo).Result;
                TempData["SuccessMesssage"] = "Product Saved Successfully";


            }
            else
            {
                //if we are updating the image
                if (productInfo.ImageFile != null)
                {
                    string imgName = "productInfo_" + DateTime.Now.ToString("ddMMyyHHmmssfff") + Path.GetExtension(productInfo.ImageFile.FileName);
                    productInfo.ImageFile.SaveAs(Path.Combine(Server.MapPath("~/Images/Smallimages"), imgName));
                    productInfo.ImagePath = "~/Images/Smallimages/" + imgName;

                }

                if (productInfo.BigImageFile != null)
                {
                    string bigImgName = "productInfobig_" + DateTime.Now.ToString("ddMMyyHHmmssfff") + Path.GetExtension(productInfo.BigImageFile.FileName);
                    productInfo.BigImageFile.SaveAs(Path.Combine(Server.MapPath("~/Images/BigImages"), bigImgName));
                    productInfo.BigImagePath = "~/Images/BigImages/" + bigImgName;

                }
                log.Info("Product" + productInfo.product_name + "updated by " + Session["email"]);
                //Sends a PUT request as an asynchronous operation to the specified Uri with the given value serialized as JSON.
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("products/" + productInfo.product_Id, productInfo).Result;
                TempData["SuccessMesssage"] = "Product Updated Successfully";
            }

            // context.SaveChanges();


            return RedirectToAction("Index", "Product");

        }

        public ActionResult Delete(int id)
        {
            //Send a DELETE request to the specified Uri as an asynchronous operation.
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("products/" + id.ToString()).Result;

            TempData["SuccessMesssage"] = "Product Deleted Successfully";
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("products/" + id.ToString()).Result;
            return View(response.Content.ReadAsAsync<ProductInfo>().Result);

        }


        //to remove multiple items 
        [HttpPost]
        public ActionResult DeleteAll(int[] deleteItemIDs)
        {
            try
            {
                foreach (int deleteItemID in deleteItemIDs)
                {
                    var itemdelete = context.ProductInfos.Where(p => p.product_Id == deleteItemID).Single();
                    context.ProductInfos.Remove(itemdelete);
                }
                context.SaveChanges();
                TempData["SuccessMesssage"] = "Product Deleted Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                log.Error("Problem occured in deleting multiple item", ex);
                TempData["ErrorMessage"] = "Please select products first";
                return RedirectToAction("Index");
            }
        }
    }
}