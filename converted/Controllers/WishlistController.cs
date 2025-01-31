using System.Threading.Tasks;
using Bookstore.Web.Helpers;
using Bookstore.Domain.Customers;
using Bookstore.Domain.Carts;
using Bookstore.Web.ViewModel.Wishlist;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Bookstore.Web.Controllers
{
    [AllowAnonymous]
    public class WishlistController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IShoppingCartService _shoppingCartService;

        public WishlistController(ICustomerService customerService, IShoppingCartService shoppingCartService)
        {
            _customerService = customerService;
            _shoppingCartService = shoppingCartService;
        }

        public async Task<IActionResult> Index()
        {
            var shoppingCart = await _shoppingCartService.GetShoppingCartAsync(HttpContext.GetShoppingCartCorrelationId());

            return View(new WishlistIndexViewModel(shoppingCart));
        }

        [HttpPost]
        public async Task<IActionResult> MoveToShoppingCart(int shoppingCartItemId)
        {
            var dto = new MoveWishlistItemToShoppingCartDto(HttpContext.GetShoppingCartCorrelationId(), shoppingCartItemId);

            await _shoppingCartService.MoveWishlistItemToShoppingCartAsync(dto);

            TempData["Notification"] = "Item moved to shopping cart";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> MoveAllItemsToShoppingCart()
        {
            var dto = new MoveAllWishlistItemsToShoppingCartDto(HttpContext.GetShoppingCartCorrelationId());

            await _shoppingCartService.MoveAllWishlistItemsToShoppingCartAsync(dto);

            TempData["Notification"] = "All items moved to shopping cart";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int shoppingCartItemId)
        {
            var dto = new DeleteShoppingCartItemDto(HttpContext.GetShoppingCartCorrelationId(), shoppingCartItemId);

            await _shoppingCartService.DeleteShoppingCartItemAsync(dto);

            TempData["Notification"] = "Item removed from wishlist";

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}