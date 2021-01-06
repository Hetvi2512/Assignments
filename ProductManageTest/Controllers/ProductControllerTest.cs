using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductManage.Controllers;
using ProductManage.Controllers.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using System.Web.Mvc;

namespace ProductManageTest.Controllers
{

    [TestClass]
    public class ProductControllerTest
    {
        [TestMethod]
        public void WelcomeTest()
        {
            // Arrange
            ProductController controller = new ProductController();

            // Act
            ViewResult result = controller.Welcome() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DeleteProductTest()
        {
            //Arrange
          
            var controller = new ProductsController();
            //Act
            var result =  controller.DeleteProduct(5);


            //Assert
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
        }
    }
}
