using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeerWeb.ViewModels
{
    public class NewProductViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 2, ErrorMessage = "Product name must have atleast 2 characters and maximun of 250 characters.")]
        public string Name { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 3, ErrorMessage = "Description must be between 3 and 300 characters.")]
        public string Description { get; set; }

        [Required]
        [Range(1,999)]
        public decimal Price { get; set; }

        public string PicURL { get; set; }


        [Required(ErrorMessage = "Product must have a category.")]
        public int Category_Id { get; set; }
        public List<SelectListItem> Category { get; set; }
    }
}