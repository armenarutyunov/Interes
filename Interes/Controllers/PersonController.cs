
using Interes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Interes.Controllers
{
    public class PersonController : Controller
    {
        public ActionResult Create()
        {
            return View(new Person());
        }


        [HttpPost]
        public ActionResult Create111(Person p)
        {
            return View(p);
        }



    }

}