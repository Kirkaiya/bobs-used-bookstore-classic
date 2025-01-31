using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace Bookstore.Web.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IConfiguration _configuration;

        public AuthenticationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Login(string redirectUri = null)
        {
            if (string.IsNullOrWhiteSpace(redirectUri)) return RedirectToAction("Index", "Home");

            return Redirect(redirectUri);
        }

        public IActionResult LogOut()
        {
            return _configuration["Services:Authentication"] == "aws" ? CognitoSignOut() : LocalSignOut();
        }

        private IActionResult LocalSignOut()
        {
            if (Request.Cookies["LocalAuthentication"] != null)
            {
                Response.Cookies.Delete("LocalAuthentication");
            }

            return RedirectToAction("Index", "Home");
        }

        private IActionResult CognitoSignOut()
        {
            if (Request.Cookies[".AspNetCore.Cookies"] != null)
            {
                Response.Cookies.Delete(".AspNetCore.Cookies");
            }

            var domain = _configuration["Authentication:Cognito:CognitoDomain"];
            var clientId = _configuration["Authentication:Cognito:LocalClientId"];
            var logoutUri = $"{Request.Scheme}://{Request.Host}/";

            return Redirect($"{domain}/logout?client_id={clientId}&logout_uri={logoutUri}");
        }
    }
}