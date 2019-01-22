using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerWeb.ViewModels
{
    public class ViewSingleProductViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PicURL { get; set; }
        public decimal Price { get; set; }
        public int UnitsInStock { get; set; }
        public string DeliveryTime { get; set; }
        public int Id { get; set; }

    }
}