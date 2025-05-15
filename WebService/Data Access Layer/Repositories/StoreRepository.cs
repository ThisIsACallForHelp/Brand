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
        public List<Store> GetStoresByBrand(Brand brand) //get a store by brand
        {
            string sql = $@"SELECT \r\n    " +
                        $@"Store.StoreName,\r\n   " +
                        $@"  Store.StoreFloor,\r\n " +
                        $@"   Store.StoreDescription\r\nFROM \r\n    " +
                        $@"Store\r\nINNER JOIN \r\n   " +
                        $@" StoreBrand ON Store.StoreID = StoreBrand.StoreID\r\n" +
                        $@"WHERE \r\n    StoreBrand.BrandID = @Brand.BrandID;\r\n";
            //select every piece of data from the store if the Brand name matches it
            List<Store> list = new List<Store>(); //make a list
            using (IDataReader BrandReader = this.dbContext.Read(sql))
            {
                while (BrandReader.Read()) //until you have reached the end
                {
                    list.Add(this.modelFactory.StoreCreator.CreateModel(BrandReader));
                    //add it to the list
                }
            }
            return list; //return it

        }

        //public bool AddProductToStore(Product product)
        //{
        //    string sql = $@"INSERT INTO Product (ProductName, ProductPrice, StoreID, BrandID, ProductIMG)" +
        //                 $@"\r\nVALUES (@ProductName,@ProductPrice,@StoreID,@BrandID,@ProductIMG );" +
        //                 $@"\r\n\r\nINSERT INTO StoreProduct (StoreID, ProductID)\r\n" +
        //                 $@"VALUES (@StoreID, @ProductID);";
        //    base.dbContext.AddParameters("@ProductName", product.ProductName);
        //    base.dbContext.AddParameters("@ProductPrice", product.ProductPrice.ToString());
        //    base.dbContext.AddParameters("@ProductStore", product.ProductStore.ID.ToString());
        //    base.dbContext.AddParameters("@ProductBrand", product.ProductBrand.ID.ToString());
        //    base.dbContext.AddParameters("@ProductIMG", product.ProductIMG);
        //    return this.dbContext.Create(sql) > 0;
        //}
        //public bool DeleteFromStore(Product product, Store store)
        //{
        //    string sql = $@"DELETE FROM StoreProduct\r\n\" + 
        //                $@"WHERE StoreID = @StoreID AND ProductID = @ProductID;\r\n";
        //    base.dbContext.AddParameters("@ProductID", product.ID.ToString());
        //    base.dbContext.AddParameters("@StoreID", store.ID.ToString());
        //    return this.dbContext.Delete(sql) > 0;
        //}

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

        public Store GetByOwnerID(int StoreOwnerID)
        {
            string sql = $@"SELECT Store.StoreName, Store.StoreTypeID, 
                                   Store.StoreFloor,
                                   StoreDescription, Store.StoreID FROM Store LEFT JOIN StoreOwner 
                                   ON Store.StoreID = StoreOwner.StoreID WHERE StoreOwner.StoreOwnerID = @StoreOwnerID";
            base.dbContext.AddParameters("@StoreOwnerID", StoreOwnerID.ToString());
            using (IDataReader reader = base.dbContext.Read(sql))
            {
                reader.Read();
                return this.modelFactory.StoreCreator.CreateModel(reader);
            }
        }
    }
}
