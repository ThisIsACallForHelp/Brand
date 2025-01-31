using Models;
using System.Data;
namespace MallWS
{
    public class ProductCreator : IModelCreator<Product>
    {
        public Product CreateModel(IDataReader src) //create a new product model
        {
            Product product = new Product() //assemble the model:
            { 
                ProductID = Convert.ToInt32(src["ProductID"]), //product ID
                ProductName = Convert.ToString(src["ProductFirstName"]), // Product Name 
                StoreID = 0, //The Store ID
                ProductPrice = Convert.ToDouble(src["ProductPrice"]), //Product Price 
                BrandID = 0, //The Product's brand
                ProductIMG = "http://localhost:7274/Images/Products" + Convert.ToString(src["ProductIMG"]) 
                //The product's image
            };
            return product; //return the model 
        }
    }
 
}
