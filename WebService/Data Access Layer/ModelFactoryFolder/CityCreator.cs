using System.Data;
using Models;
namespace WebService
{
    public class CityCreator : IModelCreator<City>
    {
        public City CreateModel(IDataReader src)
        {
            City city = new City()
            {
                ID = Convert.ToInt32(src["CityID"]),
                CityName = Convert.ToString(src["CityName"]),
                //CustomersFromCity = null
            };
            return city;
        }
    }
}
