﻿using log4net;
using Microsoft.VisualBasic.Logging;
using SourceControlFinalAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace SourceControlFinalAssignment.Controllers
{
    public class AccountController : Controller
    {
        private static log4net.ILog Log
        {

            get;

            set;

        }

        ILog log = log4net.LogManager.GetLogger(typeof(AccountController)); //type of class

                       

        private MyDbContext context;

        public AccountController()
        {

            context = new MyDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }
        // GET: Account
        public ActionResult Index()
        {
            if((Session["email"] != null)){
                Session["userinfo"] = context.Users.ToList();

                return View(Session["userinfo"]);
            }
            return View();
        }
        public ActionResult Register()
        {
            User user = new User();
            return View(user);
        }

        [HttpPost]
        public ActionResult Register(User user)
        {

            
                if (!context.Users.Any(m => m.email == user.email))
                {
                    if(user.FileName != null)
                    {
                        string imgName = "user_" + DateTime.Now.ToString("ddMMyyHHmmssfff") + Path.GetExtension(user.FileName.FileName);
                        user.FileName.SaveAs(Path.Combine(Server.MapPath("~/Scripts/UploadedFiles"), imgName));
                        user.Image = "~/Scripts/UploadedFiles" + imgName;
                        context.Users.Add(user);
                        context.SaveChanges();
                        Session["email"] = user.email;
                        return RedirectToAction("Index", "Account");
                    }
                   
                }
                else
                {
                    ModelState.AddModelError("Error", "Email-Id Already Exists!");
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
        public ActionResult Login(LoginModel login)
        {
            log.Debug("Debug message");
            log.Warn("Warn message");
            log.Error("Error message");
            log.Fatal("Fatal message");
            if (ModelState.IsValid)
            {
                if(context.Users.Where(m=>m.email == login.email && m.password == login.password).FirstOrDefault() != null)
                {
                    Session["email"] = login.email.ToString();
                   
                  return RedirectToAction("Index", "Account");
                }
                else
                {
                    ModelState.AddModelError("Error", "Email-Id or Password is not matching");
                    return View();
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }
       



    }
}