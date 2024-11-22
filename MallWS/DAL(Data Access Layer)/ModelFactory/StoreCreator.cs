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
                StoreType = Convert.ToString(src["StoreType"]),
                StoreIMG = Convert.ToString(src["StoreIMG"]),
                Products = null
            };
            return store;   
        }
        
    }
}
