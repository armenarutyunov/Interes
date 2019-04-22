﻿using BusinessLogic;
using DBMOD;
using EntityFrameworkDataAccess;
using Interes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interes.Controllers
{
    public class LoginController : Controller
    {
       
        EFGenericRepository<Security_Logins> sl_repo = new EFGenericRepository<Security_Logins>();
        private Security_LoginsLogic sl_logic;
        EFGenericRepository<Customer> cm_repo = new EFGenericRepository<Customer>();
        private CustomerLogic cm_logic;
        RestaurantEntities re = new RestaurantEntities();
        public LoginController()
        {
            sl_logic = new Security_LoginsLogic(sl_repo);
            cm_logic = new CustomerLogic(cm_repo);

        }
        // GET: Login
        public ActionResult Admin()
        {
            try
            {

                if(HomeController.isadmin==false)
                {
                    TempData["Message"] = "To Visit This Page You Need To Sign As Administrator!";
                    return RedirectToAction("Message");
                };
                return View();
            }
            catch
            {
                TempData["Message"] = "To Visit This Page You Need To Sign In First!";
               
            }

            return RedirectToAction("Message");
        }
        public ActionResult AdminSignOut()
        {
            HomeController.isadmin = false;
            HomeController.bsg.ClearBasket();
            return RedirectToAction("Home", "Home");
        }
        public ActionResult Message()
        {
            ViewBag.Message = (string)TempData["Message"];
            return View();
        }
        //public ActionResult AdminSignOut()
        //{
        //    Session["IsAdmin"] = false;
        //    return RedirectToAction("Home", "Home", new { q = false });
        //}
        public ActionResult Login()
        {
            LoginData ld = new LoginData();
            return View(ld);
        }
        public ActionResult Logout()
        {
            HomeController.bsg = new BasketGroup();
            HomeController.MenuFilterPad = "nnnnnnnnnnnn";
            HomeController.customer = new string[] { "1", null, null, null, "1", null, null, null };
            HomeController.addresses = new List<string>() { " -- Your Previous Addresses --" };
            return RedirectToAction("Home", "Home");


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Login(string email, string password)
        //{
        ////////////////////////////////////////////////////////////////////////
        public ActionResult Login(LoginData loginData)
        {
            string email = loginData.Email; string password = loginData.Password;
            ///////////////////////////////////////////////////////////////////////


            TempData["Message"] = "Sorry, something went wrong! Please, doublecheck your credentials and try again";
            if (ModelState.IsValid)
            {
                Session["IsSignedIn"] = false;
              
                ViewBag.HasAccount = false;
               
                if(email=="admin@admin.com" && password == "admin")
                {

                    HomeController.isadmin = true;
                    return RedirectToAction("Admin");
                }
                 var loglist = sl_logic.GetAll();
                foreach (var item in loglist)
                {
                    if (email == item.Email && password== item.Password)
                    {
                        Session["SecurityLoginID"] = item.Id;
                        Session["IsSignedIn"] = true;
                        ViewBag.HasAccount = true;
                        ViewBag.Status = "Logged";

                        //int SecLogId = item.Id;
                        Customer cus = cm_logic.GetList(a => a.Security_Login_Id == item.Id).FirstOrDefault();

                        HomeController.customer[0] = cus.Id.ToString();
                        HomeController.customer[1] = cus.FirstName;
                        HomeController.customer[2] = cus.LastName;
                        HomeController.customer[3] = cus.Phone;
                        HomeController.customer[4] = item.Id.ToString();
                        HomeController.customer[5] = item.Email;
                        HomeController.customer[6] = item.Password;

                        return RedirectToAction("Home", "Home");
                        //return RedirectToAction("Index","Home", new { q = true });
                    }
                }

                return RedirectToAction("Message","Home");
            }

            return RedirectToAction("Message", "Home");

        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(SignUpData signUpData/*string FN, string LN, string CP, string EA, string PW*/)
        {
            string FN = signUpData.FirstName; string LN = signUpData.LastName; string CP = signUpData.Phone;
            string EA = signUpData.Email; string PW = signUpData.Password;

            Security_Logins sl = new Security_Logins();
            //int maxId = re.Security_Logins.Select(x => x.Id).DefaultIfEmpty(9999).Max();
            //sl.Id = maxId + 1;
            sl.Email = EA;
            sl.Password = PW;
            sl.RegistrationDate = DateTime.Now.ToString();
            Security_Logins[] sllist = new Security_Logins[] { sl };
            sl_logic.Add(sllist);
            int maxId = re.Security_Logins.Select(x => x.Id).DefaultIfEmpty(0).Max();
            Customer cm = new Customer();
            cm.FirstName = FN;
            cm.LastName = LN;
            cm.Phone = CP;
            //cm.Security_Login_Id = sl.Id;
            cm.Security_Login_Id = maxId;
            Customer[] cmlist = new Customer[] { cm };
            cm_logic.Add(cmlist);
            TempData["Message"] = "Congratulations, you have registered successfully!";
            return RedirectToAction("Message");
        }
        //public ActionResult CusPage()
        //{
        //    OrderDetails bg = new OrderDetails();
        //    bg.Name = HomeController.customer[0];
        //    bg.Phone = HomeController.customer[1];
        //    bg.Email = HomeController.customer[2];
        //    int cusid = Convert.ToInt32(HomeController.customer[3]);

        //    List<Order> od_list = o_logic.GetList(a => a.CustomerId == cusid).ToList();
        //    //List<Order> od_list = od_logic.GetList(a => a.CustomerId == cusid).ToList();
        //    HomeController.addresses = new List<string>() { " -- Your Previous Addresses --" };
        //    if (cusid != 1)
        //    {
        //        foreach (var rec in od_list)
        //        {
        //            HomeController.addresses.Add(rec.Street + ", " + rec.UnitNumber + ", " + rec.City + ", " + rec.PostalCode);
        //        }
        //    }
        //    bg.Addresses = HomeController.addresses.Distinct().ToList();
        //    bg.DeliveryDate = DateTime.Now.AddDays(1).Date;
        //    bg.DeliveryTime = DateTime.Now.AddHours(12);
        //    return View(bg);
        //}
        public ActionResult CustPage()
        {
            SignUpData sud = new SignUpData();
            sud.FirstName = HomeController.customer[1];
            sud.LastName = HomeController.customer[2];
            sud.Phone = HomeController.customer[3];
            sud.Email = HomeController.customer[5];
            
            return View(sud);
        }
    }
} 