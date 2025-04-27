using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;
using System.Linq;
using System.Collections.Generic;
using Models;
using System.Security.Cryptography.X509Certificates;
using System.Reflection.Metadata.Ecma335;

namespace WebService
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        DBContext dbContext;
        UnitOfWork unitOfWork;

        public CustomerController()
        {
            this.dbContext = DBContext.GetInstance();
            this.unitOfWork = new UnitOfWork(this.dbContext);
        }

        [HttpGet]
        public CityViewModel Cities() //works
        {
            CityViewModel cityViewModel = new CityViewModel();
            try
            {
                this.dbContext.OpenConnection();
                cityViewModel.cities = this.unitOfWork.CityRepository.GetAll();
                return cityViewModel;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
            finally
            {
                this.dbContext.CloseConnection();
            }
        }
        [HttpGet]
        public int LoginAttempt(string CustomerFirstName, string CustomerLastName, string CustomerPassword)
            //works PERFECTLY   
        {
            try
            {
                this.dbContext.OpenConnection();
                return this.unitOfWork.CustomerRepository.GetCustomerID(CustomerFirstName, CustomerLastName, CustomerPassword);               
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return 0; 
            }
            finally
            {
                this.dbContext.CloseConnection();
            }
        }

        [HttpPost]
        public int AddNewCustomer(Customer customer)
        {
            try
            {
                this.dbContext.OpenConnection();
                return this.unitOfWork.CustomerRepository.CreateAndGetID(customer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return 0;
            }
            finally
            {
                
                this.dbContext.ClearParameters();
                this.dbContext.CloseConnection();
            }
        }

        [HttpPost]
        public bool CreateCart(int CustomerID)
        {
            try
            {
                this.dbContext.OpenConnection();
                return this.unitOfWork.CartRepository.CreateWithID(CustomerID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                this.dbContext.CloseConnection();
            }
        }
        [HttpPost]
        public bool UpdateCustomer(Customer customer)
        {

            try
            {
                this.dbContext.OpenConnection();
                return this.unitOfWork.CustomerRepository.Update(customer);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                this.dbContext.ClearParameters();
                this.dbContext.CloseConnection();
            }
        }

        //StoreID > 0, BrandID == 0, Sale ==0
        //StoreID > 0, BrandID == 0, Sale > 0
        //StoreID == 0, BrandID > 0, Sale > 0
        //StoreID == 0, BrandID == 0, SaleID > 0
        //All == 0

        [HttpGet]
        public CatalogViewModel Catalog(int StoreID = 0, int Percentage = 0, int StoreTypeID =0, int BrandID =0,
                                        int ProductsPerPage = 16, int pageNumber = 1)
        {
            CatalogViewModel catalogViewModel = new CatalogViewModel();
            try
            {
                this.dbContext.OpenConnection();
                List<Product> products = new List<Product>();
                int SaleID = (Percentage + (Percentage % 5)) / 5;
                catalogViewModel.Products = null;
                if (StoreTypeID > 0)
                {
                    catalogViewModel.stores = this.unitOfWork.StoreRepository.GetStoresByType(StoreTypeID);
                }
                if(StoreID > 0 && Percentage > 0 && BrandID == 0)
                {
                    BrandID = 0;
                    products = this.unitOfWork.ProductRepository.CheckSaleAndStore(SaleID, StoreID);
                }
                if (Percentage > 0 && StoreID == 0 && BrandID ==0)
                {
                    products = this.unitOfWork.ProductRepository.PercentSalesRangeList(Percentage);
                }
                if (Percentage == 0 && StoreID > 0 && BrandID == 0)
                {
                    products = this.unitOfWork.ProductRepository.ProductsFromStore(StoreID);
                }
                if(BrandID > 0 && Percentage > 0 && StoreID == 0)
                {
                    StoreID = 0;
                    products = this.unitOfWork.ProductRepository.FromBrandAndSale(SaleID, StoreID);
                }
                if(StoreID > 0 && BrandID == 0 && Percentage == 0)
                {
                    products = this.unitOfWork.ProductRepository.ProductsFromStore(StoreID);
                }
                else
                {
                    products = this.unitOfWork.ProductRepository.GetAll();
                }
                catalogViewModel.PageNumber = products.Count / ProductsPerPage;
                if(products.Count % ProductsPerPage > 0)
                {
                    catalogViewModel.PageNumber++;
                }
                products = products.Skip((pageNumber - 1)*ProductsPerPage).Take(ProductsPerPage * pageNumber).ToList();
                catalogViewModel.Products = products;
                catalogViewModel.PageNumber = pageNumber;
                catalogViewModel.stores = this.unitOfWork.StoreRepository.GetAll();
                catalogViewModel.storeTypes = this.unitOfWork.StoreTypeRepository.GetAll();
                catalogViewModel.Percentage = Percentage;
                catalogViewModel.Brands = this.unitOfWork.BrandRepository.GetAll();
                catalogViewModel.PageNumber = pageNumber;
                catalogViewModel.StoreTypeID = StoreTypeID;
                catalogViewModel.StoreID = StoreID;
                catalogViewModel.BrandID = BrandID;
                return catalogViewModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
            finally
            {
                this.dbContext.ClearParameters();
                this.dbContext.CloseConnection();
            }
        }

        [HttpPost]
        public bool AddToCart(CartProduct cart)
        {
            
            try
            {
                this.dbContext.OpenConnection();
                return this.unitOfWork.CartProductRepository.Create(cart);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                this.dbContext.ClearParameters();
                this.dbContext.CloseConnection();
            }
        }

        [HttpPost]
        public bool RemoveFromCart(CartProduct cartProduct)
        {           
            try
            {
                this.dbContext.OpenConnection();
                return this.unitOfWork.CartProductRepository.DeleteByIDs(cartProduct);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                this.dbContext.ClearParameters();
                this.dbContext.CloseConnection();
            }
        }


        [HttpGet]
        public CustomerCartViewModel ViewCart(int CustomerID)
            //generations of full-stack developers have prayed for this...
            //and it worked 
        {
            CustomerCartViewModel customerCartViewModel = new CustomerCartViewModel(); 
            try
            {
                this.dbContext.OpenConnection();
                customerCartViewModel.products = this.unitOfWork.ProductRepository.ProductsFromCart(CustomerID);
                this.dbContext.ClearParameters();
                return customerCartViewModel;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
            finally
            {
                this.dbContext.CloseConnection();
            }
        }

        [HttpGet]

        public ViewCustomerDetails GetDetail(int CustomerID)
        {
            ViewCustomerDetails Details = new ViewCustomerDetails();
            try
            {
                this.dbContext.OpenConnection();
                Details.customer = this.unitOfWork.CustomerRepository.GetCustomerDetails(CustomerID);
                Details.CityName = this.unitOfWork.CityRepository.GetCityByCustomerID(CustomerID);
                return Details;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
            finally
            {
                this.dbContext.ClearParameters();
                this.dbContext.CloseConnection();
            }
        }
        [HttpGet]
        public ViewProduct GetProduct(int ProductID)
        {
            ViewProduct product = new ViewProduct();
            try
            {
                this.dbContext.OpenConnection();
                product.Product = this.unitOfWork.ProductRepository.GetByID(ProductID);
                product.StoreName = this.unitOfWork.StoreRepository.GetStoreByPID(ProductID);
                
                return product;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
            finally
            {
                this.dbContext.ClearParameters();
                this.dbContext.CloseConnection();
            }
        }
    }
}
