using BeerWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerWeb.ViewModels
{
    public class ShowAllProductsViewModel
    {
        public string SortByNameParam { get; set; }
        public string SortByPriceParam { get; set; }


        public List<Product> ProductsList { get; set; }

        public ShowAllProductsViewModel()
        {
            ProductsList = new List<Product>();
        }
    }
}