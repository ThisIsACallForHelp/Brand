using Microsoft.AspNetCore.Mvc;
using Models;
using WebApiClient;
using static System.Net.WebRequestMethods; 
namespace MallWebApp.Controllers
{
    public class ControllerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetStoreCatalog()
        {
            WebClient<CatalogViewModel> webClient = new WebClient<CatalogViewModel>();
            webClient.Scheme = "http";
            webClient.Port = 7274; //12 is an example, it will be changed later
            webClient.Host = "localhost/api/Guest/GetStoreCatalogViewModel";
            CatalogViewModel storeCatalogViewModel = webClient.Get().Result;
            return View(storeCatalogViewModel);
        }
    }
}
