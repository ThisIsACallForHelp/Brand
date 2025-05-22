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
            StoreOwnerViewModel products = new StoreOwnerViewModel()
            {
                StoreOwnerID = StoreOwnerID,
                OnSale = OnSale
            };
            products = await Client.GetAsync();
            return View(products);
        }


        


        [HttpPost]
        //works
        public async Task<IActionResult> AddProduct(string ProductName, int ProductPrice, int ProductID,int BrandID, int Percentage, IFormFile ProductIMG,int StoreID)
        {
            //complex code + documentation incoming 🗣️🗣️🗣️🔥🔥💯💯💯💯
            //the storing path in the project 
            string RelativePath = null;
            // Save the uploaded image first
            if (ProductIMG != null && ProductIMG.Length > 0)
            //check if i am actually getting an image instead of getting scammed
            {
                var UploadsFolder = Path.Combine("C:\\MyMall\\Brand\\WebService", "wwwroot", "Products");
                //get the storing folder path 
                //Directory.CreateDirectory(uploadsFolder);
                //create that directory if it doesnt exist
                var UniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(ProductIMG.FileName);
                var FilePath = Path.Combine(UploadsFolder, UniqueFileName);
                //that thing is complex but basically -> GUID is Globally Unique Identifier
                //this command prevents overwriting files. if i got test.jpg it would be stored as:
                //"(some 128-bit, or 16-byte identifier like: (f7e3f4c2-3293-45ab-bf13-1e4a1e5ad1be)_(FileName)"
                //in basic words, it just gives the photo string a unique ID to prevent overwriting data 
                //the final path in which the file will be stored in, combining the next things:
                //the storing folder and the file name with the GUID
                using (var stream = new FileStream(FilePath, FileMode.Create))
                {
                    //what is using in basic words? (in-case i forget)
                    //you execute a block of code(resource) and then dispose of it when u exit it 
                    //FileStream is like a pipe that opens the file at filePath, so we pass the filePath
                    //again, the filePath is the path where we want to store the image
                    //what is FileMode.Create? It basically overwrites the file if it exists
                    //and if it doesnt, it creates it 
                    //to sum this line: Open a file on the hard drive and prepares to write into it.
                    await ProductIMG.CopyToAsync(stream);
                    //the line above this comment basically takes the content of the string and
                    //copies it to the stream asynchronously so the server can do other things while copying the data
                    //basically: Writes the uploaded image into the opened file
                }
                //if the image doesnt show up just remove the "Products" from the string
                RelativePath = UniqueFileName;
                // This is the path you store the data in 
            }
            else
            {
                ViewBag.Error = true;
            }                
            Console.WriteLine("The Relative Path -> " + RelativePath);
            Console.WriteLine("The Relative Path Type -> " + RelativePath.GetType());
            // Create the Client now
            WebClient<Product> Client = new WebClient<Product>()
            {
                Schema = "http",
                Port = 5134,
                Host = "localhost",
                Path = "api/StoreOwner/AddNewProductToStore"
            };
            //Create the Product
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
