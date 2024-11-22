using Models;
using System.Data;

namespace MallWS
{
    public class StoreRepository : Repository, IRepository<Store>
    {
        public StoreRepository(DBContext dbContext) : base(dbContext)
        {

        }

        public bool Create(Store model)
        {
            string sql = $@"Insert into Stores (StoreName, StoreType, StoreIMG, StoreFloor, StoreDescription)
                            values(@StoreName,@StoreType, @StoreIMG, @StoreFloor, @StoreDescription)";  //parameters for SQL Injection, extension 1
            this.dbContext.AddParameter("@StoreName", model.StoreName);
            this.dbContext.AddParameter("@StoreType", model.StoreType);
            this.dbContext.AddParameter("@StoreIMG", model.StoreIMG);
            this.dbContext.AddParameter("@StoreFloor", model.StoreFloor.ToString());
            this.dbContext.AddParameter("@StoreDescription", model.StoreDescription);
            return this.dbContext.Insert(sql);

        }

        public bool Delete(string ID)
        {
            string sql = "Delete from Stores where StoreID=@StoreID";
            this.dbContext.AddParameter("@StoresID", ID);
            return this.dbContext.Delete(sql);
        }

        public List<Store> GetAll()
        {
            List<Store> list = new List<Store>();
            string sql = "Select * from Store";
            using (IDataReader Store = this.dbContext.Read(sql))
            {
                while (Store.Read())
                {
                    list.Add(this.modelFactory.StoreCreator.CreateModel(Store));
                }
            }
            return list;
        }

        public Store GetById(string ID)
        {
            string sql = "Select * from Stores Where StoreID = @StoreID";
            this.dbContext.AddParameter("@StoreID", ID);
            using (IDataReader Store = this.dbContext.Read(sql))
            {
                Store.Read();
                return this.modelFactory.StoreCreator.CreateModel(Store);
            }
        }
        public bool Update(Store model)
        {
            string sql = $@"UPDATE Stores SET StoreName = @StoreName, StoreType = @StoreType, StoreIMG = @StoreIMG, StoreFloor = @StoreFloor, StoreDescription = @StoreDescription WHERE StoreID = @StoreID";
                           //parameters for SQL Injection, extension 1
            this.dbContext.AddParameter("@StoreName", model.StoreName);
            this.dbContext.AddParameter("@StoreType", model.StoreType);
            this.dbContext.AddParameter("@StoreIMG", model.StoreIMG);
            this.dbContext.AddParameter("@StoreFloor", model.StoreFloor.ToString());
            this.dbContext.AddParameter("@StoreDescription", model.StoreDescription);
            return this.dbContext.Update(sql);
        }
    }
}
