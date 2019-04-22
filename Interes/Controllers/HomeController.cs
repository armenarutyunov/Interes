//using DBMOD;
using Interes.Models;
//using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Web;
using System.Web.Mvc;
//using System.Web.Mvc.Html;
//using System.Web.Routing;

namespace Interes.Controllers
{
    public class HomeController : Controller
    {
        //public static MenuData menudata = new MenuData();
        public static bool isadmin = false;
        public static BasketGroup bsg = new BasketGroup();
        public static string MenuFilterPad = "nnnnnnnnnnnn";
        public static string[] customer = new string[] {"1", null, null, null, "1", null, null, null};
        public static List<string> addresses = new List<string>() { " -- Your Previous Addresses --" };
        //public MenuData MD { get { return menudata; } }
        //public void AdminStat(bool q)
        //{
        //    menudata.IsAdmin = q;
        //}
        public ActionResult Index()
        {
            
            //BasketGroup basketgroup = new BasketGroup();
            //Session["BasketGroup"] = basketgroup;
            Session["IsSigned"] = (bool)false;
            //TempData["IsAdmin"] = (bool)false;
            //TempData.Keep("IsAdmin");
            return RedirectToAction("Home");
        }
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult HIW()
        {
            ViewBag.Message = "How To Create Your First Order!";
            return View();
        }

        public ActionResult Message()
        {
            ViewBag.Message = (string)TempData["Message"];
            return View();
        }
        //[HttpGet]
        //[ChildActionOnly]
        public ActionResult NavForStart()
        {
            //ModelState.Clear();
            try
            {

                MenuData md = new MenuData { bsg = HomeController.bsg, IsAdmin = isadmin, Customer = customer };
                return PartialView(md);
            }
            catch
            {
                TempData["Message"] = "Sorry, due to big delay, we had to sign you out!";
            }
            return RedirectToAction("Message");
        }
        //[HttpGet]
        public ActionResult NavForMenu()
        {

            try
            {
                MenuData md = new MenuData { bsg = HomeController.bsg, IsAdmin = isadmin, Customer = customer };
                if (Request.IsAjaxRequest())
                {

                    return PartialView(md);
                }
                
                return View(md);
            }
            catch
            {
                TempData["Message"] = "Sorry, due to big delay, we had to sign you out!";
            }
            return RedirectToAction("Message");
        }
        //[HttpGet]
        public ActionResult NavForBasket()
        {

            try
            {
                MenuData md = new MenuData { bsg = HomeController.bsg, IsAdmin = isadmin, Customer = customer };
                return View(md);
            }
            catch
            {
                TempData["Message"] = "Sorry, due to big delay, we had to sign you out!";
            }
            return RedirectToAction("Message");
        }
        //[HttpGet]
        public ActionResult NavForCheckout()
        {

            try
            {
                MenuData md = new MenuData { bsg = HomeController.bsg, IsAdmin = isadmin, Customer = customer };
                return View(md);
            }
            catch
            {
                TempData["Message"] = "Sorry, due to big delay, we had to sign you out!";
            }
            return RedirectToAction("Message");
        }
    }
}