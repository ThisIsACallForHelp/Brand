using System.Data;
using Models;
namespace WebService
{
    public class ProductCreator : IModelCreator<Product>
    {
        public Product CreateModel(IDataReader src)
        {
            return new Product()
            {
                ID = Convert.ToInt32(src["ProductID"]),
                ProductName = Convert.ToString(src["ProductName"]),
                ProductPrice = Convert.ToInt32(src["ProductPrice"]),
                StoreID = Convert.ToInt32(src["StoreID"]),
                ProductBrand = Convert.ToInt32(src["BrandID"]),
                ProductIMG = "http://localhost:5134/Products/" + Convert.ToString(src["ProductIMG"]),
                SaleID = Convert.ToInt32(src["SaleID"])
            };
        }
    }
}
