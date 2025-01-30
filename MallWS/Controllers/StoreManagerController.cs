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
        public StoreManagerController() //constructor 
        {
            this.dbContext = DBContext.GetInstance(); //DBContext instance to access the DB 
            this.MallUnitOfWork = new MallUnitOfWorkRepositery(this.dbContext); 
            //mall unit of work to access the repositories 
        }
        //we are inserting a new product, so HTTP POST
        [HttpPost]

        public bool InsertNewProduct(Product product) //get the product
        {
            try
            {
                this.dbContext.OpenConnection(); //open connection
                return this.MallUnitOfWork.ProductRepository.Create(product); //create it 
            }
            catch (Exception) //if there was an error 
            {
                return false; //return false
            }
            finally
            {
                this.dbContext.CloseConnection(); //close the connection
            }
        }
        //we are deleting a product, so HTTP POST
        [HttpPost]
        public bool DeleteProduct(Product product) //get the product 
        {
            try
            {
                this.dbContext.OpenConnection(); //open the connection 
                return this.MallUnitOfWork.ProductRepository.Delete(product.ID); 
                //delete the product by using it's ID 
            }
            catch (Exception) //catch the exception 
            {
                return false; //return false
            }
            finally
            {
                this.dbContext.CloseConnection(); //close connection 
            }
        }
        //we are deleting a brand, so HTTP POST 
        [HttpPost]
        public bool DeleteBrand(Brand brand) //get the brand 
        {
            try
            {
                this.dbContext.OpenConnection(); //open connection
                return this.MallUnitOfWork.BrandRepository.Delete(brand.ID); //delete it by using the ID 
            }
            catch (Exception) //catch the error 
            {
                return false; //return false;
            }
            finally
            {
                this.dbContext.CloseConnection(); //close connection
            }
        }
        //we are inserting a new brand, so HTTP POST 
        [HttpPost]
        public bool InsertBrand(Brand brand) //get the brand
        {
            try
            {
                this.dbContext.OpenConnection(); //open connection
                return this.MallUnitOfWork.BrandRepository.Create(brand); //create the brand 
            }
            catch (Exception) //catch the exception 
            {
                return false; //return false
            }
            finally
            {
                this.dbContext.CloseConnection(); //close connection
            }
        }
        //we are inserting a sale, so HTTP POST
        [HttpPost]
        public bool InsertSale(Sale sale) //get the sale info
        {
            try
            {
                this.dbContext.OpenConnection(); //open connection
                return this.MallUnitOfWork.SaleRepository.Create(sale); //create it
            }
            catch (Exception) //catch the error
            {
                return false; //return false
            }
            finally
            {
                this.dbContext.CloseConnection(); //close connection
            }
        }
        //we are deleting the sale, so HTTP POST 
        [HttpPost]
        public bool DeleteSale(Sale sale) //get the sale 
        {
            try
            {
                this.dbContext.OpenConnection(); //open connection
                return this.MallUnitOfWork.SaleRepository.Delete(sale.ID); 
                //create the sale by using it's ID
            }
            catch (Exception) //catch the error
            {
                return false; //return false
            }
            finally
            {
                this.dbContext.CloseConnection(); //close connection 
            }
        }
    }
}