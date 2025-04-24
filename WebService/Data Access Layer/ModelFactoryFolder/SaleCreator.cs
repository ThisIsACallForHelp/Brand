using Models;
using System.Data;

namespace WebService
{
    public class SaleCreator : IModelCreator<Sale>
    {
        public Sale CreateModel(IDataReader src)
        {
            Sale sale = new Sale()
            {
                ID = Convert.ToInt32(src["SaleID"]),
                Percentage = Convert.ToInt32(src["Percentage"])
            };
            return sale;
        }
    }
}



