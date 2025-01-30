using Models;
using System.Data;
namespace MallWS
{
    public class CartCreator : IModelCreator<Cart>
    {

        public Cart CreateModel(IDataReader src) //create a Cart model 
        {
            Cart cart = new Cart() //assemble the model;
            {
                CartID = Convert.ToString(src["CartID"]), // the Cart's ID
                CustomerID = null //Customer's ID (the owner of the cart)
            };
            return cart; //return the model
        }
        
    }
}
