using Models;
using System.Data;

namespace MallWS
{
    public class CustomerCreator : IModelCreator<Customer>
    {
        public Customer CreateModel(IDataReader src)
        {
            Customer customer = new Customer()
            {
                CustomerFirstName = Convert.ToString(src["CustomerFirstName"]),
                CustomerLastName = Convert.ToString(src["CustomerLastName"]),
                CustomerID = Convert.ToString(src["CustomerID"]),
                CustomerPhoneNumber = Convert.ToString(src["CustomerPhoneNumber"]),
                CustomerPassword = Convert.ToString(src["CustomerPassword"]),
                CustomerEmail = Convert.ToString(src["CustomerEmail"]),
                CustomerCity = Convert.ToString(src["CustomerCity"]),
                CustomerStreet = Convert.ToString(src["CustomerRegion"]),
                Cart = null
            }; 
            return customer;
        }
    }
}
