using Models;
using Microsoft.AspNetCore.Http;
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
        public CatalogViewModel GetCatalogViewModel(int BrandID = -1, int SaleID= -1, int StoreTypeID = -1)
        {
           CatalogViewModel catalogViewModel= new CatalogViewModel();
            try
            {
                this.dbContext.OpenConnection();
                catalogViewModel.Stores = MallUnitOfWork.StoreRepository.GetAll();
                catalogViewModel.BrandID = -1;
                catalogViewModel.SaleID = -1;
                StoreTypeID = -1;
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
            return catalogViewModel;
        }
    }
}
