using Models;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;

namespace WebService
{
    public class BrandRepository : Repository, IRepository<Brand>
    {
        public BrandRepository(DBContext dbContext) : base(dbContext) 
        {

        }
        public bool Create(Brand brand)
        {
            string sql = $@"INSERT INTO Brand(BrandID, BrandName)
                            VALUES(@BrandID, @BrandName)";
            base.dbContext.AddParameters("@BrandID", brand.ID.ToString());
            base.dbContext.AddParameters("@BrandName", brand.BrandName);
            return this.dbContext.Create(sql) > 0;
        }
        public Brand GetByID(int ID)
        {
            string sql = $@"SELECT * FROM Brand WHERE BrandID = @brandID";
            base.dbContext.AddParameters("@BrandID", ID.ToString());
            using (IDataReader brand = base.dbContext.Read(sql))
            {
                brand.Read(); //Read the object 
                return this.modelFactory.BrandCreator.CreateModel(brand); //return the brand 
            }
        }
        public List<Brand> GetAll()
        {
            List<Brand> brands = new List<Brand>();
            string sql = $@"SELECT * FROM Brand";
            using (IDataReader brand = base.dbContext.Read(sql))
            {
                while (brand.Read()) //until you have not reached the end...
                {
                    brands.Add(this.modelFactory.BrandCreator.CreateModel(brand)); //add the brand into the list
                }
            }
            return brands; //return it 
        }

        public bool Update(Brand brand)
        {
            string sql = $@"UPDATE Brand SET BrandName = '@BrandName'
                                         WHERE  BrandID = @BrandID";
            base.dbContext.AddParameters("@BrandID", brand.ID.ToString());
            base.dbContext.AddParameters("@BrandName", brand.BrandName);
            return this.dbContext.Update(sql) > 0;
        }

        public bool DeleteByID(int ID)
        {
            string sql = $@"DELETE FROM Brand WHERE BrandID = @brandID";
            base.dbContext.AddParameters("@BrandID", ID.ToString());
            return dbContext.Delete(sql) > 0;
        }

        public bool Delete(Brand brand)
        {
            string sql = $@"DELETE FROM Brand WHERE BrandID = @BrandID";
            base.dbContext.AddParameters("@BrandID", brand.ID.ToString());
            return dbContext.Delete(sql) > 0;
        }
    }
}
