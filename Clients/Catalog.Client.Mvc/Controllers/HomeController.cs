using Catalog.Client.Mvc.ApiServices;
using Catalog.Client.Mvc.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Diagnostics;

namespace Catalog.Client.Mvc.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductApiService _productApiService;

        public HomeController(ILogger<HomeController> logger,
            IProductApiService productApiService)
        {
            _logger = logger;
            _productApiService = productApiService;
        }

        public async Task<IActionResult> Index()
        {
            await LogTokenAsync();
            var result = await _productApiService.GetProductsAsync();
            return View(result);
        }

        private async Task LogTokenAsync()
        {
            var identityToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.IdToken);
            Debug.WriteLine(identityToken);

            foreach (var claim in User.Claims)
            {
                Debug.WriteLine($"Type : {claim.Type} Value: {claim.Value}");
            }
        }

        public async Task Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
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