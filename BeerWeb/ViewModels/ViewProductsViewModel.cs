using BeerWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerWeb.ViewModels
{
    public class ViewProductsViewModel
    {
        public List<Product> ProductsList{ get; set; }
        public ViewProductsViewModel()
        {
            ProductsList = new List<Product>();
        }
    }
}