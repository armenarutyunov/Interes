using DBMOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interes.Models
{
    public class ProductsCategories
    {
        public Product product { get; set; }
        public List<Product> AppetizersSalads { get; set; }
        public List<Product> MainCourses { get; set; }
        public List<Product> Soups { get; set; }
        public List<Product> Beverages { get; set; }
        public List<Product> Desserts { get; set; }
        public List<Product> Breads { get; set; }
        public Dictionary<string, string> AdminFilterState { get; set; }
        public ProductsCategories()
        {
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
            AppetizersSalads = new List<Product>();
            MainCourses = new List<Product>();
            Soups = new List<Product>();
            Beverages = new List<Product>();
            Desserts = new List<Product>();
            Breads = new List<Product>();
            AdminFilterState = new Dictionary<string, string>() { {"AS",""}, {"MC",""}, { "SP","" }, {"DS",""}, {"BG",""}, {"BR",""}, { "AL", "" } };

        }
    }
}
