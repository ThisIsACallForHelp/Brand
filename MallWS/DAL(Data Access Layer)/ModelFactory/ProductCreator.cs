using Models;
using System.Data;
namespace MallWS
{
    public class ProductCreator : IModelCreator<Product>
    {
        public Product CreateModel(IDataReader src)
        {
            Product product = new Product() 
            { 
                ProductName = Convert.ToString(src["ProductName"]),
                ProductDescription = Convert.ToString(src["ProductDescription"]),
                ProductPrice = Convert.ToDouble(src["ProductPrice"]),
                ProductIMG = Convert.ToString(src["ProductIMG"]),
                Store = null,
                Sale = null,
                Brand = null,
                Cart = null
            };
            return product;
        }
    }
    //public Brand CreateModel(IDataReader src)
    //{
    //    Brand brand = new Brand()
    //    {
    //        BrandName = Convert.ToString(src["BrandName"]),
    //        BrandID = Convert.ToInt32(src["BrandID"]),
    //        BrandIMG = Convert.ToString(src["BrandIMG"]),
    //        Products = null,
    //        Sales = null
    //    };
    //    return brand;
    //}
}
