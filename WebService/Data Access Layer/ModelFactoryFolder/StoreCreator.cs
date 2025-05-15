using Models;
using System.Data;

namespace WebService
{
    public class StoreCreator : IModelCreator<Store>
    {
        public Store CreateModel(IDataReader src)
        {
            Store store = new Store()
            {
                ID = Convert.ToInt32(src["StoreID"]),
                StoreName = Convert.ToString(src["StoreName"]),
                StoreTypeID = Convert.ToInt32(src["StoreTypeID"]),
                StoreFloor = Convert.ToInt32(src["StoreFloor"]),
                StoreDescription = Convert.ToString(src["StoreDescription"]),
            };
            return store;
        }
    }
}

