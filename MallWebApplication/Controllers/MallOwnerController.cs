using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Models;
using WebApiClient;
namespace MallWebApplication.Controllers
{
    public class MallOwnerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ProductsFromStore(int StoreID)
        {
            WebClient<List<Product>> client = new WebClient<List<Product>>()
            {
                Schema = "http",
                Port = 5134,
                Host = "localhost",
                Path = "api/MallOwner/GetProductsFromStore"
            };
            client.AddParams("StoreID", StoreID.ToString());
            List<Product> Products = await client.GetAsync();
            return View(Products);
        }

        [HttpGet]
        public async Task<IActionResult> ViewMasterList(int choice)
        {
            WebClient<MallOwnerViewModel> client = new WebClient<MallOwnerViewModel>()
            {
                Schema = "http",
                Port = 5134,
                Host = "localhost",
                Path = "api/MallOwner/GetMasterList"
            };
            client.AddParams("choice", choice.ToString());
            MallOwnerViewModel mallOwnerViewModel = await client.GetAsync();
            return View(mallOwnerViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> MakeStore(Store store)
        {
            WebClient<Store> Client = new WebClient<Store>()
            {
                Schema = "http",
                Port = 5134,
                Host = "localhost",
                Path = "api/MallOwner/CreateStore"
            };
            bool StoreAdded = await Client.PostAsync(store);
            if (StoreAdded)
            {
                return View();
            }
            else
            {
                ViewBag["StoreError"] = true;
                return View("ViewMasterList");
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStore(Store store)
        {
            WebClient<Store> Client = new WebClient<Store>()
            {
                Schema = "http",
                Port = 5134,
                Host = "localhost",
                Path = "api/MallOwner/UpdateStore"
            };
            bool StoreAdded = await Client.PostAsync(store);
            if (StoreAdded)
            {
                return View();
            }
            else
            {
                ViewBag["StoreError"] = true;
                return View("ViewMasterList");
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteStore(int storeID)
        {
            WebClient<int> Client = new WebClient<int>()
            {
                Schema = "http",
                Port = 5134,
                Host = "localhost",
                Path = "api/MallOwner/DeleteStore"
            };
            bool StoreAdded = await Client.PostAsync(storeID);
            if (StoreAdded)
            {
                return View();
            }
            else
            {
                ViewBag["StoreError"] = true;
                return View("ViewMasterList");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetStore(int StoreID)
        {
            WebClient<Store> client = new WebClient<Store>()
            {
                Schema = "http",
                Port = 5134,
                Host = "localhost",
                Path = "api/MallOwner/GetStoreByID"
            };
            client.AddParams("StoreID", StoreID.ToString());
            return View(client);
        }

        [HttpGet]
        public async Task<IActionResult> GetProduct(int ProductID)
        {
            WebClient<Product> client = new WebClient<Product>()
            {
                Schema = "http",
                Port = 5134,
                Host = "localhost",
                Path = "api/MallOwner/GetProductByID"
            };
            client.AddParams("ProductID", ProductID.ToString());
            return View(client);
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomer(int CustomerID)
        {
            WebClient<Customer> client = new WebClient<Customer>()
            {
                Schema = "http",
                Port = 5134,
                Host = "localhost",
                Path = "api/MallOwner/GetCustomerByID"
            };
            client.AddParams("CustomerID", CustomerID.ToString());
            return View(client);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteOwner(int StoreOwnerID)
        {
            WebClient<int> client = new WebClient<int>()
            {
                Schema = "http",
                Port = 5134,
                Host = "localhost",
                Path = "api/MallOwner/GetStoreByID"
            };
            bool Deleted = await client.PostAsync(StoreOwnerID);
            if (Deleted)
            {
                return View("ViewMasterList");
            }
            return RedirectToAction("Exception");
        }

        [HttpGet]
        public IActionResult Exception()
        {
            return View();
        }


    }
}
