using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace Bookstore.Web.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class ErrorController : AdminAreaControllerBase
    {
        [Route("/Admin/Error/{code:int}")]
        public IActionResult Index(int code)
        {
            var feature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewData["Path"] = feature?.Path;
            ViewData["StatusCode"] = code;
            return View();
        }

        [Route("/Admin/error")]
        public IActionResult Support()
        {
            var feature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewData["Path"] = feature?.Path;
            var error = Problem();

            ViewData["StatusCode"] = error.StatusCode;
            return View("~/Views/Error/Index.cshtml");
        }
    }
}