using Models;
using System.Data;
namespace MallWS
{
    public class CartCreator : IModelCreator<Cart>
    {

        public Cart CreateModel(IDataReader src)
        {
            Cart cart = new Cart()
            {
                CustomerID = null,
            };
            return cart;
        }
        
    }
}
