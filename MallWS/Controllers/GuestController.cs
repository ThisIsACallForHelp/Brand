
using Microsoft.AspNetCore.Http;
using Models;
using Microsoft.AspNetCore.Mvc;

namespace MallWebService
{
    [Route("api/[controller]/[action]")] // api , name of the controller, name of the action 
    [ApiController]
    public class GuestController : ControllerBase
    {
            DBContext dbContext; //the DBContext 
            UnitOfWork unitOfWork { get; set; }
            public GuestController() //constructor 
            {
                this.dbContext = DBContext.GetInstance(); //get instance of DBContext
                this.unitOfWork = new UnitOfWork(this.dbContext); //unit of work
            }

            [HttpGet] //we are trying to log in, not register. so it is an HTTP GET packet
            public Customer LoginCustomer(string CustomerFirstName, string CustomerLastName, string CustomerPassword)
                //get all of the info 
            {
                try
                {
                    this.dbContext.OpenConnection(); //open connection
                    return unitOfWork.CustomerRepository.LoginAttempt(CustomerFirstName, CustomerLastName, CustomerPassword);
                    //return all the info about the customer 
                }
                catch (Exception ex) //if there is an excepion
                {
                    string message = ex.Message; //create a string showing it 
                    Console.WriteLine(message); //print it 
                    return null; //return null (error)
                }
                finally
                {
                    this.dbContext.CloseConnection(); //close connection no matter what 
                }
            }
            //we are talking about registration which requires inserting a new Customer 
            //to the DB, so its an HTTP POST packet
            [HttpPost]
            public bool AddNewCustomer(Customer customer) //get all of the info you need 
            {
                try
                {
                    this.dbContext.OpenConnection(); //open the connection 
                    return unitOfWork.CustomerRepository.Create(customer);
                    //create a customer 
                }
                catch (Exception ex) //catch and exception
                {
                    string Message = ex.Message; //make it a string
                    Console.WriteLine(Message); //print it 
                    return false; //return false (registration failed)
                }
                finally
                {
                    this.dbContext.CloseConnection(); //close the connection
                }
            }
            
            //we are updating info in our DB, so it's a HTTP POST packet 
            [HttpPost]
            public bool UpdateCustomerInfo(Customer customer) //get all of the info
            {
                try
                {
                    this.dbContext.OpenConnection(); //open connection
                    return unitOfWork.CustomerRepository.Update(customer);
                    //take all of the new info and update the user
                }
                catch (Exception ex) //if there is an error 
                {
                    string message = ex.Message; //convert the exception to string 
                    Console.WriteLine(message); //print it 
                    return false; //return false (error)
                }
                finally
                {
                    this.dbContext.CloseConnection(); //close connection
                }
            }
            //we want to get the catalog, so its an HTTP GET packet 
            [HttpGet]
            public CatalogViewModel GetStoreCatalog() //get the store catalog
            {
                CatalogViewModel catalogViewModel = new CatalogViewModel(); 
                //create a new Store catalog object
                try
                {
                    this.dbContext.OpenConnection(); //open connection 
                    List<Store> allStores = unitOfWork.StoreRepository.GetAll().ToList(); 
                    //create a list of stores since we are showing all of the stores.
                    //from the initialization of the list, call the repository to get all of the stores and 
                    //fill the list  
                    catalogViewModel.Stores = allStores; //the object's store list is all of our stores 
                    return catalogViewModel; //return the catalog 
                }
                catch (Exception ex) //catch an exception 
                {
                    string message = ex.Message; //make it a string
                    Console.WriteLine(message); //print it 
                    return null; //return null 
                }
                finally
                {
                    this.dbContext.CloseConnection(); //close the connection 
                }
            }

            //we want to request a brand catalog, so that is a HTTP GET packet 
            [HttpGet]
            public BrandCatalogViewModel GetBrandCatalog()
            {
                BrandCatalogViewModel brandCatalogViewModel = new BrandCatalogViewModel();
                //create a Brand catalog object 
                try
                {
                    this.dbContext.OpenConnection();
                    List<Brand> AllBrands = unitOfWork.BrandRepository.GetAll().ToList();
                    //fill the list with all the brands  
                    brandCatalogViewModel.Brands = AllBrands;
                    //asign the object's list to be the brand list
                    return brandCatalogViewModel; //return the object 
                }
                catch (Exception ex) //if there is an exception 
                {
                    string message = ex.Message; //make it a string 
                    Console.WriteLine(message); //print it 
                    return null; //return null 
                }
                finally
                {
                    this.dbContext.CloseConnection(); //close connection 
                }
            }

            //we want to get a store type list, so its an HTTP GET packet
            [HttpGet]
            public List<Store> GetStoreTypeList()
            {
                try
                {
                    this.dbContext.OpenConnection();
                    return this.unitOfWork.StoreRepository.GetTypeList();
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                    Console.WriteLine(message);
                    return null;
                }
                finally
                {
                    this.dbContext.CloseConnection();
                }
            }

