using BeerWeb.Models;
using BeerWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeerWeb.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        [HttpGet]
        public ActionResult ViewProducts(int id)
        {
            using (var entities = new BeerWeb.Models.BeerModel())
            {
                var viewmodel = new ViewModels.ViewProductsViewModel();
                viewmodel.ProductsList.AddRange(entities.Products.Where(x => x.Category_Id == id));


                return View(viewmodel);
            }
        }
        public JsonResult GetMoreInfo(int id)
        {
            using (var db = new BeerModel())
            {
                var mod = db.Products.FirstOrDefault(x => x.Id == id);
                var model = new ViewModels.ViewSingleProductViewModel();
                model.DeliveryTime = mod.DeliveryTime;
                model.UnitsInStock = mod.UnitsInStock;
                return Json(model, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpGet]
        public ActionResult ViewSingleProduct(int id)
        {
            using (var entities = new Models.BeerModel())
            {
                var viewModel = new ViewModels.ViewSingleProductViewModel();
                var prod = entities.Products.FirstOrDefault(x => x.Id == id);
                viewModel.Description = prod.Description;
                viewModel.Name = prod.Name;
                viewModel.Price = prod.Price;
                viewModel.PicURL = prod.PicURL;
                viewModel.Id = prod.Id;
                return View(viewModel);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin,ProductManager")]
        public ActionResult DeleteProduct(int id)
        {
            using (var entities = new Models.BeerModel())
            {
                var product = entities.Products.FirstOrDefault(x => x.Id == id);
                entities.Products.Remove(product);
                entities.SaveChanges();

                return RedirectToAction("Index", "Category");
            }
        }
        [HttpGet]
        [Authorize(Roles = "Admin,ProductManager")]
        public ActionResult EditProduct(int id)
        {
            using (var entities = new Models.BeerModel())
            {
                var product = entities.Products.FirstOrDefault(x => x.Id == id);
                var viewModel = new EditProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Category_Id = product.Category_Id,
                    PicURL = product.PicURL
                };
                SetupAvailableCatgoriesEdit(viewModel);
                return View(viewModel);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin,ProductManager")]
        public ActionResult EditProduct(ViewModels.EditProductViewModel modified)
        {
            SetupAvailableCatgoriesEdit(modified);
            if (!ModelState.IsValid)
            {
                return View(modified);
            }
            using (var entities = new Models.BeerModel())
            {
                var model = entities.Products.FirstOrDefault(x => x.Id == modified.Id);

                model.Name = modified.Name;
                model.Price = modified.Price;
                model.Description = modified.Description;
                model.Category_Id = modified.Category_Id;
                model.PicURL = modified.PicURL;

                entities.SaveChanges();

                return RedirectToAction("Index", "Category");
            }
        }

        void SetupAvailableCatgoriesNew(NewProductViewModel model)
        {
            using (var entities = new BeerWeb.Models.BeerModel())
            {
                model.Category = new List<SelectListItem>
                {
                    new SelectListItem{Value = null, Text ="Choose a category.."},
                };

                foreach (var item in entities.Categories)
                {
                    var cat = new SelectListItem { Value = item.Id.ToString(), Text = item.Name };
                    model.Category.Add(cat);
                };
            }
        }
        void SetupAvailableCatgoriesEdit(EditProductViewModel model)
        {
            using (var entities = new BeerWeb.Models.BeerModel())
            {
                model.Category = new List<SelectListItem>
                {
                    new SelectListItem{Value = null, Text ="Choose a category.."},
                };

                foreach (var item in entities.Categories)
                {
                    var cat = new SelectListItem { Value = item.Id.ToString(), Text = item.Name };
                    model.Category.Add(cat);
                };
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin,ProductManager")]
        public ActionResult NewProduct()
        {
            var model = new ViewModels.NewProductViewModel();
            SetupAvailableCatgoriesNew(model);
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,ProductManager")]
        public ActionResult NewProduct(NewProductViewModel model)
        {
            SetupAvailableCatgoriesNew(model);
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var entities = new BeerWeb.Models.BeerModel())
            {
                var newproduct = new Models.Product
                {
                    Category_Id = model.Category_Id,
                    Name = model.Name,
                    Description = model.Description,
                    PicURL = model.PicURL,
                    Price = model.Price
                };
                entities.Products.Add(newproduct);
                entities.SaveChanges();

                return RedirectToAction("Index", "Category");
            }

        }

        public ActionResult SearchResult(string sortOrder, string searchProduct)
        {
            var viewmodel = new ShowAllProductsViewModel();
            viewmodel.Search = searchProduct;

            using (var db = new BeerModel())
            {
                viewmodel.ProductsList.AddRange(db.Products.Where(x => x.Description.ToUpper().Contains(searchProduct.ToUpper()) || x.Name.ToUpper().Contains(searchProduct.ToUpper())));
                viewmodel = Sort(sortOrder, viewmodel);

                return View(viewmodel);

            }
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult ShowAllProducts(string sortOrder)
        {
            using (var db = new Models.BeerModel())
            {
                var viewmodel = new ViewModels.ShowAllProductsViewModel();
                viewmodel.ProductsList.AddRange(db.Products);
                viewmodel = Sort(sortOrder, viewmodel);
                return View(viewmodel);
            }
        }

        public ShowAllProductsViewModel Sort(string sortOrder, ShowAllProductsViewModel model)
        {

            model.SortByNameParam = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            model.SortByPriceParam = sortOrder == "Price" ? "price_desc" : "Price";

            switch (sortOrder)
            {
                case "name_desc":
                    model.ProductsList = model.ProductsList.OrderByDescending(x => x.Name).ToList();
                    break;

                case "Price":
                    model.ProductsList = model.ProductsList.OrderBy(x => x.Price).ToList();
                    break;

                case "price_desc":
                    model.ProductsList = model.ProductsList.OrderByDescending(x => x.Price).ToList();
                    break;

                default:
                    model.ProductsList = model.ProductsList.OrderBy(x => x.Name).ToList();
                    break;
            }
            
            return model;
            
        }
    }
}