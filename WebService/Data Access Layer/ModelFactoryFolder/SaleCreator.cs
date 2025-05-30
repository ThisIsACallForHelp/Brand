using Models;
using System.Data;

namespace WebService
{
    public class SaleCreator : IModelCreator<Sale>
    {
        public Sale CreateModel(IDataReader src)
        {
            return new Sale()
            {
                ID = Convert.ToInt32(src["SaleID"]),
                Percentage = Convert.ToInt32(src["Percentage"])
            };

        }
    }
}



