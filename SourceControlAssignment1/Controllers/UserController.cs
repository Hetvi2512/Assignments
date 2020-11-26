using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Registration_form.Models;

namespace Registration_form.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            userinfo userModel = new userinfo();
            return View(userModel);
        }

        [HttpPost]
        public ActionResult Add(userinfo userModel)
        {
            using(DbModels dbmodel = new DbModels())
            {
                if(dbmodel.userinfoes.Any(x=>x.Email == userModel.Email))
                {
                    ViewBag.DuplicateMessage = "User Name already Exists";
                    return View("Index", userModel);
                }
                dbmodel.userinfoes.Add(userModel);
                dbmodel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successfull";
            return View("Index", new userinfo());
        }
    }
}