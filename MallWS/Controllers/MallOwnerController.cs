using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Reflection.Metadata.Ecma335;

namespace MallWS.Controllers
{
    [Route("api/[controller]/[action]")] // api , name of the controller, name of the action 
    [ApiController]
    public class MallOwnerController : ControllerBase
    {
        DBContext dbContext;
        MallUnitOfWorkRepositery MallUnitOfWork { get; set; }
        public MallOwnerController() //constructor 
        {
            this.dbContext = DBContext.GetInstance(); //get a DBContext instance 
            this.MallUnitOfWork = new MallUnitOfWorkRepositery(this.dbContext); //mall unit of work 
        }
        //we are deleting a store, so we are changing data in the "Stores" table. HTTP POST
        [HttpPost]
        public bool RemoveStore(Store store) //get the store
        {
            try
            {
                this.dbContext.OpenConnection(); //open this connection
                return this.MallUnitOfWork.StoreRepository.Delete(store.ID); //delete it using the ID 
            }
            catch (Exception) //if there was an error 
            {
                return false; //return false;
            }
            finally
            {
                this.dbContext.CloseConnection(); //close the connection 
            }
        }
        //we are inserting a new store into the mall, HTTP POST 
        [HttpPost]
        public bool InsertStore(Store store) //get the store
        {
            try
            {
                this.dbContext.OpenConnection(); //open connection
                return this.MallUnitOfWork.StoreRepository.Create(store); //create the store 
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
        //we are updating the store, so we are changing data again. HTTP POST 
        [HttpPost]
        public bool UpdateStore(Store store) //get the store 
        {
            try
            {
                this.dbContext.OpenConnection(); //open the connection 
                return this.MallUnitOfWork.StoreRepository.Update(store); //update the store 
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
    }
}