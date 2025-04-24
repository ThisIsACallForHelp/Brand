using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebService
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MallOwnerController : ControllerBase
    {
        DBContext dbContext;
        UnitOfWork unitOfWork;

        public MallOwnerController()
        {
            this.dbContext = DBContext.GetInstance();
            this.unitOfWork = new UnitOfWork(this.dbContext);
        }


        

        [HttpPost]
        public bool CreateStore(Store store)
            //it should work
        {
            try
            {
                this.dbContext.OpenConnection();
                return this.unitOfWork.StoreRepository.Create(store);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                this.dbContext.CloseConnection();
            }
        }
        [HttpPost]
        public bool DeleteStore(int StoreID)
            //works
        {
            try
            {
                this.dbContext.OpenConnection();
                return this.unitOfWork.StoreRepository.DeleteByID(StoreID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                this.dbContext.CloseConnection();
            }
        }

        
        [HttpPost]
        public bool UpdateStore(Store store)
            //works
        {
            try
            {
                this.dbContext.OpenConnection();
                return this.unitOfWork.StoreRepository.Update(store);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                this.dbContext.CloseConnection();
            }
        }
        [HttpGet]
        public Store GetStoreByID(int ID) //works
        {
            try
            {
                this.dbContext.OpenConnection();
                return this.unitOfWork.StoreRepository.GetByID(ID);
            }
            catch (Exception ex)
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
        public MallOwnerViewModel GetMasterList(int choice)
        {
            MallOwnerViewModel mallOwnerViewModel = new MallOwnerViewModel();
            try
            {
                this.dbContext.OpenConnection();
                switch (choice) 
                {
                    case 1:
                        mallOwnerViewModel.Customer = this.unitOfWork.CustomerRepository.GetAll();
                        mallOwnerViewModel.Store = null;
                        mallOwnerViewModel.Brand = null;
                        mallOwnerViewModel.storeOwners = null;  
                        break;
                    case 2:
                        mallOwnerViewModel.Customer = null;
                        mallOwnerViewModel.Store = this.unitOfWork.StoreRepository.GetAll();
                        mallOwnerViewModel.Brand = null;
                        mallOwnerViewModel.storeOwners = null;
                        break;
                    case 3:
                        mallOwnerViewModel.Customer = null;
                        mallOwnerViewModel.Store = null;
                        mallOwnerViewModel.Brand = this.unitOfWork.BrandRepository.GetAll();
                        mallOwnerViewModel.storeOwners = null;
                        break;
                    case 4:
                        mallOwnerViewModel.Customer = null;
                        mallOwnerViewModel.Store = null;
                        mallOwnerViewModel.Brand = null;
                        mallOwnerViewModel.storeOwners = this.unitOfWork.StoreOwnerRepository.GetAll();
                        break;
                    default:
                        break;

                }

                return mallOwnerViewModel;
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



        [HttpPost]
        public bool DeleteUser(int ID)
        {
            try
            {
                this.dbContext.OpenConnection();
                return this.unitOfWork.CustomerRepository.DeleteByID(ID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                this.dbContext.CloseConnection();
            }
        }

        [HttpGet]
        public List<Product> GetProductsFromStore(int StoreID)
        //works
        {
            try
            {
                this.dbContext.OpenConnection();
                return this.unitOfWork.ProductRepository.ProductsFromStore(StoreID);
            }
            catch (Exception ex)
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
        public Product GetProductByID(int ID)
        {
            try
            {
                this.dbContext.OpenConnection();
                return this.unitOfWork.ProductRepository.GetByID(ID);
            }
            catch (Exception ex)
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
        public Customer GetCustomerByID(int ID)
        {
            try
            {
                this.dbContext.OpenConnection();
                return this.unitOfWork.CustomerRepository.GetByID(ID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
            finally
            {
                this.dbContext.CloseConnection();
            }
        }
    }
}
