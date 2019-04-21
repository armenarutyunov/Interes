using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Interes.Models
{
    public class LoginData
    {
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^[\w-\._\+%]+@(?:[\w-]+\.)+[\w]{2,6}$", ErrorMessage = "Email address is not valid")]
        public string  Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        //[RegularExpression(@"^((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[\W_]).{6,50})$", ErrorMessage = "Password is not valid")]
        public string Password { get; set; }

      
        //public LoginData()
        //{
        //    Email = "--Enter Your Email--";
        //    Password = "--Enter Your Password--";
        //}
    }
}