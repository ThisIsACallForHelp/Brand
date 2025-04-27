using Microsoft.AspNetCore.Mvc;
using WebApiClient;
using Models;
using System.Security.Policy;
namespace MallWebApplication.Controllers
{
    public class UserController : Controller
    {
        
        public IActionResult Index()
        {
            TempData["CustomerID"] = Convert.ToInt32(HttpContext.Session.GetString("CustomerID"));
            return RedirectToAction("GetCatalog", "User");
        }




        [HttpGet]

        //int StoreID = 0, int Percentage = 0, int StoreTypeID = 0, int BrandID = 0,
        //                                int ProductsPerPage = 15, int pageNumber = 1
         
        public async Task<IActionResult> GetCatalog(int ProductsPerPage = 16, int pageNumber = 1, int StoreID = 0, int Percentage = 0, int StoreTypeID = 0, int BrandID = 0)
        {
            //works but needs styling
            //fr style this pls dont forget 
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


        [HttpPost]
        
        public async Task<IActionResult> AddProductToCart(int ProductID, int Quantity)
        {
            //works
            int CustomerID = Convert.ToInt32(HttpContext.Session.GetString("CustomerID"));
            WebClient<CartProduct> Client = new WebClient<CartProduct>()
            {
                Schema = "http",
                Port = 5134,
                Host = "localhost",
                Path = "api/Customer/AddToCart"
            };
            CartProduct cartProduct = new CartProduct
            {
                ProductID = ProductID,
                Quantity = Quantity,
                CustomerID = CustomerID
            };
            bool cart = await Client.PostAsync(cartProduct);
            if (cart)
            {
                return RedirectToAction("GetCart" , "User");
            }
            else
            {
                return null;
            }
        }

        [HttpGet]
        public async Task<IActionResult> ViewProfile()
        {
            //nvm it works im goated with the sauce  
            int CustomerID = Convert.ToInt32(HttpContext.Session.GetString("CustomerID"));
            WebClient<ViewCustomerDetails> Client = new WebClient<ViewCustomerDetails>();
            Client.Schema = "http";
            Client.Port = 5134;
            Client.Host = "localhost";
            Client.Path = "api/Customer/GetDetail";
            Client.AddParams("CustomerID", CustomerID.ToString());
            Console.WriteLine("cusotmer id -> " + CustomerID);
            ViewCustomerDetails Details = new ViewCustomerDetails()
            {
                CustomerID = CustomerID
            };
            Details = await Client.GetAsync();
            return View(Details);
        }


        
        [HttpGet]
        public async Task<IActionResult> GetCart()
        {
            //works
            int CustomerID = Convert.ToInt32(HttpContext.Session.GetString("CustomerID"));
            WebClient<CustomerCartViewModel> Client = new WebClient<CustomerCartViewModel>();
            Client.Schema = "http";
            Client.Port = 5134;
            Client.Host = "localhost";
            Client.Path = "api/Customer/ViewCart";
            Client.AddParams("CustomerID", CustomerID.ToString());
            CustomerCartViewModel cartProduct = await Client.GetAsync();
            cartProduct.CustomerID = CustomerID;
            return View(cartProduct);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveProductFromCart(int ProductID, int CustomerID)
        {
            //works ong fr fr 
            WebClient<CartProduct> Client = new WebClient<CartProduct>()
            {
                Schema = "http",
                Port = 5134,
                Host = "localhost",
                Path = "api/Customer/RemoveFromCart"
            };
            CartProduct cartProduct = new CartProduct()
            {
                CustomerID = CustomerID,
                ProductID = ProductID
            };
            bool cart = await Client.PostAsync(cartProduct);
            if (cart)
            {
                return RedirectToAction("GetCatalog", "User");
            }
            else
            {
                return null;
            }
        }



        
    }
}
