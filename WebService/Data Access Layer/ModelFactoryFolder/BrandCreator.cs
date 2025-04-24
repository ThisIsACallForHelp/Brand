using System.Data;
using Models;
namespace WebService
{
    public class BrandCreator : IModelCreator<Brand>
    {
        public Brand CreateModel(IDataReader src)
        {
            Brand brand = new Brand()
            {
                ID = Convert.ToInt32(src["BrandID"]),
                BrandName = Convert.ToString(src["BrandName"]),
                BrandIMG = "http:/localhost:5134/Brands/" + Convert.ToString(src["BrandIMG"])
            };
            return brand;
        }
    }
}
