using System.Linq;
using System.Web.Mvc;
using SportsStoreDomain.Abstract;
using SportsStoreDomain.Entities;
using SportsStoreWeb.Models;

namespace SportsStoreWeb.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductRepository repository;

        public CartController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
        {
            var product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
                cart.AddItem(product, 1);
            return RedirectToAction("Index", new {returnUrl});
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            var product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
                cart.RemoveLine(product);
            return RedirectToAction("Index", new {returnUrl});
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        } 

    }
}