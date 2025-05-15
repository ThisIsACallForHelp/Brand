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
                BrandName = Convert.ToString(src["BrandName"])
            };
            return brand;
        }
    }
}
