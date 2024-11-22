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
                BrandIMG = Convert.ToString(src["BrandIMG"]),
                Products = null,
                Sales = null
            };
            return brand;
        }
    }
}
