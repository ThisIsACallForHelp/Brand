using System.Data;
using Models;
namespace MallWebService
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
                AddParameters("@BrandName", model.BrandName);
                AddParameters("@BrandIMG", model.BrandIMG);
                return this.dbContext.Create(sql) > 0; //execute the SQL statement 
                
            }


            public bool Delete(string ID) //delete a Brand with a given ID
            {
                string sql = "Delete from Brands where BrandID=@BrandID"; //delete a from the DB if it matches the ID
                AddParameters("@BrandsID", ID);
                return this.dbContext.Delete(sql) > 0; //execute
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
                AddParameters("@BrandID", ID);
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
                AddParameters("@BrandName", model.BrandName);
                AddParameters("@BrandIMG", model.BrandIMG);
                return this.dbContext.Update(sql) > 0; //return the answer (if the change was a succsess)
            }
        }
}
