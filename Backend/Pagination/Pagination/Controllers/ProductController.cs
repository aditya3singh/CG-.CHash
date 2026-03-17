using Microsoft.AspNetCore.Mvc;
using Pagination.Repositories;

namespace Pagination.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository _repository;

        public ProductController(ProductRepository repository)
        {
            _repository = repository;
        }

        // 1. Loads the initial View
        public IActionResult Index()
        {
            return View();
        }

        // 2. Called by JavaScript to get more data
        [HttpGet]
        public IActionResult LoadMoreProducts(int pageNumber, int pageSize)
        {
            var products = _repository.GetProductsLazyLoaded(pageNumber, pageSize);

            return Json(products);
        }
    }
}