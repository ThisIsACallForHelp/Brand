using System.Data;
using Models;
namespace WebService
{
    public class StoreTypeCreator : IModelCreator<StoreType>
    {
        public StoreType CreateModel(IDataReader src)
        {
            StoreType storeType = new StoreType()
            {
                ID = Convert.ToInt32(src["StoreTypeID"]),
                StoreTypeName = Convert.ToString(src["StoreTypeName"])
            }; 
            return storeType;
        }
    }
}


