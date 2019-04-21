using BusinessLogic;
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
    public class MenuController : Controller
    {
        EFGenericRepository<Product> p_repo = new EFGenericRepository<Product>();
        private ProductLogic p_logic;
        public MenuController()
        {
            p_logic = new ProductLogic(p_repo);
        }
        public static CountryCategories cc = new CountryCategories();
        // GET: Menu
        public ActionResult Menu()
        {

            
            if (cc.virgin == 0 || HomeController.isadmin==true)
            {   cc = new CountryCategories(); 
                List<Product> p_list = p_logic.GetList(a => 1==1).ToList();
            foreach (var item in p_list)
            {
                if (item.Category == "AS") { if (item.Country == "AM") cc.armenia["AS"].Add(item); if (item.Country == "AZ") cc.azerbaidjan["AS"].Add(item); if (item.Country == "GE") cc.georgia["AS"].Add(item); if (item.Country == "IR") cc.iran["AS"].Add(item); }
                if (item.Category == "MC") { if (item.Country == "AM") cc.armenia["MC"].Add(item); if (item.Country == "AZ") cc.azerbaidjan["MC"].Add(item); if (item.Country == "GE") cc.georgia["MC"].Add(item); if (item.Country == "IR") cc.iran["MC"].Add(item); }
                if (item.Category == "SP") { if (item.Country == "AM") cc.armenia["SP"].Add(item); if (item.Country == "AZ") cc.azerbaidjan["SP"].Add(item); if (item.Country == "GE") cc.georgia["SP"].Add(item); if (item.Country == "IR") cc.iran["SP"].Add(item); }
                if (item.Category == "BG") { if (item.Country == "AM") cc.armenia["BG"].Add(item); if (item.Country == "AZ") cc.azerbaidjan["BG"].Add(item); if (item.Country == "GE") cc.georgia["BG"].Add(item); if (item.Country == "IR") cc.iran["BG"].Add(item); }
                if (item.Category == "DS") { if (item.Country == "AM") cc.armenia["DS"].Add(item); if (item.Country == "AZ") cc.azerbaidjan["DS"].Add(item); if (item.Country == "GE") cc.georgia["DS"].Add(item); if (item.Country == "IR") cc.iran["DS"].Add(item); }
                if (item.Category == "BR") { if (item.Country == "AM") cc.armenia["BR"].Add(item); if (item.Country == "AZ") cc.azerbaidjan["BR"].Add(item); if (item.Country == "GE") cc.georgia["BR"].Add(item); if (item.Country == "IR") cc.iran["BR"].Add(item); }
            }
                cc.virgin = 1;
            }
            string MFP = HomeController.MenuFilterPad;
            return View((object)MFP);
        }
        [HttpPost]
        public string SaveMenuFilter(string mfp)
        {
            HomeController.MenuFilterPad = mfp;
            return mfp;
        }
        [HttpPost]
        public string ItemsInCart()
        {
            int iib = HomeController.bsg.ItemsTotal();
           
            return iib.ToString();
        }
        [HttpPost]
        public void  AddToCart(int id, string quantity)
        {
            int iq = Convert.ToInt32(quantity);
            Product p = p_logic.GetList(a => a.Id == id).FirstOrDefault();
            HomeController.bsg.AddRecord(p, iq);
            Record rec = new Record() { Product = p, Quantity = iq };
           
        }
       
            public ActionResult ShowMenu()
        {
            CountryCategories countrycat =cc/* (CountryCategories)Session["CountryCat"]*/;
            //ViewBag.AS = AS;
            if (Request.IsAjaxRequest())
            {

                return PartialView(countrycat);
            }
            return View(countrycat);
        }
        public ActionResult ShowBasket()
        {
            //BasketGroup basketgroup = (BasketGroup)Session["BasketGroup"];

            //ViewBag.AS = AS;
            //if (Request.IsAjaxRequest())
            //{

            //    return PartialView(countrycat);
            //}
            //return View(basketgroup);
            //HomeController.MenuFilterPad = mfp;
            if (Request.IsAjaxRequest())
            {

                return View(HomeController.bsg);
            }
            return View(HomeController.bsg);
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult AddToBasket(int id, string quantity)
        {
            int iq = Convert.ToInt32(quantity);
            //BasketGroup bsg = (BasketGroup)Session["BasketGroup"];
            Product p = p_logic.GetList(a => a.Id == id).FirstOrDefault();
            //HomeController.bsg.AddRecord(p, iq);
            Record rec = new Record() { Product = p, Quantity = iq };
            if (Request.IsAjaxRequest())
            {

                return PartialView(rec);
            }
            return PartialView(rec);
        }

        public ActionResult ItemsInBasket()
        {
            int iib = HomeController.bsg.ItemsTotal();
            if (Request.IsAjaxRequest())
            {

                return PartialView(iib);
            }
            return View(iib);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateQty(int id, string quantity)
        {
            int iq = Convert.ToInt32(quantity);
            Product p = p_logic.GetList(a => a.Id == id).FirstOrDefault();
            HomeController.bsg.UpdateRecord(p,iq);

            //HomeController.bsg.RemoveRecord(p);
            //HomeController.bsg.AddRecord(p, iq);
            return RedirectToAction("ShowBasket");
        }
       
        public ActionResult RemoveFromBasket(string id)
        {
            int iid = Convert.ToInt32(id);
            Product p = p_logic.GetList(a => a.Id == iid).FirstOrDefault();
            HomeController.bsg.RemoveRecord(p);
            return RedirectToAction("ShowBasket");
        }

        public ActionResult CleaUpBasket()
        {
            HomeController.bsg.ClearBasket();
            return RedirectToAction("ShowBasket");
        }
    }
}