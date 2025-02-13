using Models;
using System.Data;

namespace MallWebService
{
    public class CustomerCreator : IModelCreator<Customer>
    {
        public Customer CreateModel(IDataReader src) //create the model
        {
            Customer customer = new Customer()
            {
                CustomerFirstName = Convert.ToString(src["CustomerFirstName"]), //Customer's first name
                CustomerLastName = Convert.ToString(src["CustomerLastName"]), //Customer's Last Name
                CustomerID = Convert.ToString(src["CustomerIRLID"]), //Customer's real life ID 
                CustomerPhoneNumber = Convert.ToString(src["CustomerPhoneNumber"]), //Customer's phone number
                CustomerPassword = Convert.ToString(src["CustomerPassword"]), // Customer's password
                CustomerEmail = Convert.ToString(src["CustomerEmail"]), // Customer's Email
                CustomerCity = Convert.ToString(src["CustomerCity"]), // Customer city
                CustomerStreet = Convert.ToString(src["CustomerRegion"]), // Customer street
                CartID = null //Customer's cart 
            }; 
            return customer; //return the model 
        }
    }
}
