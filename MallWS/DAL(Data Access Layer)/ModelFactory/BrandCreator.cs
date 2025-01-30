using Models;
using System.Data;

namespace MallWS
{
    public class BrandCreator : IModelCreator<Brand>
    {
        
        public Brand CreateModel(IDataReader src) //create a Brand model:
        {
            Brand brand = new Brand() //assemble it:
            {
                BrandName = Convert.ToString(src["BrandName"]), //the Brand's name
                BrandID = Convert.ToInt32(src["BrandID"]), //The Brand's ID
                BrandIMG = "http://localhost:7274/Images/Brands" + Convert.ToString(src["BrandIMG"]) //the Brand's image

            };
            return brand; //return the model 
        }
    }
}
