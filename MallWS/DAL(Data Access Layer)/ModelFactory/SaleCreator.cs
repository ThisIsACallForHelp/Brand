using System.Data;
using Models;

namespace MallWebService
{
    public class SaleCreator : IModelCreator<Sale>
    {
        public Sale CreateModel(IDataReader src) //create a new model
        {
            Sale sale = new Sale() //assemble the model
            {
                ProductID = 0, //Product ID
                Percentage = Convert.ToInt32(src["Percentage"]), //Sale percentage
                SaleID = Convert.ToInt32(src["SaleID"]) //Sale ID
            };
            return sale; //return the model
        }
    }
    
}