            //we want to get all of the stores by their types, so its an HTTP GET packet 
            [HttpGet]
            public CatalogViewModel GetStoreByType(string StoreType)
            //return the catalog of store by a specific request 
            {
                CatalogViewModel TypeCatalogViewModel = new CatalogViewModel();
                try
                {
                    this.dbContext.OpenConnection(); //open connection
                    List<Store> TypeStores = unitOfWork.StoreRepository.GetStoreByType(StoreType).ToList();
                    //create a list with the stores in it and use the function we built 
                    //in the repository, which returns a list of all the stores with a specific type 
                    TypeCatalogViewModel.Stores = TypeStores;
                    //asign a value to our list 
                    return TypeCatalogViewModel; //return it!
                }
                catch (Exception ex) //if there was an error 
                {
                    string message = ex.Message; //make a string 
                    Console.WriteLine(message); //print it out 
                    return null; //return null 
                }
                finally
                {
                    this.dbContext.CloseConnection(); //close the connection 
                }
            }

            //we want to get a page with stores by their brands, so its an HTTP GET  packet 
            [HttpGet]
            public CatalogViewModel GetStoresByBrand(Brand brand) //get the brand 
            {
                CatalogViewModel StoreByTypeCatalogViewModel = new CatalogViewModel();
                //the view model object
                try
                {
                    this.dbContext.OpenConnection(); //open connection 
                    List<Store> StoreByBrand = unitOfWork.StoreRepository.GetStoresByBrand(brand).ToList();
                    //asign the values to the list
                    StoreByTypeCatalogViewModel.Stores = StoreByBrand; //give the lsit it's values 
                    return StoreByTypeCatalogViewModel; //return it 
                }
                catch (Exception ex) //if there is an error 
                {
                    string message = ex.Message; //make a string 
                    Console.WriteLine(message); //print it 
                    return null; //return null
                }
                finally
                {
                    this.dbContext.CloseConnection(); //close connection 
                }
            }
            //we want to see the products on sale 
            [HttpGet]
            public ProductCatalogViewModel GetProductsBySale()
            {
                ProductCatalogViewModel saleCatalogViewModel = new ProductCatalogViewModel();
                //create a new object 
                try
                {
                    this.dbContext.OpenConnection(); //open connection 
                    List<Product> SaleList = unitOfWork.ProductRepository.GetBySales();
                    //create a list that contains all of the products on sale 
                    saleCatalogViewModel.ProductsOnSale = SaleList;
                    //asign the Products on sale list 
                    return saleCatalogViewModel;
                    //return it
                }
                catch (Exception ex) //catch an exception
                {
                    string message = ex.Message; //make it a string 
                    Console.WriteLine(message); //print it 
                    return null; //return null
                }
                finally
                {
                    this.dbContext.CloseConnection(); //close connection 
                }
            }
            //this time, we are adding a product into the cart, so its an HTTP POST packet 
            [HttpPost]
            public bool InsertInTheCart(Product product) //get a product 
            {
                try
                {
                    this.dbContext.OpenConnection(); //open the connection
                    return this.unitOfWork.CartRepository.ProductIntoCart(product); //insert it 
                }
                catch (Exception ex) //catch an error 
                {
                    string message = ex.Message; //make it a string 
                    Console.WriteLine(message); //print it 
                    return false; //return flase 
                }
                finally
                {
                    this.dbContext.CloseConnection(); //close the connection
                }
            }
            //we are deleting a product from Customer's cart, so it's an HTTP POST packet
            [HttpPost]
            public bool DeleteFromTheCart(Product product) //delete a product from cart
            {
                try
                {
                    this.dbContext.OpenConnection(); //open connection 
                    return this.unitOfWork.CartRepository.DeleteProductInCart(product); //delete it 
                }
                catch (Exception ex) //catch an exception 
                {
                    string message = ex.Message; //make it a string 
                    Console.WriteLine(message); //print it 
                    return false; //return flase
                }
                finally
                {
                    this.dbContext.CloseConnection(); //close the connection
                }
            }
            //we are getting all products from a store, so it's an HTTP GET packet
            [HttpGet]
            public ProductCatalogViewModel GetAllFromStore(Store store) 
            //get a store                
            {
                ProductCatalogViewModel productCatalogViewModel = new ProductCatalogViewModel();
                //product catalog view model object
                try
                {
                    this.dbContext.OpenConnection();
                    List<Product> ProductsFromStore = unitOfWork.ProductRepository.GetProductsFromStore(store);
                    //create a list of products from a requested store  
                    productCatalogViewModel.ProductsOnSale = ProductsFromStore;
                    //give the list it's value
                    return productCatalogViewModel; //return it 
                }
                catch (Exception ex) //if an error occured:
                {
                    string message = ex.Message; //make it a string 
                    Console.WriteLine(message); //print it 
                    return null; //return null
                }
                finally
                {
                    this.dbContext.CloseConnection(); //close the connection 
                }
            }
            //PLEEEEASE HELP MY FINGERS ARE ON FIRE AFTER TYPING THAT MUCHHHH
            //Also fixed some strange stuff, new version 
    }

}

