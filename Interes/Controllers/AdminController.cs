using BusinessLogic;
using DBMOD;
using EntityFrameworkDataAccess;
using Interes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Interes.Controllers
{
    public class AdminController : Controller
    {
        EFGenericRepository<Product> p_repo = new EFGenericRepository<Product>();
        private ProductLogic p_logic;
        public AdminController()
        {
            p_logic = new ProductLogic(p_repo);
        }
        public static ProductsCategories procat = new ProductsCategories();
        // GET: Admin

        public ActionResult ShowProducts()
        {
            //ProductsCategories procat = (ProductsCategories)Session["procat"];
            return View(procat);
        }
        public ActionResult Products()
        {
            //ProductsCategories pc = new ProductsCategories();
            procat = new ProductsCategories();
            List<Product> p_list = p_logic.GetList(a=>1==1).ToList();
            foreach(var item in p_list)
            {
                if (item.Category == "AS") { procat.AppetizersSalads.Add(item); }
                if (item.Category == "MC") { procat.MainCourses.Add(item); }
                if (item.Category == "SP") { procat.Soups.Add(item); }
                if (item.Category == "BG") { procat.Beverages.Add(item); }
                if (item.Category == "DS") { procat.Desserts.Add(item); }
                if (item.Category == "BR") { procat.Breads.Add(item); }
            }
           
            //Session["procat"] = pc;
            return RedirectToAction("ShowProducts");
        }
        public ActionResult Customers()
        {
            return View();
        }
        public ActionResult Orders()
        {
            return View();
        }
        public ActionResult SecurityLogins()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProduct([Bind(Include = "product")] ProductsCategories pc, string category)
             //, string AS = "N", string MC = "N", string SP = "N", string BG = "N", string DS = "N", string BR = "N", string AL = "N")
        {
            Product p = new Product()
            {

                ProductTitle = pc.product.ProductTitle,
                NativeTitle = pc.product.NativeTitle,
                ImageSrc = pc.product.ImageSrc,
                Category = category,
                SubCategory = pc.product.SubCategory,
                Country = pc.product.Country,
                PortionWeight = pc.product.PortionWeight,
                CaloriesPer100g = pc.product.CaloriesPer100g,
                PortionPrice = pc.product.PortionPrice,
                MainComponents = pc.product.MainComponents,
                CookingRecipe = pc.product.CookingRecipe
            };

            Product[] plist = new Product[]{p}; p_logic.Add(plist);
            //pc = (ProductsCategories)Session["procat"];
            if (category == "AS") { procat.AppetizersSalads.Add(p); }
            if (category == "MC") { procat.MainCourses.Add(p); }
            if (category == "SP") { procat.Soups.Add(p); }
            if (category == "BG") { procat.Beverages.Add(p); }
            if (category == "DS") { procat.Desserts.Add(p); }
            if (category == "BR") { procat.Breads.Add(p); }
            procat.product = new Product();

            //if (AS == "Y") { pc.AdminFilterState["AS"] = "checked"; } else { pc.AdminFilterState["AS"] = ""; }
            //if (MC == "Y") { pc.AdminFilterState["MC"] = "checked"; } else { pc.AdminFilterState["MC"] = ""; }
            //if (SP == "Y") { pc.AdminFilterState["SP"] = "checked"; } else { pc.AdminFilterState["SP"] = ""; }
            //if (BG == "Y") { pc.AdminFilterState["BG"] = "checked"; } else { pc.AdminFilterState["BG"] = ""; }
            //if (DS == "Y") { pc.AdminFilterState["DS"] = "checked"; } else { pc.AdminFilterState["DS"] = ""; }
            //if (BR == "Y") { pc.AdminFilterState["BR"] = "checked"; } else { pc.AdminFilterState["BR"] = ""; }
            //if (AL == "Y") { pc.AdminFilterState["AL"] = "checked"; } else { pc.AdminFilterState["AL"] = ""; }

            //Session["procat"] = pc;
            return RedirectToAction("ShowProducts");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateProduct([Bind(Include = "product")] ProductsCategories pc, string category) 
            //,string AS = "N", string MC = "N", string SP = "N", string BG = "N", string DS = "N", string BR = "N", string AL = "N")
        {
            Product p = new Product()
            {
                Id = pc.product.Id,
                ProductTitle = pc.product.ProductTitle,
                NativeTitle = pc.product.NativeTitle,
                ImageSrc = pc.product.ImageSrc,
                Category = category,
                SubCategory = pc.product.SubCategory,
                Country = pc.product.Country,
                PortionWeight = pc.product.PortionWeight,
                CaloriesPer100g = pc.product.CaloriesPer100g,
                PortionPrice = pc.product.PortionPrice,
                MainComponents = pc.product.MainComponents,
                CookingRecipe = pc.product.CookingRecipe
            };
            p_logic.Update(new Product[] { p });
            //pc = (ProductsCategories)Session["procat"];
            if (category == "AS") { procat.AppetizersSalads.RemoveAll(a=>a.Id==p.Id); procat.AppetizersSalads.Add(p); }
            if (category == "MC") { procat.MainCourses.RemoveAll(a => a.Id == p.Id); procat.MainCourses.Add(p); }
            if (category == "SP") { procat.Soups.RemoveAll(a => a.Id == p.Id); procat.Soups.Add(p); }
            if (category == "BG") { procat.Beverages.RemoveAll(a => a.Id == p.Id); procat.Beverages.Add(p); }
            if (category == "DS") { procat.Desserts.RemoveAll(a => a.Id == p.Id); procat.Desserts.Add(p); }
            if (category == "BR") { procat.Breads.RemoveAll(a => a.Id == p.Id); procat.Breads.Add(p); }
            procat.product = new Product();

            //if (AS == "Y") { pc.AdminFilterState["AS"] ="checked"; } else { pc.AdminFilterState["AS"] = ""; }
            //if (MC == "Y") { pc.AdminFilterState["MC"] ="checked"; } else { pc.AdminFilterState["MC"] = ""; }
            //if (SP == "Y") { pc.AdminFilterState["SP"] ="checked"; } else { pc.AdminFilterState["SP"] = ""; }
            //if (BG == "Y") { pc.AdminFilterState["BG"] ="checked"; } else { pc.AdminFilterState["BG"] = ""; }
            //if (DS == "Y") { pc.AdminFilterState["DS"] ="checked"; } else { pc.AdminFilterState["DS"] = ""; }
            //if (BR == "Y") { pc.AdminFilterState["BR"] ="checked"; } else { pc.AdminFilterState["BR"] = ""; }
            //if (AL == "Y") { pc.AdminFilterState["AL"] ="checked"; } else { pc.AdminFilterState["AL"] = ""; }

            //Session["procat"] = pc;
            return RedirectToAction("ShowProducts");
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteProduct(int id)
        {
            //Company c = (Company)Session["Company"];
            Product p = p_logic.GetList(a => a.Id == id).First();
            
            //ProductsCategories pc = (ProductsCategories)Session["procat"];
            string category = p.Category;
            if (category == "AS") { procat.AppetizersSalads.RemoveAll(a=>a.Id==p.Id); }
            if (category == "MC") { procat.MainCourses.RemoveAll(a => a.Id == p.Id); }
            if (category == "SP") { procat.Soups.RemoveAll(a => a.Id == p.Id); }
            if (category == "BG") { procat.Beverages.RemoveAll(a => a.Id == p.Id); }
            if (category == "DS") { procat.Desserts.RemoveAll(a => a.Id == p.Id); }
            if (category == "BR") { procat.Breads.RemoveAll(a => a.Id == p.Id); }
            p_logic.Remove(new Product[] { p });
            procat.product = new Product();
            //Session["procat"] = pc;
            return RedirectToAction("ShowProducts");
        }

        //-------------------------------------------------------------- Experiment ------------------------------------------------------------
       
    }
}