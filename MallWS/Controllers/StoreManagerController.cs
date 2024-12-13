using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
namespace MallWS.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StoreManagerController : ControllerBase
    {
        DBContext dbContext;
        MallUnitOfWorkRepositery MallUnitOfWork { get; set; }
        public StoreManagerController()
        {
            this.dbContext = DBContext.GetInstance();
            this.MallUnitOfWork = new MallUnitOfWorkRepositery(this.dbContext);
        }
        [HttpPost]

        public bool InsertNewProduct(Product product)
        {
            try
            {
                this.dbContext.OpenConnection();
                return this.MallUnitOfWork.ProductRepository.Create(product);
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
        [HttpPost]
        public bool DeleteProduct(Product product)
        {
            try
            {
                this.dbContext.OpenConnection();
                return this.MallUnitOfWork.ProductRepository.Delete(product.ID);
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
        [HttpPost]
        public bool DeleteBrand(Brand brand)
        {
            try
            {
                this.dbContext.OpenConnection();
                return this.MallUnitOfWork.BrandRepository.Delete(brand.ID);
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
        [HttpPost]
        public bool InsertBrand(Brand brand)
        {
            try
            {
                this.dbContext.OpenConnection();
                return this.MallUnitOfWork.BrandRepository.Create(brand);
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
        [HttpPost]
        public bool InsertSale(Sale sale)
        {
            try
            {
                this.dbContext.OpenConnection();
                return this.MallUnitOfWork.SaleRepository.Create(sale);
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
        [HttpPost]
        public bool DeleteSale(Sale sale)
        {
            try
            {
                this.dbContext.OpenConnection();
                return this.MallUnitOfWork.SaleRepository.Delete(sale.ID);
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
    }
}