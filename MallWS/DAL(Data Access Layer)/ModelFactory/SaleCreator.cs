using System.Data;
using Models;

namespace MallWS
{
    public class SaleCreator : IModelCreator<Sale>
    {
        public Sale CreateModel(IDataReader src)
        {
            Sale sale = new Sale()
            {
                ProductID = 0,
                Percentage = Convert.ToInt32(src["Percentage"]),
                SaleID = Convert.ToInt32(src["SaleID"])
            };
            return sale;
        }
    }
    
}
