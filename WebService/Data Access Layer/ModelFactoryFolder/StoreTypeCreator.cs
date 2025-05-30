using System.Data;
using Models;
namespace WebService
{
    public class StoreTypeCreator : IModelCreator<StoreType>
    {
        public StoreType CreateModel(IDataReader src)
        {
            return new StoreType()
            {
                ID = Convert.ToInt32(src["StoreTypeID"]),
                StoreTypeName = Convert.ToString(src["StoreTypeName"])
            }; 

        }
    }
}


