using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;

namespace BeerWeb.ViewModels
{
    public class EditUserViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        public string Id { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }
        [Required(ErrorMessage = "You must choose a role.")]
        public string Role { get; set; }
    }
}