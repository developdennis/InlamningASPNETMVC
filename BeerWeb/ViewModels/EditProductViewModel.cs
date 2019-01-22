using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeerWeb.ViewModels
{
    public class EditProductViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Enter atleast 3 characters and maximun 250 characters.")]
        public string Name { get; set; }

        [Required]
        [StringLength(250,MinimumLength = 3, ErrorMessage = "Enter atleast 3 characters and maximum 250 characters.")]
        public string Description { get; set; }

        [Required]
        [Range(0.01,1000, ErrorMessage = "We don't sell free beer or beer that costs more than $999")]
        public decimal Price { get; set; }

        public string PicURL { get; set; }

        [Required(ErrorMessage = "Product must have a category.")]
        public int Category_Id { get; set; }
        public List<SelectListItem> Category { get; set; }
    }
}