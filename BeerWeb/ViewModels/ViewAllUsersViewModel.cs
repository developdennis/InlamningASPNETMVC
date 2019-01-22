using BeerWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerWeb.ViewModels
{
    public class ViewAllUsersViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}