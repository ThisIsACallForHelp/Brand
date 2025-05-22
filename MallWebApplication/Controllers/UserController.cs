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
            return RedirectToAction("GetCatalog", "User");
        }




        [HttpGet]

        //int StoreID = 0, int Percentage = 0, int StoreTypeID = 0, int BrandID = 0,
        //                                int ProductsPerPage = 15, int pageNumber = 1
         
        public async Task<IActionResult> GetCatalog(int SaleID, int ProductsPerPage = 16, int pageNumber = 1, int StoreID = 0, int StoreTypeID = 0, int BrandID = 0)
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
            Client.AddParams("Percentage", SaleID.ToString());
            if (BrandID > 0)
            {
                Client.AddParams("BrandID", BrandID.ToString());
            }
            CatalogViewModel productsAndSalesViewModel = await Client.GetAsync();
            return View(productsAndSalesViewModel);
        }


        public async Task<PartialViewResult> GetProductCatalog(int SaleID, int ProductsPerPage = 16, int pageNumber = 1, int StoreID = 0, int StoreTypeID = 0, int BrandID = 0)
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
            if (SaleID > 0)
            {
                Client.AddParams("Percentage", SaleID.ToString());
            }
            if (BrandID > 0)
            {
                Client.AddParams("BrandID", BrandID.ToString());
            }
            CatalogViewModel productsAndSalesViewModel = await Client.GetAsync();
            return PartialView(productsAndSalesViewModel);
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
            WebClient<CartProduct> Client = new WebClient<CartProduct>()
            {
                Schema = "http",
                Port = 5134,
                Host = "localhost",
                Path = "api/Customer/AddToCart"
            };
            Console.WriteLine("Quantity ->" + Quantity);
            CartProduct cartProduct = new CartProduct
            {
                ProductID = ProductID,
                Quantity = Quantity,
                CustomerID = Convert.ToInt32(HttpContext.Session.GetString("CustomerID"))
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
            //nvm it works the register finally hands out the ID
            WebClient<ViewCustomerDetails> Client = new WebClient<ViewCustomerDetails>();
            Client.Schema = "http";
            Client.Port = 5134;
            Client.Host = "localhost";
            Client.Path = "api/Customer/GetDetail";
            Client.AddParams("CustomerID", HttpContext.Session.GetString("CustomerID"));
            Console.WriteLine("cusotmer id -> " + Convert.ToInt32(HttpContext.Session.GetString("CustomerID")));
            ViewCustomerDetails Details = new ViewCustomerDetails()
            {
                CustomerID = Convert.ToInt32(HttpContext.Session.GetString("CustomerID"))
            };
            Details = await Client.GetAsync();
            return View(Details);
        }


        
        [HttpGet]
        public async Task<IActionResult> GetCart()
        {
            //works
            WebClient<CustomerCartViewModel> Client = new WebClient<CustomerCartViewModel>();
            Client.Schema = "http";
            Client.Port = 5134;
            Client.Host = "localhost";
            Client.Path = "api/Customer/ViewCart";
            Client.AddParams("CustomerID", HttpContext.Session.GetString("CustomerID"));
            CustomerCartViewModel cartProduct = await Client.GetAsync();
            cartProduct.CustomerID = Convert.ToInt32(HttpContext.Session.GetString("CustomerID"));
            return View(cartProduct);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveProductFromCart(int ProductID, int CustomerID)
        {
            //works
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
