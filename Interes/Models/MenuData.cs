using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interes.Models
{
    public class MenuData
    {
        public BasketGroup bsg { get; set; }
        public bool IsAdmin { get; set; }
        public string[] Customer { get; set; }
        public MenuData()
        {
            bsg = new BasketGroup();
            IsAdmin = false;
            Customer = new string[4];
        }
    }
}