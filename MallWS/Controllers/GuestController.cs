
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
        public Customer LoginCustmomer(Customer customer)
        {
            try
            {
                this.dbContext.OpenConnection();
                return MallUnitOfWork.CustomerRepository.LoginAttempt(customer);
            }
            catch (Exception)
            {
                return null;
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
                bool flag = this.MallUnitOfWork.CustomerRepository.Update(customer);
                if(flag)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                this.dbContext.CloseConnection();
            }
        }
        [HttpGet]
        public Store GetStoreCatalog(int AmountPerPage = 10, int PageNumber = 1, int BrandID = -1, string StoreTypeID = "", int SaleID = -1)
        {
            CatalogViewModel StoreViewModel = new CatalogViewModel();
            this.dbContext.OpenConnection();
            try
            {
                List<Brand> Brands = null;
                List<Sale> Sales = null;
                List<Store> Stores = null;
                if(BrandID != -1)
                {
                    Brands = this.MallUnitOfWork.BrandRepository.GetAll();
                }
                if(SaleID != -1)
                {
                    Sales = this.MallUnitOfWork.SaleRepository.GetAll();
                }
                if(StoreTypeID != "")
                {
                    Stores = this.MallUnitOfWork.StoreRepository.GetAll();
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                dbContext.CloseConnection();
            }
        }
        
    }
}
