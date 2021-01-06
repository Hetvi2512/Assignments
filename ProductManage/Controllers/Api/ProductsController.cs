using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using AutoMapper;
using ProductManage.Dtos;
using ProductManage.Models;


namespace ProductManage.Controllers.Api
{
   
    public class ProductsController : ApiController
    {
        private MyDbContext context;
        public ProductsController()
        {
            context = new MyDbContext();
        }
        // GET /api/products
        public IEnumerable<ProductDto> GetProducts()

        {
            return context.ProductInfos.ToList().Select(Mapper.Map<ProductInfo, ProductDto>);
        }

        // GET /api/products/1
        public HttpResponseMessage GetProduct(int id)
        {
            try
            {
                var product = context.ProductInfos.SingleOrDefault(C => C.product_Id == id);
                if (product == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,"Product does not Exist");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<ProductInfo, ProductDto>(product));
                }
               
                //return Ok(Mapper.Map<ProductInfo, ProductDto>(product));
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
           
        }

        //POST api/products

            [HttpPost]
        public IHttpActionResult CreateProduct(ProductDto productdto)
        {
           
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var product = Mapper.Map<ProductDto, ProductInfo>(productdto);
           
           context.ProductInfos.Add(product);
           context.SaveChanges();
            productdto.product_Id = product.product_Id;
            return Created(new Uri(Request.RequestUri + "/" + product.product_Id), productdto);

        }

        [HttpPut]
        //PUT api/products/1
        public HttpResponseMessage UpdateProduct(int id, ProductDto productdto)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,"State not valid");
            }
            try
            {
                var productInDb = context.ProductInfos.SingleOrDefault(C => C.product_Id == id);
                if (productInDb == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product does not Exist");

                }
                else
                {
                    Mapper.Map(productdto, productInDb);
                    context.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map(productdto, productInDb));
                }
              
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

          
            
        }


        //DELETE  /api/products/1
        [HttpDelete]
        public HttpResponseMessage DeleteProduct(int id)
        {
               var productInDb = context.ProductInfos.SingleOrDefault(C => C.product_Id == id);
                if (productInDb == null)
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
                else
                {
                    context.ProductInfos.Remove(productInDb);

                    context.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                
           
          /*  catch(Exception ex)
            {

                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            */
        
            
        }
    }
}
