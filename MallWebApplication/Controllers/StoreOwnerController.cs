using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Models;
using System.Net;
using WebApiClient;

namespace MallWebApplication.Controllers
{
    public class StoreOwnerController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            TempData["StoreOwnerID"] = Convert.ToInt32(HttpContext.Session.GetString("StoreOwnerID"));
            TempData["StoreID"] = Convert.ToInt32(HttpContext.Session.GetString("StoreID"));
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> StoreOwnerView(bool OnSale, int StoreOwnerID)
        {
           //need to finish this, but the product catalog works perfectly fr fr 
            StoreOwnerID = Convert.ToInt32(HttpContext.Session.GetString("StoreOwnerID"));
            Console.WriteLine("StoreOwnerID -> " + StoreOwnerID);
            Console.WriteLine(StoreOwnerID.GetType());
            WebClient<StoreOwnerViewModel> Client = new WebClient<StoreOwnerViewModel>()
            {
                Schema = "http",
                Port = 5134,
                Host = "localhost",
                Path = "api/StoreOwner/StoreOwnerView"
            };
            Client.AddParams("StoreOwnerID", StoreOwnerID.ToString());
            Client.AddParams("OnSale", OnSale.ToString());
            StoreOwnerViewModel products = new StoreOwnerViewModel()
            {
                StoreOwnerID = StoreOwnerID,
                OnSale = OnSale
            };
            products = await Client.GetAsync();
            return View(products);
        }

        [HttpPost]

        public async Task<IActionResult> AddProduct(Product product)
        {
            //need to code this 
            //maybe open a modal menu?
            WebClient<Product> Client = new WebClient<Product>()
            {
                Schema = "http",
                Port = 5134,
                Host = "localhost",
                Path = "api/StoreOwner/AddNewProductToStore"
            };           
            bool CustomerAdded = await Client.PostAsync(product);
            if (CustomerAdded)
            {
                return View();
            }
            else
            {
                return null;
            }
        }

        [HttpPost]
        //i dont need to pass the whole product if i can just pass it's ID
        // i have to do it like i said above 
        public async Task<IActionResult> AddSale(Product Product, int Percentage)
        {
            WebClient<Product> Client = new WebClient<Product>()
            {
                Schema = "http",
                Port = 5134,
                Host = "localhost",
                Path = "api/StoreOwner/AddNewSale"
            };
            Product.SaleID = Percentage / 5;
            bool CustomerAdded = await Client.PostAsync(Product);
            if (CustomerAdded)
            {
                return View();
            }
            else
            {
                return null;
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetProduct(int ProductID)
        {
            //should work since i already have the html
            WebClient<Product> Client = new WebClient<Product>();
            Client.Schema = "http";
            Client.Port = 5134; //12 is an example, it will be changed later
            Client.Host = "localhost";
            Client.Path = "api/Customer/GetProduct";
            Client.AddParams("ProductID", ProductID.ToString());
            Product product = await Client.GetAsync();
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int ProductID)
        {
            //need to fix this shit fr 
            //the webservice gets ProductID = 0 even though here it gives the correct ID 
            WebClient<int> Client = new WebClient<int>()
            {
                Schema = "http",
                Port = 5134,
                Host = "localhost",
                Path = "api/StoreOwner/DeleteProduct"
            };
            Console.WriteLine("Product ID -> " + ProductID);    
            bool Deleted = await Client.PostAsync(ProductID);
            if (Deleted)
            {
                return RedirectToAction("GetCatalog", "User");
            }
            else
            {
                ViewBag["ProductError"] = true;
                return View("StoreOwnerView", "StoreOwner");
            }
        }

        [HttpPost]

        public async Task<IActionResult> DeleteSale(int ProductID)
        {
            //need to code this 
            WebClient<int> webClient = new WebClient<int>()
            {
                Schema = "http",
                Port = 5134,
                Host = "localhost",
                Path = "api/StoreOwner/DeleteSale"
            };
            bool Deleted = await webClient.PostAsync(ProductID);
            if (Deleted)
            {
                return View();
            }
            else
            {
                ViewBag["ProductError"] = true;
                return View("StoreOwnerView");
            }
        }


        
    }
}
