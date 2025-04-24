using System.Data;
using Models;
namespace WebService
{
    public class CartProductCreator : IModelCreator<CartProduct>
    {
        public CartProduct CreateModel(IDataReader src)
        {
            CartProduct cartProduct = new CartProduct()
            {
                ID = Convert.ToInt32(src["CartProductID"]),
                ProductID = Convert.ToInt32(src["ProductID"]),
                Quantity = Convert.ToInt32(src["Quantity"]),
                CustomerID = Convert.ToInt32(src["CustomerID"])
            };
            return cartProduct;
        }
    }
}