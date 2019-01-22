﻿using BeerWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerWeb.ViewModels
{
    public class HomePageViewModel
    {
        public List<Category> CategoryList { get; set; }

        public HomePageViewModel()
        {
            CategoryList = new List<Category>();
        }
    }
}