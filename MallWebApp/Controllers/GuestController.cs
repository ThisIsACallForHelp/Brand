using Microsoft.AspNetCore.Mvc;
using Models;
using WebApiClient;
using static System.Net.WebRequestMethods; 
namespace MallWebApp.Controllers
{
    public class GuestController : Controller
    {
        public IActionResult StartPage()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetStoreCatalog()
        {
            WebClient<CatalogViewModel> webClient = new WebClient<CatalogViewModel>();
            webClient.Scheme = "http";
            webClient.Port = 7274; //12 is an example, it will be changed later
            webClient.Host = "localhost";
            webClient.Path = "api/Guest/GetStoreCatalog"; 
            CatalogViewModel storeCatalogViewModel = webClient.Get().Result;
            return View(storeCatalogViewModel);
        }
    }
}
