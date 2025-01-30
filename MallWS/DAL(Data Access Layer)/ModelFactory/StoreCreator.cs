using Models;
using System.Data;

namespace MallWS
{
    public class StoreCreator : IModelCreator<Store>
    {
        public Store CreateModel(IDataReader src) //create a Store Model
        {
            Store store = new Store() //assemble the model:
            {
                StoreName = Convert.ToString(src["StoreName"]), //the Store's name
                StoreID = Convert.ToInt32(src["StoreID"]), //the Store's ID
                StoreType = Convert.ToString(src["StoreType"]), //the Store's type
                StoreIMG = "http://localhost:7274/Images/Stores" + Convert.ToString(src["StoreIMG"]), //the Store's image
            };
            return store;   //return the model
        }
        
    }
}
