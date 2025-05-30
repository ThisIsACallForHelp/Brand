using System.Data;
using Models;
namespace WebService
{
    public class CityCreator : IModelCreator<City>
    {
        public City CreateModel(IDataReader src)
        {
            return new City()
            {
                ID = Convert.ToInt32(src["CityID"]),
                CityName = Convert.ToString(src["CityName"])
            };
        }
    }
}
