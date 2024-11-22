using Models;
using System.Data;

namespace MallWS
{
    public class SaleRepository : Repository, IRepository<Sale>
    {
        public SaleRepository(DBContext dbContext) : base(dbContext)
        {

        }

        public bool Create(Sale model)
        {
            string sql = $@"Insert into Sales (Percentage, ProductID)
                            values(@Percentage,@ProductID)";  //parameters for SQL Injection, extension 1
            this.dbContext.AddParameter("@Percentage", model.Percentage.ToString());
            this.dbContext.AddParameter("@Percentage", model.Product.ProductID.ToString());
            return this.dbContext.Insert(sql);

        }

        public bool Delete(string ID)
        {
            string sql = "Delete from Sales where SaleID=@SaleID";
            this.dbContext.AddParameter("@SalesID", ID);
            return this.dbContext.Delete(sql);
        }

        public List<Sale> GetAll()
        {
            List<Sale> list = new List<Sale>();
            string sql = "Select * from Sales";
            using (IDataReader Sale = this.dbContext.Read(sql))
            {
                while (Sale.Read())
                {
                    list.Add(this.modelFactory.SaleCreator.CreateModel(Sale));
                }
            }
            return list;
        }

        public Sale GetById(string ID)
        {
            string sql = "Select * from Sales Where SaleID = @SaleID";
            this.dbContext.AddParameter("@SaleID", ID);
            using (IDataReader Sale = this.dbContext.Read(sql))
            {
                Sale.Read();
                return this.modelFactory.SaleCreator.CreateModel(Sale);
            }
        }

        public bool Update(Sale model)
        {
            string sql = $@"Insert into Sales Percentage = @Percentage, ProductID = @ProductID WHERE SaleID = @SaleID";
                           
            //parameters for SQL Injection, extension 1
            this.dbContext.AddParameter("@Percentage", model.Percentage.ToString());
            this.dbContext.AddParameter("@ProductID", model.Product.ProductID.ToString());
            return this.dbContext.Update(sql);
        }
    }
}
