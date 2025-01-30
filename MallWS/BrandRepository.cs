using System.Data;
using Models;
namespace MallWS
{
    
    
        public class BrandRepository : Repository, IRepository<Brand>
        {
            public BrandRepository(DBContext dbContext) : base(dbContext)
            {

            }

            public bool Create(Brand model) //Create a Brand
            {
                string sql = $@"Insert into Brands (BrandName, BrandIMG) 
                            values(@BrandName,@BrandIMG)";  //create a new Brand object with these values
                this.dbContext.AddParameter("@BrandName", model.BrandName);
                this.dbContext.AddParameter("@BrandIMG", model.BrandIMG);
                return this.dbContext.Insert(sql); //execute the SQL statement 
                
            }


            public bool Delete(string ID) //delete a Brand with a given ID
            {
                string sql = "Delete from Brands where BrandID=@BrandID"; //delete a from the DB if it matches the ID
                this.dbContext.AddParameter("@BrandsID", ID);
                return this.dbContext.Delete(sql); //execute
            }

            public List<Brand> GetAll()
            {
                List<Brand> list = new List<Brand>(); //create a list
                string sql = "Select * from Brand"; //Select every object from the DB in the Brand table
                using (IDataReader brand = this.dbContext.Read(sql))
                {
                    while (brand.Read()) //while you didnt reach the end...
                    {
                        list.Add(this.modelFactory.BrandCreator.CreateModel(brand)); //add the brand into the list
                    }
                }
                return list; //return it 
            }

            public Brand GetById(string ID) //get a brand by a specific ID
            {
                string sql = "Select * from Brands Where BrandID = @BrandID"; //select the Brand object if it matches the ID
                this.dbContext.AddParameter("@BrandID", ID);
                using (IDataReader brand = this.dbContext.Read(sql))
                {
                    brand.Read(); //Read the object 
                    return this.modelFactory.BrandCreator.CreateModel(brand); //return the brand 
                }
            }
            public bool Update(Brand model) //update the brand in the DB
            {
                string sql = $@"UPDATE Brands SET BrandName = @BrandName, BrandIMG = @BrandIMG WHERE BrandID == @BrandID";
                            //update a brand 
                this.dbContext.AddParameter("@BrandName", model.BrandName);
                this.dbContext.AddParameter("@BrandIMG", model.BrandIMG);
                return this.dbContext.Update(sql); //return the answer (if the change was a succsess)
            }
        }
}
