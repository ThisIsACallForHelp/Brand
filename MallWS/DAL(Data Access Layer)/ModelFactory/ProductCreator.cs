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
                ProductID = Convert.ToInt32(src["ProductID"]),
                ProductName = Convert.ToString(src["ProductFirstName"]),
                Store = null,
                ProductPrice = Convert.ToDouble(src["ProductPrice"]),
                Brand = null,
                ProductIMG = Convert.ToString(src["ProductIMG"])
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
