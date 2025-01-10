using Models;
using System.Data;

namespace MallWS
{
    public class BrandCreator : IModelCreator<Brand>
    {
        
        public Brand CreateModel(IDataReader src) 
        {
            Brand brand = new Brand()
            {
                BrandName = Convert.ToString(src["BrandName"]),
                BrandID = Convert.ToInt32(src["BrandID"]),
                BrandIMG = "http://localhost:7274/Images/Brands" + Convert.ToString(src["BrandIMG"])

            };
            return brand;
        }
    }
}
