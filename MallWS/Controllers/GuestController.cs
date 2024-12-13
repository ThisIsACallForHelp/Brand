
using Microsoft.AspNetCore.Http;
using Models;
using Microsoft.AspNetCore.Mvc;

namespace MallWS
{
    [Route("api/[controller]/[action]")] // api , name of the controller, name of the action 
    [ApiController]
    public class GuestController : ControllerBase
    {
            DBContext dbContext;
            MallUnitOfWorkRepositery MallUnitOfWork { get; set; }
            public GuestController()
            {
                this.dbContext = DBContext.GetInstance();
                this.MallUnitOfWork = new MallUnitOfWorkRepositery(this.dbContext);
            }

            [HttpGet]
            public Customer? LoginCustomer(Customer customer)
            {
                try
                {
                    this.dbContext.OpenConnection();
                    return MallUnitOfWork.CustomerRepository.LoginAttempt(customer);
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
            [HttpPost]
            public bool AddNewCustomer(Customer customer)
            {
                try
                {
                    this.dbContext.OpenConnection();
                    return MallUnitOfWork.CustomerRepository.Create(customer);
                }
                catch (Exception ex)
                {
                    string Message = ex.Message;
                    Console.WriteLine(Message);
                    return false;
                }
                finally
                {
                    this.dbContext.CloseConnection();
                }
            }

            [HttpPost]
            public bool UpdateCustomerInfo(Customer customer)
            {
                try
                {
                    this.dbContext.OpenConnection();
                    return MallUnitOfWork.CustomerRepository.Update(customer);
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                    Console.WriteLine(message);
                    return false;
                }
                finally
                {
                    this.dbContext.CloseConnection();
                }
            }
            [HttpGet]
            public List<Store> GetStoreCatalog()
            {
                try
                {
                    this.dbContext.OpenConnection();
                    return this.MallUnitOfWork.StoreRepository.GetAll();
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
            [HttpGet]
            public List<Brand> GetBrandCatalog()
            {
                try
                {
                    this.dbContext.OpenConnection();
                    return this.MallUnitOfWork.BrandRepository.GetAll();
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
            [HttpGet]
            public List<Store> GetStoreTypeList()
            {
                try
                {
                    this.dbContext.OpenConnection();
                    return this.MallUnitOfWork.StoreRepository.GetTypeList();
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
            [HttpGet]
            public List<Store> GetStoreByType(string StoreType)
            {
                try
                {
                    this.dbContext.OpenConnection();
                    return this.MallUnitOfWork.StoreRepository.GetStoreByType(StoreType);
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
            [HttpGet]
            public List<Store> GetStoresByBrand(Brand brand)
            {
                try
                {
                    this.dbContext.OpenConnection();
                    return this.MallUnitOfWork.StoreRepository.GetStoresByBrand(brand);
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
            [HttpGet]
            public List<Product> GetProductsBySale()
            {
                try
                {
                    this.dbContext.OpenConnection();
                    return this.MallUnitOfWork.ProductRepository.GetBySales();
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
            [HttpPost]
            public bool InsertInTheCart(Product product)
            {
                try
                {
                    this.dbContext.OpenConnection();
                    return this.MallUnitOfWork.CartRepository.ProductIntoCart(product);
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                    Console.WriteLine(message);
                    return false;
                }
                finally
                {
                    this.dbContext.CloseConnection();
                }
            }
            [HttpPost]
            public bool DeleteFromTheCart(Product product)
            {
                try
                {
                    this.dbContext.OpenConnection();
                    return this.MallUnitOfWork.CartRepository.DeleteProductInCart(product);
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                    Console.WriteLine(message);
                    return false;
                }
                finally
                {
                    this.dbContext.CloseConnection();
                }
            }
            [HttpGet]
            public List<Product> GetAllFromStore(Store store)
            {
                try
                {
                    this.dbContext.OpenConnection();
                    return this.MallUnitOfWork.ProductRepository.GetProductsFromStore(store);
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

    }

}

