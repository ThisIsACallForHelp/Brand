using Models;
using System.Data;

namespace MallWebService
{
    public class SaleRepository : Repository, IRepository<Sale>
    {
        public SaleRepository(DBContext dbContext) : base(dbContext)
        {

        }

        public bool Create(Sale model) //create a sale 
        {
            string sql = $@"Insert into Sales (Percentage, ProductID)
                            values(@Percentage,@ProductID)"; 
            //insert a new sale into the DB 
            AddParameters("@Percentage", model.Percentage.ToString());
            AddParameters("@Percentage", model.Product.ProductID.ToString());
            return this.dbContext.Create(sql) > 0; //execute SQL 


        }

        public bool Delete(string ID)
        {
            string sql = "Delete from Sales where SaleID=@SaleID";
            //delete a sale if it matches the given ID
            AddParameters("@SalesID", ID);
            return this.dbContext.Delete(sql) > 0; //execute
        }

        public List<Sale> GetAll() //get all sales
        {
            List<Sale> list = new List<Sale>(); //make a new list
            string sql = "Select * from Sales"; //select everything from the sale table
            using (IDataReader Sale = this.dbContext.Read(sql)) //read 
            {
                while (Sale.Read()) //until you have reached the end...
                {
                    list.Add(this.modelFactory.SaleCreator.CreateModel(Sale)); //add the sale to the list
                }
            }
            return list; //return 
        }

        public Sale GetById(string ID) //get a sale by ID 
        {
            string sql = "Select * from Sales Where SaleID = @SaleID";
            //select a sale with a matching ID
            AddParameters("@SaleID", ID);
            using (IDataReader Sale = this.dbContext.Read(sql))
            {
                Sale.Read(); //read it
                return this.modelFactory.SaleCreator.CreateModel(Sale); //return it
            }
        }

        public bool Update(Sale model) //update a sale 
        {
            string sql = $@"Insert into Sales Percentage = @Percentage, ProductID = @ProductID WHERE SaleID = @SaleID";
            //update a sale if the ID matches
            AddParameters("@Percentage", model.Percentage.ToString());
            AddParameters("@ProductID", model.Product.ProductID.ToString());
            return this.dbContext.Update(sql) > 0;
            //execute the update
        }
    }
}
