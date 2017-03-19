using System.Linq;
using System.Web.Mvc;
using SportsStoreDomain.Abstract;
using SportsStoreWeb.Models;

namespace SportsStoreWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        public int PageSize = 4;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: Product
        public ViewResult List(string category, int page = 1)
        {
            //return View( _productRepository.Products.
            //    OrderBy(p => p.ProductID).
            //    Skip( ( page - 1 ) * PageSize ).
            //    Take(PageSize) );

            var model = new ProductsListViewModel
            {
                Products = _productRepository.Products
                    .Where(p => (category == null) || (p.Category == category))
                    .OrderBy(p => p.ProductID)
                    .Skip((page - 1)*PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null
                        ? _productRepository.Products.Count()
                        : _productRepository
                            .Products
                            .Where(e => e.Category == category).Count()
                },
                CurrentCategory = category
            };

            return View(model);
        }
    }
}