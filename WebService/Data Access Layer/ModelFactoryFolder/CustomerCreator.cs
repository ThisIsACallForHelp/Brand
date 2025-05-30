using System.Data;
using Models;
namespace WebService
{
    public class CustomerCreator : IModelCreator<Customer>
    {
        public Customer CreateModel(IDataReader src)
        {
            return new Customer()
            {
                ID = Convert.ToInt32(src["CustomerID"]),
                CustomerFirstName = Convert.ToString(src["CustomerFirstName"]),
                CustomerLastName = Convert.ToString(src["CustomerLastName"]),
                CustomerPhoneNumber = Convert.ToString(src["CustomerPhoneNumber"]),
                CustomerEmail = Convert.ToString(src["CustomerEmail"]),
                CityID = Convert.ToInt32(src["CityID"]),
                CustomerPassword = Convert.ToString(src["CustomerPassword"]),
                CustomerIMG = "http://localhost:5134/Customers/" + Convert.ToString(src["CustomerIMG"])
            };
        }
    }
}
