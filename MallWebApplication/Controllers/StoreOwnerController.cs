using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Execution;
using Microsoft.CodeAnalysis;
using Models;
using System.Net;
using System.Runtime.CompilerServices;
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
            //works 
            Console.WriteLine("On sale ->" + OnSale);
            HttpContext.Session.SetString("OnSale", OnSale.ToString());
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
            StoreOwnerViewModel products = await Client.GetAsync();
            return View(products);
        }


        


        [HttpPost]
        //works
        public async Task<IActionResult> AddProduct(string ProductName, int ProductPrice, int ProductID,int BrandID, int Percentage, IFormFile ProductIMG,int StoreID)
        {
           
            string RelativePath = null;
            if (ProductIMG != null && ProductIMG.Length > 0)
            {
                var UploadsFolder = Path.Combine("C:\\MyMall\\Brand\\WebService", "wwwroot", "Products");
                var UniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(ProductIMG.FileName);
                var FilePath = Path.Combine(UploadsFolder, UniqueFileName);
                using (var stream = new FileStream(FilePath, FileMode.Create))
                {
                    await ProductIMG.CopyToAsync(stream);
                }
                RelativePath = UniqueFileName;
            }
            else
            {
                ViewBag.Error = true;
            }                
            Console.WriteLine("The Relative Path -> " + RelativePath);
            Console.WriteLine("The Relative Path Type -> " + RelativePath.GetType());
            WebClient<Product> Client = new WebClient<Product>()
            {
                Schema = "http",
                Port = 5134,
                Host = "localhost",
                Path = "api/StoreOwner/AddNewProductToStore"
            };
            Product product = new Product()
            {
                ProductName = ProductName,
                ProductPrice = ProductPrice,
                ProductBrand = BrandID,
                SaleID = (Percentage - (Percentage % 5)) / 5,
                StoreID = StoreID,
                ProductIMG = RelativePath,
                ID = ProductID,
            };

            bool CustomerAdded = await Client.PostAsync(product);

            if (CustomerAdded)
            {
                return RedirectToAction("StoreOwnerView", "StoreOwner"); 
            }
            else
            {
                return null;
            }
        }
        
        [HttpPost]
        //works
        public async Task<IActionResult> AddSale(int ProductID, int Percentage)
        {
            WebClient<Product> Client = new WebClient<Product>()
            {
                Schema = "http",
                Port = 5134,
                Host = "localhost",
                Path = "api/StoreOwner/AddNewSale"
            };
            Product product = new Product()
            {
                ID = ProductID,
                SaleID = (Percentage - (Percentage % 5)) / 5
            };
            bool CustomerAdded = await Client.PostAsync(product);
            if (CustomerAdded)
            {
                return RedirectToAction("StoreOwnerView", "StoreOwner");
            }
            else
            {
                return null;
            }

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int ProductID)
        {
            //works
            Product product = new Product()
            {
                ID = ProductID
            };
            string OnSale = HttpContext.Session.GetString("OnSale");
            Console.WriteLine("Product ID -> " + ProductID);
            Console.WriteLine("OnSale -> " + OnSale);
            WebClient<Product> Client = new WebClient<Product>()
            {
                Schema = "http",
                Port = 5134,
                Host = "localhost",
            };
            if (OnSale.Equals("True"))
            {
                Client.Path = "api/StoreOwner/DeleteSale";             
            }
            else
            {
                Client.Path = "api/StoreOwner/DeleteProduct";
            }                
            Console.WriteLine("Product ID -> " + product.ID);
            bool Deleted = await Client.PostAsync(product);
            if (Deleted)
            {
                return RedirectToAction("StoreOwnerView", "StoreOwner");
            }
            else
            {
                return null;
            }
        }

        [HttpGet]

        public IActionResult AddProductForm()
        {
            //works
            return View();
        }

        [HttpGet]
        public IActionResult AddSaleForm()
        {
            //works
            return View();
        }


    }
}
