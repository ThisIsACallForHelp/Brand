using Models;
using System.Data;

namespace MallWS
{
    public class StoreRepository : Repository, IRepository<Store>
    {
        public StoreRepository(DBContext dbContext) : base(dbContext)
        {

        }

        public bool Create(Store model) //insert a new store
        {
            string sql = $@"Insert into Stores (StoreName, StoreType, StoreIMG, StoreFloor, StoreDescription)
                            values(@StoreName,@StoreType, @StoreIMG, @StoreFloor, @StoreDescription)";  
            //SQL statememt that says "insert a store with this name, this type, this image, is located on this floor and has this description into the table in the DB"
            this.dbContext.AddParameter("@StoreName", model.StoreName);
            this.dbContext.AddParameter("@StoreType", model.StoreType);
            this.dbContext.AddParameter("@StoreIMG", model.StoreIMG);
            this.dbContext.AddParameter("@StoreFloor", model.StoreFloor.ToString());
            this.dbContext.AddParameter("@StoreDescription", model.StoreDescription);
            return this.dbContext.Insert(sql); //inserts the new store

        }

        public bool Delete(string ID) //delete a store with the same ID
        {
            string sql = "Delete from Stores where StoreID=@StoreID"; 
            //SQL command that says "delete a store with this ID"
            this.dbContext.AddParameter("@StoresID", ID);
            return this.dbContext.Delete(sql); //deletes the store 
        }

        public IEnumerable<Store> GetAll()
        {
            List<Store> list = new List<Store>(); //creates a new list 
            string sql = "Select * from Stores"; //select every column in store
            using (IDataReader Store = this.dbContext.Read(sql))
            {
                while (Store.Read())
                {
                    list.Add(this.modelFactory.StoreCreator.CreateModel(Store)); //add to the list 
                }
            }
            return list; //return the list 
        }

        public List<Store> GetTypeList()
        {
            string sql = "Select Distinct StoreType FROM Stores";
            //select the store type from stores, but dont show it more than once 
            List<Store> StoreTypes = new List<Store>(); //new list
            using (IDataReader StoreT = this.dbContext.Read(sql))
            {
                while (StoreT.Read()) //until you have reached the end...
                {
                    StoreTypes.Add(this.modelFactory.StoreCreator.CreateModel(StoreT));
                    //add to the list
                }
            }
            return StoreTypes; //return it
        }

        public List<Store> GetStoreByType(string StoreType) //get a store by type
        {
            string sql = "SELECT * FROM Stores WHERE StoreType = @StoreType";
            //select a store if it has the store type the user looks for
            List<Store> StoreTypes = new List<Store>(); //make  new list
            using (IDataReader StoreT = this.dbContext.Read(sql))
            {
                while (StoreT.Read()) //until you have reached the end
                {
                    StoreTypes.Add(this.modelFactory.StoreCreator.CreateModel(StoreT));
                    //add to the list
                }
            }
            return StoreTypes; //return the list
        }

        public Store GetById(string ID) //get the store by its ID
        {
            string sql = "Select * from Stores Where StoreID = @StoreID"; 
            //SQL statement that says "select a store with the same ID"
            this.dbContext.AddParameter("@StoreID", ID);
            using (IDataReader Store = this.dbContext.Read(sql))
            {
                Store.Read(); //read it
                return this.modelFactory.StoreCreator.CreateModel(Store); 
                // return this store
            }
        }
        public bool Update(Store model) //update the a store 
        {
            string sql = $@"UPDATE Stores SET StoreName = @StoreName, StoreType = @StoreType, StoreIMG = @StoreIMG, StoreFloor = @StoreFloor, StoreDescription = @StoreDescription WHERE StoreID = @StoreID";
            //SQL command tha says "update this info in a store with the same ID"
            this.dbContext.AddParameter("@StoreName", model.StoreName);
            this.dbContext.AddParameter("@StoreType", model.StoreType);
            this.dbContext.AddParameter("@StoreIMG", model.StoreIMG);
            this.dbContext.AddParameter("@StoreFloor", model.StoreFloor.ToString());
            this.dbContext.AddParameter("@StoreDescription", model.StoreDescription);
            return this.dbContext.Update(sql); //return 
        }
        public List<Store> GetStoresByBrand(Brand brand) //get a store by brand
        {
            string sql = "SELECT \r\n   " +
                        " Store.StoreName,\r\n    " +
                        "Store.StoreIMG,\r\n   " +
                        " Store.StoreDescription\r\n" +
                        "FROM \r\n   " +
                        " Store\r\n" +
                        "JOIN \r\n  " +
                        "  Brand\r\n" +
                        "ON \r\n   " +
                        " @Store.BrandName = @Brand.BrandName\r\n" +
                        "WHERE \r\n    @Brand.BrandName = @Brand.BrandName;";
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
    }
}