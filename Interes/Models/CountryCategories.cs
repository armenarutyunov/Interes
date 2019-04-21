using DBMOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interes.Models
{
    public class CountryCategories
    {
        public Dictionary<string,List<Product>> armenia { get; set; }
        public Dictionary<string,List<Product>> azerbaidjan { get; set; }
        public Dictionary<string,List<Product>> georgia { get; set; }
        public Dictionary<string, List<Product>> iran { get; set; }
        public Product product { get; set; }
        public int virgin { get; set; }

        public CountryCategories()
        {
            virgin = 0;
            product = new Product()
            {
                ProductTitle = "",
                NativeTitle = "",
                ImageSrc = "",
                Category = "",
                SubCategory = "",
                Country = "",
                PortionWeight = "",
                CaloriesPer100g = "",
                PortionPrice = "",
                MainComponents = "",
                CookingRecipe = ""
            };
            armenia = new Dictionary<string, List<Product>>() { { "AS", new List<Product>()}, { "MC", new List<Product>() }, { "SP", new List<Product>() }, { "DS", new List<Product>() }, { "BG", new List<Product>() }, { "BR", new List<Product>() } };
            georgia = new Dictionary<string,List<Product>>() { { "AS", new List<Product>() }, { "MC", new List<Product>() }, { "SP", new List<Product>() }, { "DS", new List<Product>() }, { "BG", new List<Product>() }, { "BR", new List<Product>() } };
            azerbaidjan = new Dictionary<string,List<Product>>() { { "AS", new List<Product>() }, { "MC", new List<Product>() }, { "SP", new List<Product>() }, { "DS", new List<Product>() }, { "BG", new List<Product>() }, { "BR", new List<Product>() } };
            iran = new Dictionary<string,List<Product>>() { { "AS", new List<Product>() }, { "MC", new List<Product>() }, { "SP", new List<Product>() }, { "DS", new List<Product>() }, { "BG", new List<Product>() }, { "BR", new List<Product>() } };

        }
    }
}
