using Models;
using System.Data;

namespace MallWS
{
    public class StoreCreator : IModelCreator<Store>
    {
        public Store CreateModel(IDataReader src)
        {
            Store store = new Store()
            {
                StoreName = Convert.ToString(src["StoreName"]),
                StoreID = Convert.ToInt32(src["StoreID"]),
                StoreType = Convert.ToString(src["StoreType"]),
                StoreIMG = "http://localhost:7274/Images/Stores" + Convert.ToString(src["StoreIMG"]),
            };
            return store;   
        }
        
    }
}
