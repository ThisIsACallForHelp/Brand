using Models;
using System.Data;
using System.Numerics;

namespace WebService
{
    public class StoreOwnerRepository : Repository, IRepository<StoreOwner>
    {
        public StoreOwnerRepository(DBContext dbContext) : base(dbContext)
        {

        }

        public bool Create(StoreOwner storeOwner)
        {
            string sql = $@"INSERT INTO StoreOwner(StoreOwnerName, StoreOwnerLastName, StoreOwnerPhoneNumber, StoreOwnerEmail, StoreID, StoreOwnerIMG)
					VALUES(@StoreOwnerName, @StoreOwnerLastName, @StoreOwnerPhoneNumber, @StoreOwnerEmail, @StoreID, @StoreOwnerIMG)";
            base.dbContext.AddParameters("@StoreOwnerName", storeOwner.StoreOwnerName);
            base.dbContext.AddParameters("@StoreOwnerLastName", storeOwner.StoreOwnerLastName);
            base.dbContext.AddParameters("@StoreOwnerPhoneNumber", storeOwner.StoreOwnerPhoneNumber);
            base.dbContext.AddParameters("@StoreOwnerEmail", storeOwner.StoreOwnerEmail);
            base.dbContext.AddParameters("@StoreID", storeOwner.StoreID.ToString());
            base.dbContext.AddParameters("@StoreOwnerIMG", storeOwner.StoreOwnerIMG);
            return base.dbContext.Create(sql) > 0;
        }

        public bool DeleteByID(int ID)
        {
            string sql = $@"DELETE FROM StoreOwner WHERE StoreOwnerID = @storeOwnerID";
            base.dbContext.AddParameters("@StoreOwnerID", ID.ToString());
            return base.dbContext.Delete(sql) > 0;
        }

        public bool Delete(StoreOwner storeOwner)
        {
            string sql = $@"DELETE FROM StoreOwner WHERE StoreOwnerID = @storeOwnerID";
            base.dbContext.AddParameters("@StoreOwnerID", storeOwner.ID.ToString());
            return base.dbContext.Delete(sql) > 0;
        }
        public List<StoreOwner> GetAll()
        {
            List<StoreOwner> ProductsInCart = new List<StoreOwner>();
            string sql = $@"SELECT * FROM StoreOwner";
            using (IDataReader products = base.dbContext.Read(sql))
            {
                while (products.Read())
                {
                    ProductsInCart.Add(this.modelFactory.StoreOwnerCreator.CreateModel(products));
                }
            }
            return ProductsInCart;
        }

        //StoreOwner(StoreOwnerName, StoreOwnerLastName, StoreOwnerPhoneNumber, StoreOwnerEmail, StoreID, StoreOwnerIMG)
        public bool Update(StoreOwner storeOwner)
        {
            string sql = $@"UPDATE StoreOwner SET StoreOwnerName = @StoreOwnerName
										StoreOwnerLastName = @StoreOwnerLastName
										StoreOwnerPhoneNumber = @StoreOwnerPhoneNumber
                                        StoreOwnerEmail = @StoreOwnerEmail
                                        StoreID = @StoreID
                                        StoreOwnerIMG = @StoreOwnerIMG
									WHERE storeOwnerID = @storeOwnerID";
            base.dbContext.AddParameters("@StoreOwnerName", storeOwner.StoreOwnerIMG);
            base.dbContext.AddParameters("@StoreOwnerLastName", storeOwner.StoreOwnerIMG);
            base.dbContext.AddParameters("@StoreOwnerPhoneNumber", storeOwner.StoreOwnerPhoneNumber);
            base.dbContext.AddParameters("@StoreOwnerEmail", storeOwner.StoreOwnerIMG);
            base.dbContext.AddParameters("@StoreID", storeOwner.StoreID.ToString());
            base.dbContext.AddParameters("@StoreOwnerIMG", storeOwner.StoreOwnerIMG);
            base.dbContext.AddParameters("@storeOwnerID", storeOwner.ID.ToString());
            return base.dbContext.Update(sql) > 0;
        }

        public StoreOwner GetByID(int ID)
        {
            string sql = $@"SELECT * FROM StoreOwner WHERE StoreOwnerID = @storeOwnerID";
            base.dbContext.AddParameters("@StoreOwnerID", ID.ToString());
            using (IDataReader storeOwner = base.dbContext.Read(sql))
            {
                storeOwner.Read();
                return this.modelFactory.StoreOwnerCreator.CreateModel(storeOwner);
            }

        }

        public int SignInReturnID(string StoreOwnerName, string StoreOwnerLastName, int StoreOwnerID)
        {
            string sql = $@"SELECT * FROM StoreOwner WHERE StoreOwnerName = @StoreOwnerName 
                                                        AND StoreOwnerLastName = @StoreOwnerLastName
                                                        AND StoreOwnerID = @StoreOwnerID";
            base.dbContext.AddParameters("@StoreOwnerName", StoreOwnerName);
            base.dbContext.AddParameters("@StoreOwnerLastName", StoreOwnerLastName);
            base.dbContext.AddParameters("@StoreOwnerID", StoreOwnerID.ToString());
            using (IDataReader reader = base.dbContext.Read(sql))
            {
                reader.Read();
                return this.modelFactory.StoreOwnerCreator.CreateModel(reader).ID;
            }
        }
    }
}
