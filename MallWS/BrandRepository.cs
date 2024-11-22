using System.Data;
using Models;
namespace MallWS
{
    
    
        public class BrandRepository : Repository, IRepository<Brand>
        {
            public BrandRepository(DBContext dbContext) : base(dbContext)
            {

            }

            public bool Create(Brand model)
            {
                string sql = $@"Insert into Brands (BrandName, BrandIMG)
                            values(@BrandName,@BrandIMG)";  //parameters for SQL Injection, extension 1
                this.dbContext.AddParameter("@BrandName", model.BrandName);
                this.dbContext.AddParameter("@BrandIMG", model.BrandIMG);
                return this.dbContext.Insert(sql);
                
            }

            public bool Delete(string ID)
            {
                string sql = "Delete from Brands where BrandID=@BrandID";
                this.dbContext.AddParameter("@BrandsID", ID);
                return this.dbContext.Delete(sql);
            }

            public List<Brand> GetAll()
            {
                List<Brand> list = new List<Brand>();
                string sql = "Select * from Brand";
                using (IDataReader brand = this.dbContext.Read(sql))
                {
                    while (brand.Read())
                    {
                        list.Add(this.modelFactory.BrandCreator.CreateModel(brand));
                    }
                }
                return list;
            }

            public Brand GetById(string ID)
            {
                string sql = "Select * from Brands Where BrandID = @BrandID";
                this.dbContext.AddParameter("@BrandID", ID);
                using (IDataReader brand = this.dbContext.Read(sql))
                {
                    brand.Read();
                    return this.modelFactory.BrandCreator.CreateModel(brand);
                }
            }
            public bool Update(Brand model)
            {
            string sql = $@"UPDATE Brands SET BrandName = @BrandName, BrandIMG = @BrandIMG WHERE BrandID == @BrandID";
                            //parameters for SQL Injection, extension 1
                this.dbContext.AddParameter("@BrandName", model.BrandName);
                this.dbContext.AddParameter("@BrandIMG", model.BrandIMG);
                return this.dbContext.Update(sql);
            }
        }
}
