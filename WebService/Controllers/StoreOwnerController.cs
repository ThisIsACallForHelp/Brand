using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
namespace WebService
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StoreOwnerController : ControllerBase
    {
        DBContext dbContext;
        UnitOfWork unitOfWork;

        public StoreOwnerController()
        {
            this.dbContext = DBContext.GetInstance();
            this.unitOfWork = new UnitOfWork(this.dbContext);
        }
        [HttpGet]

        public int OwnerSignIn(string StoreOwnerName, string StoreOwnerLastName, int StoreOwnerID)
        {
            try
            {
                this.dbContext.OpenConnection();
                return this.unitOfWork.StoreOwnerRepository.SignInReturnID(StoreOwnerName, StoreOwnerLastName, StoreOwnerID);
            }
            catch (Exception ex)
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
        public bool AddNewProductToStore(Product product)
        {
            try
            {
                Console.WriteLine("WebService Got -> " + product.ProductIMG);
                Console.WriteLine("Var Type -> " + product.ProductIMG.GetType());
                this.dbContext.OpenConnection();
                return this.unitOfWork.ProductRepository.Create(product);
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

        //you take the product and change it's SaleID 
        //i need to see if it works 
        public bool AddNewSale(Product product)
        {
            try
            {
                this.dbContext.OpenConnection();
                return this.unitOfWork.ProductRepository.ChangeSaleID(product.ID, product.SaleID);
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
        public bool DeleteProduct(Product product)
        {
            try
            {
                this.dbContext.OpenConnection();
                Console.WriteLine(product.ID);
                return this.unitOfWork.ProductRepository.DeleteByID(product.ID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                this.dbContext.ClearParameters();
                this.dbContext.CloseConnection();
            }
        }

        [HttpPost]
        public bool DeleteSale(Product product)
        {
            try
            {
                this.dbContext.OpenConnection();
                return this.unitOfWork.ProductRepository.DeleteSale(product.ID);
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
        public bool UpdateOwner(StoreOwner Owner)
        {
            try
            {
                this.dbContext.OpenConnection();
                return this.unitOfWork.StoreOwnerRepository.Update(Owner);
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
        public StoreOwnerViewModel StoreOwnerView(int StoreOwnerID, bool OnSale = false)
        {
            StoreOwnerViewModel storeOwnerViewModel = new StoreOwnerViewModel();            
            try
            {
                this.dbContext.OpenConnection();
                storeOwnerViewModel.Products = this.unitOfWork.ProductRepository.GetByOwnerID(StoreOwnerID);
                if (OnSale)
                {
                    storeOwnerViewModel.Products = this.unitOfWork.ProductRepository.OwnerSales(StoreOwnerID);
                }
                return storeOwnerViewModel;                
            }
            catch(Exception ex) 
            {
                Console.WriteLine($"Error: {ex.Message}");
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
