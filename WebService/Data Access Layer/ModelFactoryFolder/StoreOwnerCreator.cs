using Models;
using System.Data;
namespace WebService
{
    public class StoreOwnerCreator : IModelCreator<StoreOwner>
    {
        public StoreOwner CreateModel(IDataReader src)
        {
            return new StoreOwner()
            {
                ID = Convert.ToInt32(src["StoreOwnerID"]),
                StoreOwnerName = Convert.ToString(src["StoreOwnerName"]),
                StoreOwnerLastName = Convert.ToString(src["StoreOwnerLastName"]),
                StoreOwnerPhoneNumber = Convert.ToString(src["StoreOwnerPhoneNumber"]),
                StoreOwnerEmail = Convert.ToString(src["StoreOwnerEmail"]),
                StoreID = Convert.ToInt32(src["StoreID"]),
                StoreOwnerIMG = "http://localhost:5134/StoreOwners/" + Convert.ToString(src["StoreOwnerIMG"])
            };

        }
    }
}
