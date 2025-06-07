using Models;
using System.Data;

namespace WebService
{
    public class StoreRepository : Repository, IRepository<Store>
    {
        public StoreRepository(DBContext dbContext) : base(dbContext)
        {

        }
        public bool Create(Store store)
        {
            string sql = $@"INSERT INTO Store(StoreName, StoreID, StoreTypeID, StoreFloor, StoreDescription)
                            VALUES(@StoreName, @StoreID, @StoreTypeID, @StoreFloor, @StoreDescription)";
            base.dbContext.AddParameters("@StoreName", store.StoreName);
            base.dbContext.AddParameters("@StoreID", store.ID.ToString());
            base.dbContext.AddParameters("@StoreTypeID", store.StoreTypeID.ToString());
            base.dbContext.AddParameters("@StoreFloor", store.StoreFloor.ToString());
            base.dbContext.AddParameters("@StoreDescription", store.StoreDescription);
            return this.dbContext.Create(sql) > 0;
        }
        public Store GetByID(int StoreID)
        {
            string sql = $@"SELECT * FROM Store WHERE StoreID = @storeID";
            base.dbContext.AddParameters("@StoreID", StoreID.ToString());
            using (IDataReader store = base.dbContext.Read(sql))
            {
                store.Read(); //Read the object 
                return this.modelFactory.StoreCreator.CreateModel(store); //return the brand 
            }
        }
        public List<Store> GetAll()
        {
            List<Store> Stores = new List<Store>();
            string sql = $@"SELECT * FROM Store";
            using (IDataReader store = base.dbContext.Read(sql))
            {
                while (store.Read()) //until you have not reached the end...
                {
                    Stores.Add(this.modelFactory.StoreCreator.CreateModel(store)); //add the brand into the list
                }
            }
            return Stores; //return it 
        }
        public bool Update(Store store)
        {
            string sql = $@"UPDATE Store SET StoreName = @StoreName,
                                             StoreTypeID = @StoreTypeID,
                                             StoreFloor = @StoreFloor,
                                             StoreDescription = @StoreDescription
                                         WHERE  StoreID = @StoreID";
            base.dbContext.AddParameters("@StoreName", store.StoreName);
            base.dbContext.AddParameters("@StoreTypeID", store.StoreTypeID.ToString());
            base.dbContext.AddParameters("@StoreFloor", store.StoreFloor.ToString());
            base.dbContext.AddParameters("@StoreDescription", store.StoreDescription);
            base.dbContext.AddParameters("@StoreID", store.ID.ToString());
            return this.dbContext.Update(sql) > 0;
        }

        public bool DeleteByID(int ID)
        {
            string sql = $@"DELETE FROM Store WHERE StoreID = @storeID";
            base.dbContext.AddParameters("@StoreID", ID.ToString());
            return dbContext.Delete(sql) > 0;
        }

        public bool Delete(Store store)
        {
            string sql = $@"DELETE FROM Store WHERE StoreID = @StoreID";
            base.dbContext.AddParameters("@StoreID", store.ID.ToString());
            return dbContext.Delete(sql) > 0;
        }

        public List<Store> GetStoresByType(int storeTypeID)
        {
            List<Store> stores = new List<Store>();
            string sql = $@"SELECT * FROM Store WHERE StoreTypeID = @storeTypeID";
            base.dbContext.AddParameters("@StoreTypeID", storeTypeID.ToString());
            using (IDataReader store = base.dbContext.Read(sql))
            {
                while (store.Read()) //until you have not reached the end...
                {
                    stores.Add(this.modelFactory.StoreCreator.CreateModel(store)); //add the brand into the list
                }
            }
            return stores; //return it 
        }

        public string GetStoreByPID(int ProductID)
        {
            string sql = $@"SELECT Store.StoreName, Store.StoreID, Store.StoreTypeID, Store.StoreFloor, Store.StoreDescription
                                   FROM Store LEFT JOIN Product ON Store.StoreID = Product.StoreID
                                   WHERE Product.ProductID = @productID";
            base.dbContext.AddParameters("@ProductID", ProductID.ToString());
            using (IDataReader reader = base.dbContext.Read(sql))
            {
                reader.Read();
                return this.modelFactory.StoreCreator.CreateModel(reader).StoreName;
            }
        }

    }
}
