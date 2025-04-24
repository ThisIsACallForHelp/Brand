using System.Data;
using Models;
namespace WebService
{
    public class CartCreator : IModelCreator<Cart>
    {
        public Cart CreateModel(IDataReader src)
        {
            Cart cart = new Cart()
            {
                ID = Convert.ToInt32(src["CartID"])
            };
            return cart;
        }
    }
}
