using BusinessLogic;
using DBMOD;
using EntityFrameworkDataAccess;
using Interes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
//using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Interes.Controllers
{
    public class CheckoutController : Controller
    {
     
        RestaurantEntities re = new RestaurantEntities();
        EFGenericRepository<Order> o_repo = new EFGenericRepository<Order>();
        private OrderLogic o_logic;
        public CheckoutController()
        {
            o_logic = new OrderLogic(o_repo);
        }
        //public class IsNameValidAttribute : ValidationAttribute

        //{
            

        //    public override bool IsValid(object value)
        //    {
        //        string str = Convert.ToString(value);
        //        return str == "ARMEN";
        //    }
        //}
        // GET: Checkout
        public ActionResult OrderDetails()
        {
            //BasketGroup bg = HomeController.bsg;
            OrderDetails bg = new OrderDetails();
            bg.Name = HomeController.customer[1]+" "+ HomeController.customer[2];
            bg.Phone = HomeController.customer[3];
            bg.Email = HomeController.customer[5];

            int cusid = Convert.ToInt32(HomeController.customer[0]);
            HomeController.addresses = new List<string>() { " -- Your Previous Addresses --" };
            if (cusid > 1)
            {
                List<Order> od_list = o_logic.GetList(a => a.CustomerId == cusid).ToList(); 
          
                foreach (var rec in od_list)
                {
                    HomeController.addresses.Add(rec.Street + ", " + rec.UnitNumber + ", " + rec.City + ", " + rec.PostalCode);
                }
            }
            bg.Addresses = HomeController.addresses.Distinct().ToList();
            bg.DeliveryDate = DateTime.Now.AddDays(1).Date;
            bg.DeliveryTime = DateTime.Now.AddHours(12);
            return View(bg);
           
           
        }
        public ActionResult BasketContents()
        {
            return View(HomeController.bsg);
        }
        [HttpPost]
        public ActionResult OrderDetails(OrderDetails obj)
        {
            if (Interes.Models.OrderDetails.isInValid || Interes.Models.OrderDetails.isInValidTime)
            {
                obj.Addresses = HomeController.addresses.Distinct().ToList();

                if (Interes.Models.OrderDetails.isInValidTime)
                {
                    ViewBag.Validation = "Sorry, we need at least 36 Hours to fulfill your order!";

                }
                else { ViewBag.Validation = ""; }
                return View(obj);
            }
            //ViewBag.Validation = "";
            TempData["OD"] = obj;
            return RedirectToAction("OrderHandler");
          
        }
       //[HttpPost]
        public ActionResult OrderHandler(/*OrderDetails obj*/)// OrderHandler
        {
            OrderDetails obj = (OrderDetails)TempData["OD"];

            var del = 12 - HomeController.bsg.BasketTotal() * 0.1;
            if (del < 0) { del = 0; }
            var prco = HomeController.bsg.BasketTotal();
            Order order = new Order()
            {
                OrderDate = obj.DeliveryDate.ToString() + ' ' + obj.DeliveryTime.ToString(),
                ProductCost = prco.ToString("####.##"),
                DeliveryCost = del.ToString("####.##"),
                TotalHST = (0.13 * (prco + del)).ToString("####.##"),
                TotalCost = (1.13 * (prco + del)).ToString("####.##"),
               
            };
            //order.City = (string.IsNullOrEmpty(obj.City)) ?  "Not Provided":  obj.City;
            order.City = obj.City;
            order.Street = (string.IsNullOrEmpty(obj.StreetAddress)) ? "Not Provided" : obj.StreetAddress;
            //order.HomeNumber = (string.IsNullOrEmpty(obj.HomeNumber)) ? "Not Provided" : obj.HomeNumber;
            order.UnitNumber = (string.IsNullOrEmpty(obj.UnitApt)) ? "N/A" : obj.UnitApt;
            order.PostalCode = (string.IsNullOrEmpty(obj.PostalCode)) ? "Not Provided" : obj.PostalCode;
            order.CustomerId = Convert.ToInt32(HomeController.customer[3]);
            order.HomeNumber = obj.Phone;
            Order[] olist = new Order[] { order };
            //try
            //{
            //    o_logic.Add(olist);
            //}
            //catch (AggregateException e) { IEnumerable<BusinessLogic.ValidationException> exceptions = e.InnerExceptions.Cast<BusinessLogic.ValidationException>();
            //    string str = "";
            //    foreach (var item in exceptions)
            //    {
            //        //TempData["Message"] = exceptions.ElementAt(0).Message;

            //         str=str+"|"+item.Message;
            //    }
            //    TempData["Message"] = str;
            //        return RedirectToAction("Message", "Home");
            //}

            int maxId = re.Orders.Select(x => x.Id).DefaultIfEmpty(0).Max();
            //List<OrderDetail> odlist = new List<OrderDetail>();

            foreach(Record line in HomeController.bsg.Records)
            {

               OrderDetail od = new OrderDetail { ProductId = line.Product.Id, PortionsQuantity = line.Quantity.ToString(), OrderId = maxId };
                re.OrderDetails.Add(od);
                re.SaveChanges();
            }

//Sends confirmation Email to Customer -- Block Starts -------------------------------------
            try
            {
                //Configuring webMail class to send emails  
                //gmail smtp server  
                WebMail.SmtpServer = "smtp.gmail.com";
                //gmail port to send emails  
                WebMail.SmtpPort = 587;
                WebMail.SmtpUseDefaultCredentials = true;
                //sending emails with secure protocol  
                WebMail.EnableSsl = true;
                //EmailId used to send emails from application  
                WebMail.UserName = "easterncuisinerestaurant@gmail.com";
                WebMail.Password = "dva*dva=4";

                //Sender email address.  
                WebMail.From = "easterncuisinerestaurant@gmail.com";

                string body = "<h2>Dear " + obj.Name + "</h2>" + "<br/>" + "<h3>These are the Details of Your Order, made at:</h3> " + DateTime.Now.ToString() + "<br/>";
                body += "<h3>Delivery Address:  </h3>" /*+ obj.HomeNumber*/ + "&nbsp;" + obj.StreetAddress + " &nbsp;&nbsp;&nbsp;  " + "Unit/Apt #: " + obj.UnitApt + " City: &nbsp;" + obj.City + "<br/>";
                body += "<h3>Date of Delivery: </h3>" + obj.DeliveryDate + " <h3>Delivery Time: </h3>" + obj.DeliveryTime;
                //Send email  
                WebMail.Send(to: obj.Email.ToString(), subject: "Your Order's Details", body: body, /*cc: null, bcc: null,*/ isBodyHtml: true);
                ViewBag.Status = "You Order Confirmed Successfully!";
                
            }
            catch (Exception)
            {
                ViewBag.Status = "Problem while sending email, Please check details.";

            }
//Sends confirmation Email to Customer -- Block Ends -----------------------------------------
            HomeController.bsg = new BasketGroup();
            HomeController.MenuFilterPad = "nnnnnnnnnnnn";
            return View();
        }
        //public bool IsEmail(string Email)
        //{
        //    //Regex phoneRegex = new Regex(@"^([0-9\(\)\/\+ \-]*)$");
        //    Regex emailRegex = new Regex(/*[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?*/@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$| |^([0-9\(\)\/\+ \-]*)$");

        //    return (emailRegex.IsMatch(Email) /*|| phoneRegex.IsMatch(notification)*/);
        //}
       
        
    }

    //public class EmailAddressAttribute : System.ComponentModel.DataAnnotations.RegularExpressionAttribute
    //{
    //    public EmailAddressAttribute() :base(@"^[\w -\._\+%] +@(?:[\w -] +\.)+[\w]{2,6}$") 
    //    {
    //    }
    //}


}