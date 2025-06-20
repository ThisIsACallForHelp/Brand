﻿using MallWebApplication;
using Microsoft.AspNetCore.Mvc;
using Models;
using WebApiClient;
namespace MallWebApplication
{
    public class GuestController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> StartPage()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> RegistrationForm()
        {
            //works
            WebClient<CityViewModel> Client = new WebClient<CityViewModel>();
            Client.Schema = "http";
            Client.Port = 5134;
            Client.Host = "localhost";
            Client.Path = "api/Customer/Cities";
            CityViewModel cities = await Client.GetAsync();
            return View(cities);
        }

        [HttpPost]
        public async Task<IActionResult> Register(Customer customer, IFormFile CustomerImage)
        {            
            string RelativePath = null;           
            if (CustomerImage != null && CustomerImage.Length > 0)
            {
                var UploadsFolder = Path.Combine("C:\\MyMall\\Brand\\WebService", "wwwroot", "Customers");
                var UniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(CustomerImage.FileName);
                var FilePath = Path.Combine(UploadsFolder, UniqueFileName);
                using (var stream = new FileStream(FilePath, FileMode.Create))
                {
                    await CustomerImage.CopyToAsync(stream);
                }
                RelativePath = UniqueFileName;
            }
            else
            {
                ViewBag.Error = true;
            }
            customer.CustomerIMG = RelativePath;
            WebClient<Customer> Client = new WebClient<Customer>();
            Client.Schema = "http";
            Client.Port = 5134;
            Client.Host = "localhost";
            Client.Path = "api/Customer/AddNewCustomer";
            int CustomerID = await Client.RegPost(customer);
            if (CustomerID != 0)
            {
                HttpContext.Session.SetString("CustomerID", CustomerID.ToString());
                return RedirectToAction("GetCatalog", "User");
            }
            else
            {
                ViewBag.Error = true;
                return RedirectToAction("RegistrationForm", "Guest");
            }
        }

        [HttpGet]

      
        public async Task<IActionResult> GetCatalog(int SaleID, int StoreID, int StoreTypeID, int BrandID, int ProductsPerPage = 16, int pageNumber = 1)
        {
            //works
            WebClient<CatalogViewModel> Client = new WebClient<CatalogViewModel>();
            Client.Schema = "http";
            Client.Port = 5134;
            Client.Host = "localhost";
            Client.Path = "api/Customer/Catalog";
            Console.WriteLine("SaleID -> " + SaleID);
            Client.AddParams("pageNumber", pageNumber.ToString());
            Client.AddParams("ProductsPerPage", ProductsPerPage.ToString());
            if (StoreID > 0)
            {
                Client.AddParams("StoreID", StoreID.ToString());
            }
            if (StoreTypeID > 0)
            {
                Client.AddParams("StoreTypeID", StoreTypeID.ToString());
            }
            Client.AddParams("SaleID", SaleID.ToString());
            if (BrandID > 0)
            {
                Client.AddParams("BrandID", BrandID.ToString());
            }
            CatalogViewModel productsAndSalesViewModel = await Client.GetAsync();
            return View(productsAndSalesViewModel);
        }

        public async Task<PartialViewResult> GetProductCatalog(int SaleID, int StoreID, int StoreTypeID, int BrandID, int ProductsPerPage = 16, int pageNumber = 1)
        {

            //this is the catalog that USES THE AJAX
            //all of the CSS from the masterpage is gone, logical since Partial View
            //but i want and need that style from the masterpage i dont know what to do 
            WebClient<CatalogViewModel> Client = new WebClient<CatalogViewModel>();
            Client.Schema = "http";
            Client.Port = 5134;
            Client.Host = "localhost";
            Client.Path = "api/Customer/AJAXCatalog";
            Client.AddParams("pageNumber", pageNumber.ToString());
            Client.AddParams("ProductsPerPage", ProductsPerPage.ToString());
            if (StoreID > 0)
            {
                Client.AddParams("StoreID", StoreID.ToString());
            }
            if (StoreTypeID > 0)
            {
                Client.AddParams("StoreTypeID", StoreTypeID.ToString());
            }
            Client.AddParams("SaleID", SaleID.ToString());
            if (BrandID > 0)
            {
                Client.AddParams("BrandID", BrandID.ToString());
            }
            CatalogViewModel productsAndSalesViewModel = await Client.GetAsync();
            return PartialView(productsAndSalesViewModel);
        }

        //Guest/GetProduct?ProductID=4
        [HttpGet]
        public async Task<IActionResult> GetProduct(int ProductID)
        {
            //works
            WebClient<ViewProduct> Client = new WebClient<ViewProduct>();
            Client.Schema = "http";
            Client.Port = 5134; //12 is an example, it will be changed later
            Client.Host = "localhost";
            Client.Path = "api/Customer/GetProduct";
            Client.AddParams("ProductID", ProductID.ToString());
            ViewProduct product = await Client.GetAsync();
            return View(product);
        }
        [HttpGet]
        public IActionResult LoginForm()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CustomerLogin(string CustomerFirstName, string CustomerLastName, string CustomerPassword)
        {
            WebClient<int> Client = new WebClient<int>()
            {
                Schema = "http",
                Port = 5134,
                Host = "localhost",
                Path = "api/Customer/LoginAttempt"
            };
            Client.AddParams("CustomerFirstName", CustomerFirstName);
            Client.AddParams("CustomerLastName", CustomerLastName);
            Client.AddParams("CustomerPassword", CustomerPassword);
            int CustomerID = await Client.GetAsync();
            if (CustomerID != 0)
            {
                HttpContext.Session.SetString("CustomerID", CustomerID.ToString());
                return RedirectToAction("GetCatalog", "User");
            }
            ViewBag.Error = true;
            return RedirectToAction("LoginForm", "Guest");
        }

        [HttpGet]
        public async Task<IActionResult> OwnerLogin(string StoreOwnerName, string StoreOwnerLastName, int StoreOwnerID)
        {
            //works
            WebClient<int> Client = new WebClient<int>()
            {
                Schema = "http",
                Port = 5134,
                Host = "localhost",
                Path = "api/StoreOwner/OwnerSignIn"
            };
            Client.AddParams("StoreOwnerName", StoreOwnerName);
            Client.AddParams("StoreOwnerLastName", StoreOwnerLastName);
            Client.AddParams("StoreOwnerID", StoreOwnerID.ToString());
            int OwnerID = await Client.GetAsync();
            if (OwnerID != 0)
            {
                HttpContext.Session.SetString("StoreOwnerID", OwnerID.ToString());
                TempData["StoreOwnerID"] = OwnerID;
                return RedirectToAction("StoreOwnerView", "StoreOwner");
            }
            //ViewBag.Error = true;
            return View("OwnerLoginForm", "Guest");
        }
        [HttpGet]
        public IActionResult OwnerLoginForm()
        {
            //works
            return View();
        }
    }
}

