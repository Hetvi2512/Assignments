using log4net;
using ProductManage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductManage.Controllers
{
    public class HomeController : Controller
    {
        private static log4net.ILog Log
        {
            get;
            set;

        }

        ILog log = log4net.LogManager.GetLogger(typeof(HomeController));

        public ActionResult Index()
        {
            return View();
        }
        private MyDbContext context;

        public HomeController()
        {

            context = new MyDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }


        public ActionResult Register()
        {
            LoginModel user = new LoginModel();
            return View(user);

        }
        [HttpPost]
        public ActionResult Register(LoginModel login)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if (!context.LoginModels.Any(m => m.email == login.email))
                    {
                        context.LoginModels.Add(login);
                        context.SaveChanges();
                        Session["email"] = login.email;
                         Session["name"] = login.userName;
                         log.Info("Registration Successfull for " + Session["email"]);
                        return RedirectToAction("Index", "Product");
                    }

                    else
                    {

                        ModelState.AddModelError("Error", "Email-Id Already Exists!");
                        
                        return View();
                    }
                }
             
            }
            catch (Exception ex)
            {
                log.Info(ex.Message);
                return View();
            }
            return View();
        }

        public ActionResult Login()
        {
            LoginModel login = new LoginModel();
            return View(login);
        }

        [HttpPost]
        public ActionResult Login([Bind(Include ="email,password")]LoginModel login)
        {
            
                log.Debug("Before Login");
                if (context.LoginModels.Where(m => m.email == login.email && m.password == login.password).FirstOrDefault() != null)
                {
                    Session["email"] = login.email;
                  
                    log.Info("Session is set for" + Session["email"]);
                    log.Debug("After Login");
                    return RedirectToAction("Welcome", "Product");
                }
                else
                {
                   log.Warn("Email or password already exists");
                    ModelState.AddModelError("Error", "Email-Id or Password is not matching");
                    return View();
                }
            
         
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            log.Info("Session is unset");
            return RedirectToAction("Login", "Home");
        }

    }
}