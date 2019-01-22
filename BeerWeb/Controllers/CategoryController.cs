using BeerWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeerWeb.Controllers
{
    public class CategoryController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            using (var db = new BeerWeb.Models.BeerModel())
            {
                var viewModel = new ViewModels.HomePageViewModel();
                viewModel.CategoryList.AddRange(db.Categories);

                return View(viewModel);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin,ProductManager")]
        public ActionResult NewCategory()
        {
            var model = new ViewModels.NewCategoryViewModel();

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,ProductManager")]
        public ActionResult NewCategory(ViewModels.NewCategoryViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            using (var entities = new Models.BeerModel())
            {
                var newCat = new Category
                {
                    Name = model.Name
                };
                entities.Categories.Add(newCat);
                entities.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin,ProductManager")]
        public ActionResult EditCategory(int id)
        {
            using (var entities = new Models.BeerModel())
            {
                var model = entities.Categories.FirstOrDefault(x => x.Id == id);
                var viewmodel = new ViewModels.EditCategoryViewModel
                {
                    Name = model.Name
                };
                return View(viewmodel);

            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin,ProductManager")]
        public ActionResult EditCategory(ViewModels.EditCategoryViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            using (var entities = new Models.BeerModel())
            {
                var cat = entities.Categories.FirstOrDefault(x => x.Id == model.Id);
                cat.Name = model.Name;

                entities.SaveChanges();

                return RedirectToAction("Index");
            }

        }

        [HttpGet]
        public ActionResult DeleteCategory(int id)
        {
            using (var entities = new BeerModel())
            {
                var category = entities.Categories.FirstOrDefault(x => x.Id == id);
                entities.Categories.Remove(category);
                entities.SaveChanges();
                return RedirectToAction("Index");
            }
        }

    }
}