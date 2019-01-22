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

        [Required(ErrorMessage = "Field price is required.")]
        [RegularExpression(@"^\d+\,\d{0,2}$", ErrorMessage = "Please enter a valid price, ex: 10,00 / 10")]
        [Range(0, 9999999999999999.99, ErrorMessage = "Please enter a valid price, ex: 10,00 / 10")]
        public decimal Price { get; set; }

        public string PicURL { get; set; }

        [Required(ErrorMessage = "Product must have a category.")]
        public int Category_Id { get; set; }
        public List<SelectListItem> Category { get; set; }
    }
}