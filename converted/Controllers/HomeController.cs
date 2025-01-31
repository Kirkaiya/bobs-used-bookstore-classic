using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bookstore.Domain.Books;
using System.Threading.Tasks;
using Bookstore.Web.ViewModel.Home;
using Microsoft.AspNetCore.Authorization;

namespace Bookstore.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IBookService _bookService;

        public HomeController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _bookService.ListBestSellingBooksAsync(4);
            return View(new HomeIndexViewModel(books));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Search()
        {
            return RedirectToAction("Index", "Search");
        }

        public IActionResult Cart()
        {
            return RedirectToAction("Index", "ShoppingCart");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}