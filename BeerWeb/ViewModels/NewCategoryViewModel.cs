using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeerWeb.ViewModels
{
    public class NewCategoryViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(250,MinimumLength = 2, ErrorMessage = "Categoryname must be between 2 and 250 characters in length.")]
        public string Name { get; set; }

    }
}