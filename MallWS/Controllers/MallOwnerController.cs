using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace MallWS.Controllers
{
    [Route("api/[controller]/[action]")] // api , name of the controller, name of the action 
    [ApiController]
    public class MallOwnerController : ControllerBase
    {
        DBContext dbContext;
        MallUnitOfWorkRepositery MallUnitOfWork { get; set; }
        public MallOwnerController()
        {
            this.dbContext = DBContext.GetInstance();
            this.MallUnitOfWork = new MallUnitOfWorkRepositery(this.dbContext);
        }
        [HttpPost]
        public bool RemoveStore(Store store)
        {
            try
            {
                this.dbContext.OpenConnection();
                return this.MallUnitOfWork.StoreRepository.Delete(store.ID);
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
        public bool InsertStore(Store store)
        {
            try
            {
                this.dbContext.OpenConnection();
                return this.MallUnitOfWork.StoreRepository.Create(store);
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
        public bool UpdateStore(Store store)
        {
            try
            {
                this.dbContext.OpenConnection();
                return this.MallUnitOfWork.StoreRepository.Update(store);
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