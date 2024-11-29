using Models;
using System.Data;

namespace MallWS
{
    public class ProductRepository : Repository, IRepository<Product>
    {
        public ProductRepository(DBContext dbContext) : base(dbContext)
        {

        }


        public bool Create(Product model)
        {
            string sql = $@"Insert into Products (ProductName, ProductPrice, StoreID, BrandID, ProductIMG)
                            values(@ProductName,@ProductIMG)";  //parameters for SQL Injection, extension 1
            this.dbContext.AddParameter("@ProductName", model.ProductName);
            this.dbContext.AddParameter("@ProductName", model.ProductName);
            this.dbContext.AddParameter("@StoreID", model.Store.StoreID.ToString());
            this.dbContext.AddParameter("@BrandID", model.Brand.BrandID.ToString());
            this.dbContext.AddParameter("@ProductIMG", model.ProductIMG);

            return this.dbContext.Insert(sql);

        }

        public bool Delete(string ID)
        {
            string sql = "Delete from Products where ProductID=@ProductID";
            this.dbContext.AddParameter("@ProductsID", ID);
            return this.dbContext.Delete(sql);
        }

        public List<Product> GetAll()
        {
            List<Product> list = new List<Product>();
            string sql = "Select * from Product";
            using (IDataReader Product = this.dbContext.Read(sql))
            {
                while (Product.Read())
                {
                    list.Add(this.modelFactory.ProductCreator.CreateModel(Product));
                }
            }
            return list;
        }

        public Product GetById(string ID)
        {
            string sql = "Select * from Products Where ProductID = @ProductID";
            this.dbContext.AddParameter("@ProductID", ID);
            using (IDataReader Product = this.dbContext.Read(sql))
            {
                Product.Read();
                return this.modelFactory.ProductCreator.CreateModel(Product);
            }
        }

        public bool Update(Product model)
        {
            string sql = $@"UPDATE Products SET ProductName = @ProductName, ProductPrice = @ProductPrice, StoreID = @StoreID, BrandID = @BrandID, ProductIMG = @ProductIMG WHERE ProductID == @ProductID)";
                              //parameters for SQL Injection, extension 1
            this.dbContext.AddParameter("@ProductName", model.ProductName);
            this.dbContext.AddParameter("@ProductName", model.ProductName);
            this.dbContext.AddParameter("@StoreID", model.Store.StoreID.ToString());
            this.dbContext.AddParameter("@BrandID", model.Brand.BrandID.ToString());
            this.dbContext.AddParameter("@ProductIMG", model.ProductIMG);
            return this.dbContext.Update(sql);
        }
    }
}
