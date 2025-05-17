using Models;
using System.Data;

namespace WebService
{
    public class SaleRepository : Repository, IRepository<Sale>
    {
        public SaleRepository(DBContext dbContext) : base(dbContext)
        {

        }
        public bool Create(Sale sale)
        {
            string sql = $@"INSERT INTO Sale(SaleID, Percentage)
                            VALUES(@SaleID,@Percentage)";
            base.dbContext.AddParameters("@SaleID", sale.ID.ToString());
            base.dbContext.AddParameters("@Percentage", sale.Percentage.ToString());
            return this.dbContext.Create(sql) > 0;
        }
        public Sale GetByID(int ID)
        {
            string sql = $@"SELECT FROM Sale WHERE SaleID = @saleID";
            base.dbContext.AddParameters("@SaleID", ID.ToString());
            using (IDataReader sale = base.dbContext.Read(sql))
            {
                sale.Read(); //Read the object 
                return this.modelFactory.SaleCreator.CreateModel(sale); //return the brand 
            }
        }
        public List<Sale> GetAll()
        {
            List<Sale> sales = new List<Sale>();
            string sql = $@"SELECT * FROM Sale";
            using (IDataReader sale = base.dbContext.Read(sql))
            {
                while (sale.Read()) //until you have not reached the end...
                {
                    sales.Add(this.modelFactory.SaleCreator.CreateModel(sale)); //add the brand into the list
                }
            }
            return sales; //return it 
        }

        public bool Update(Sale sale)
        {
            string sql = $@"UPDATE Sale SET Percentage = @Percentage
                                        WHERE SaleID = @SaleID";
            base.dbContext.AddParameters("@Percentage", sale.Percentage.ToString());
            base.dbContext.AddParameters("@SaleID", sale.ID.ToString());
            return this.dbContext.Update(sql) > 0;
        }

        public bool DeleteByID(int ID)
        {
            string sql = $@"DELETE FROM Sale WHERE SaleID = @saleID";
            base.dbContext.AddParameters("@SaleID", ID.ToString());
            return dbContext.Delete(sql) > 0;
        }
        public bool Delete(Sale sale)
        {
            string sql = $@"DELETE FROM Sale WHERE SaleID = @SaleID";
            base.dbContext.AddParameters("@SaleID", sale.ID.ToString());
            return dbContext.Delete(sql) > 0;
        }
    }
}
