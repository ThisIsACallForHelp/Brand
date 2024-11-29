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
                CartID = Convert.ToString(src["CartID"]),
                TotalPrice = Convert.ToDouble(src["CartID"]),
                CustomerID = null
            };
            return cart;
        }
        
    }
}
