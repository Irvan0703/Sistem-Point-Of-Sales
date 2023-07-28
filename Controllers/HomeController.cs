using Microsoft.AspNetCore.Mvc;
using Sistem_Point_Of_Sales.Models;
using Sistem_Point_Of_Sales.Interface;
using Sistem_Point_Of_Sales.ViewModels;
using System.Diagnostics;

namespace Sistem_Point_Of_Sales.Controllers
{
    public class HomeController : Controller
    {
        /*
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/
        private readonly IProduct product;
        public HomeController(IProduct product)
        {
            this.product = product;
        }

        public IActionResult Index()
        {
            try
            {
                var result = product.GetAllProducts().Result;
                ViewBag.Product = result;
                return View();

            } catch (Exception)
            {
                throw;
            }
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create (Products products, Tags tags)
        {
            if(ModelState.IsValid)
            {
                product.CreateProduct(products, tags);
            }
            ViewBag.message = "Data Successfully Saved";
            ModelState.Clear();
            return View();
        }

        public IActionResult Edit(int id)
        {
            ProductViewModel empview = new ProductViewModel()
            {
                viewModelProduct = product.GetProductsById(id)
            };
            return View(empview);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductViewModel productViewModel)
        {
            Products pmodel = new Products()
            {
                Id = (int)productViewModel.productId,
                Name = productViewModel.ProductName,
                Description = productViewModel.ProductDescription,
                Price = (double)productViewModel.ProductPrice,
                category = productViewModel.ProductCategory,
                stock = productViewModel.ProductStock
            };
            Tags tags = new Tags()
            {

            };
            var result = product.UpdateProduct(pmodel, tags);
            ModelState.Clear();
            return View(result);
        }

        public IActionResult Delete(int id)
        {
            ProductViewModel empview = new ProductViewModel()
            {
                viewModelProduct = product.GetProductsById(id)
            };
            return View(empview);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(ProductViewModel productViewModel)
        {
            var result = product.DeleteProduct(productViewModel.productId);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}