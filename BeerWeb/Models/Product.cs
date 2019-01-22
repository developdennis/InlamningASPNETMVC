using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerWeb.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Category_Id { get; set; }
        public string PicURL { get; set; }
        public int UnitsInStock { get; set; }
        public string DeliveryTime { get; set; }
    }
}