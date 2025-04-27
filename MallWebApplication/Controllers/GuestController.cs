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
            //works
            //complex code + documentation incoming 🗣️🗣️🗣️🔥🔥💯💯💯💯
            //the storing path in the project 
            string relativePath = null;
            // Save the uploaded image first
            if (CustomerImage != null && CustomerImage.Length > 0)
            //check if i am actually getting an image instead of getting scammed
            {
                var uploadsFolder = Path.Combine("C:\\MyMall\\Brand\\WebService", "wwwroot", "Customers");
                //get the storing folder path 
                //Directory.CreateDirectory(uploadsFolder);
                //create that directory if it doesnt exist
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(CustomerImage.FileName);
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                //that thing is complex but basically -> GUID is Globally Unique Identifier
                //this command prevents overwriting files. if i got test.jpg it would be stored as:
                //"(some 128-bit, or 16-byte identifier like: (f7e3f4c2-3293-45ab-bf13-1e4a1e5ad1be)_(FileName)"
                //in basic words, it just gives the photo string a unique ID to prevent overwriting data 
                //the final path in which the file will be stored in, combining the next things:
                //the storing folder and the file name with the GUID
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    //what is using in basic words? (in-case i forget)
                    //you execute a block of code(resource) and then dispose of it when u exit it 
                    //FileStream is like a pipe that opens the file at filePath, so we pass the filePath
                    //again, the filePath is the path where we want to store the image
                    //what is FileMode.Create? It basically overwrites the file if it exists
                    //and if it doesnt, it creates it 
                    //to sum this line: Open a file on the hard drive and prepares to write into it.
                    await CustomerImage.CopyToAsync(stream);
                    //the line above this comment basically takes the content of the string and
                    //copies it to the stream asynchronously so the server can do other things while copying the data
                    //basically: Writes the uploaded image into the opened file
                }
                relativePath = uniqueFileName;
                // This is the path you store
            }
            else
            {
                //if i did get scammed, then just tell the server to throw a
                //BadRequest (code 400) Exception
                return BadRequest("No product image uploaded.");
            }
            Console.WriteLine("The Relative Path -> " + relativePath);
            Console.WriteLine("The Relative Path Type -> " + relativePath.GetType());
            customer.CustomerIMG = relativePath;
            WebClient<Customer> Client = new WebClient<Customer>();
            Client.Schema = "http";
            Client.Port = 5134;
            Client.Host = "localhost";
            Client.Path = "api/Customer/AddNewCustomer";
            int CustomerID = await Client.RegPost(customer);
            if (CustomerID != 0)
            {
                HttpContext.Session.SetString("CustomerID", CustomerID.ToString());
                string userID = HttpContext.Session.GetString("CustomerID");
                Console.WriteLine(userID);
                return RedirectToAction("GetCatalog", "User");
            }
            else
            {
                WebClient<CityViewModel> webClient = new WebClient<CityViewModel>()
                {
                    Schema = "http",
                    Port = 5134,
                    Host = "localhost",
                    Path = "api/Customer/Cities"
                };
                CityViewModel cities = await webClient.GetAsync();
                //ViewBag["Error"] = true; why tf it crashes the whole website
                return RedirectToAction("RegistrationForm", "Guest");
            }
        }

        [HttpGet]

        //int StoreID = 0, int Percentage = 0, int StoreTypeID = 0, int BrandID = 0,
        //                                int ProductsPerPage = 15, int pageNumber = 1
        public async Task<IActionResult> GetCatalog(int ProductsPerPage = 16, int pageNumber = 1, int StoreID = 0, int Percentage = 0, int StoreTypeID = 0, int BrandID = 0)
        {
            //works
            WebClient<CatalogViewModel> Client = new WebClient<CatalogViewModel>();
            Client.Schema = "http";
            Client.Port = 5134;
            Client.Host = "localhost";
            Client.Path = "api/Customer/Catalog";
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
            if (Percentage > 0)
            {
                Client.AddParams("Percentage", Percentage.ToString());
            }
            if (BrandID > 0)
            {
                Client.AddParams("BrandID", BrandID.ToString());
            }
            CatalogViewModel productsAndSalesViewModel = await Client.GetAsync();
            return View(productsAndSalesViewModel);
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
            //works
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CustomerLogin(string CustomerFirstName, string CustomerLastName, string CustomerPassword)
        {
            //works
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
                TempData["CustomerID"] = CustomerID;
                string user = HttpContext.Session.GetString("CustomerID");
                Console.WriteLine(user);
                return RedirectToAction("GetCatalog", "User");
            }
            //ViewBag.Error = true;
            return RedirectToAction("LoginForm", "Guest");
        }

        [HttpGet]
        public async Task<IActionResult> OwnerLogin(string StoreOwnerName, string StoreOwnerLastName, int StoreOwnerID, int StoreID)
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
            Client.AddParams("StoreID", StoreID.ToString());
            int OwnerID = await Client.GetAsync();
            if (OwnerID != 0)
            {
                HttpContext.Session.SetString("StoreOwnerID", OwnerID.ToString());
                TempData["StoreOwnerID"] = OwnerID;
                HttpContext.Session.SetString("StoreID", StoreID.ToString());
                TempData["StoreID"] = StoreID;
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

//[HttpGet]
//public async Task<IActionResult> StartPage()
//{
//    return View();
//}
//[HttpGet]

//public async Task<IActionResult> RegistrationForm()
//{
//    WebClient<List<City>> Client = new WebClient<List<City>>();
//    Client.Schema = "http";
//    Client.Port = 5134;
//    Client.Host = "localhost";
//    Client.Path = "api/Customer/Cities";
//    List<City> cities = await Client.GetAsync();
//    return View(cities);
//}

//[HttpPost]

//public async Task<IActionResult> Register(Customer customer)
//{
//    WebClient<Customer> Client = new WebClient<Customer>();
//    Client.Schema = "http";
//    Client.Port = 5134;
//    Client.Host = "localhost";
//    Client.Path = "api/Customer/Register";
//    bool CustomerAdded = await Client.PostAsync(customer);
//    if (CustomerAdded)
//    {
//        return View();
//    }
//    else
//    {
//        ViewBag["Error"] = true;
//        return View("RegistrationForm");
//    }
//}

//[HttpGet]

////int StoreID = 0, int Percentage = 0, int StoreTypeID = 0, int BrandID = 0,
////                                int ProductsPerPage = 15, int pageNumber = 1
//public async Task<IActionResult> GetCatalog(int ProductsPerPage = 16, int pageNumber = 1, int StoreID = 0, int Percentage = 0, int StoreTypeID = 0, int BrandID = 0)
//{
//    WebClient<CatalogViewModel> Client = new WebClient<CatalogViewModel>();
//    Client.Schema = "http";
//    Client.Port = 5134;
//    Client.Host = "localhost";
//    Client.Path = "api/Customer/Catalog";
//    Client.AddParams("pageNumber", pageNumber.ToString());
//    Client.AddParams("ProductsPerPage", ProductsPerPage.ToString());
//    if (StoreID > 0)
//    {
//        Client.AddParams("StoreID", StoreID.ToString());
//    }
//    if (StoreTypeID > 0)
//    {
//        Client.AddParams("StoreTypeID", StoreTypeID.ToString());
//    }
//    if (Percentage > 0)
//    {
//        Client.AddParams("Percentage", Percentage.ToString());
//    }
//    if (BrandID > 0)
//    {
//        Client.AddParams("BrandID", BrandID.ToString());
//    }
//    CatalogViewModel productsAndSalesViewModel = await Client.GetAsync();
//    return View(productsAndSalesViewModel);
//}

//[HttpGet]
//public async Task<IActionResult> GetProduct(int ProductID)
//{
//    WebClient<Product> Client = new WebClient<Product>();
//    Client.Schema = "http";
//    Client.Port = 5134;
//    Client.Host = "localhost";
//    Client.Path = "api/Customer/GetProduct";
//    Client.AddParams("ProductID", ProductID.ToString());
//    Product product = await Client.GetAsync();
//    return View(product);
//}

//[HttpGet]
//public async Task<IActionResult> GetCart(int CartID)
//{
//    WebClient<CartProduct> Client = new WebClient<CartProduct>();
//    Client.Schema = "http";
//    Client.Port = 5134;
//    Client.Host = "localhost";
//    Client.Path = "api/Customer/ViewCart";
//    Client.AddParams("CartID", CartID.ToString());
//    CartProduct cartProduct = await Client.GetAsync();
//    return View(cartProduct);
//}

//[HttpGet]
//public async Task<IActionResult> ViewProfile(int CustomerID)
//{
//    WebClient<Customer> Client = new WebClient<Customer>();
//    Client.Schema = "http";
//    Client.Port = 5134;
//    Client.Host = "localhost";
//    Client.Path = "api/Customer/GetDetail";
//    Client.AddParams("CustomerID", CustomerID.ToString());
//    Customer customer = await Client.GetAsync();
//    return View(customer);
//}

//[HttpPost]
//public async Task<IActionResult> AddToCart(int CustomerID, int ProductID, int Quantity)
//{
//    WebClient<CartProduct> Client = new WebClient<CartProduct>()
//    {
//        Schema = "http",
//        Port = 5134,
//        Host = "localhost",
//        Path = "api/Customer/AddToCart"
//    };
//    Client.AddParams("CustomerID", CustomerID.ToString());
//    Client.AddParams("ProductID", ProductID.ToString());
//    Client.AddParams("Quantity", Quantity.ToString());
//    CartProduct cart = await Client.GetAsync();
//    return View(cart);
//}
//    }
//}
