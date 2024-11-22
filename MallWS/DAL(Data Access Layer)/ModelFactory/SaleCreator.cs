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
                Percentage = Convert.ToInt32(src["Percentage"]),
                Product = null,
                Brand = null
            };
            return sale;
        }
    }
    
}
