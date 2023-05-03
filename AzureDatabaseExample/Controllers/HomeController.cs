using AzureDatabaseExample.data;
using AzureDatabaseExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AzureDatabaseExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly StepDataContext _dbContext;

        public HomeController(StepDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            //var myEntities = _dbContext.ProductCategories.Select(a=>a.Name).ToList();
            ViewBag.Categories = new SelectList(_dbContext.ProductCategories, "ProductCategoryId", "Name");
            //ViewBag.Categories = myEntities;
            return View("Index", null);
        }
        public ActionResult GetProductsByCategoryId(int categoryId)
        {
            var products = _dbContext.Products.Where(p => p.ProductCategoryId == categoryId).ToList();
            return PartialView("ProductList", products);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}