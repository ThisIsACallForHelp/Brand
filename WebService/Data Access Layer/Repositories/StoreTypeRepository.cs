using Models;
using System.Data;
namespace WebService
{
    public class StoreTypeRepository : Repository, IRepository<StoreType>
    {
        public StoreTypeRepository(DBContext dbContext) : base(dbContext)
        {

        }
        public bool Create(StoreType storeType)
        {
            string sql = $@"INSERT INTO StoreType(StoreTypeID,StoreTypeName)
                                 VALUES(@StoreTypeID, @StoreTypeName)";
            base.dbContext.AddParameters("@StoreTypeID", storeType.ID.ToString());
            base.dbContext.AddParameters("@StoreTypeName", storeType.StoreTypeName);
            return this.dbContext.Create(sql) > 0;
        }
        public StoreType GetByID(int ID)
        {
            string sql = $@"SELECT FROM StoreType WHERE StoreTypeID = @storeTypeID";
            base.dbContext.AddParameters("@StoreTypeID", ID.ToString());
            using (IDataReader storeType = base.dbContext.Read(sql))
            {
                storeType.Read(); //Read the object 
                return this.modelFactory.StoreTypeCreator.CreateModel(storeType); //return the brand 
            }
        }
        public List<StoreType> GetAll()
        {
            List<StoreType> StoreTypes = new List<StoreType>();
            string sql = $@"SELECT * FROM StoreType";
            using (IDataReader storeType = base.dbContext.Read(sql))
            {
                while (storeType.Read()) //until you have not reached the end...
                {
                    StoreTypes.Add(this.modelFactory.StoreTypeCreator.CreateModel(storeType)); //add the brand into the list
                }
            }
            return StoreTypes; //return it 
        }
        public bool Update(StoreType storeType)
        {
            string sql = $@"UPDATE Cart SET StoreTypeName = @StoreTypeName
                                             WHERE StoreTypeID = @StoreTypeID";
            base.dbContext.AddParameters("@StoreTypeID", storeType.ID.ToString());
            base.dbContext.AddParameters("@StoreTypeName", storeType.StoreTypeName);
            return this.dbContext.Update(sql) > 0;
        }
        public bool DeleteByID(int ID)
        {
            string sql = $@"DELETE FROM StoreType WHERE StoreTypeID = @storeTypeID";
            base.dbContext.AddParameters("@StoreTypeID", ID.ToString());
            return dbContext.Delete(sql) > 0;
        }
        public bool Delete(StoreType storeType)
        {
            string sql = $@"DELETE FROM StoreType WHERE StoreTypeID = @StoreTypeID";
            base.dbContext.AddParameters("@StoreTypeID", storeType.ID.ToString());
            return dbContext.Delete(sql) > 0;
        }
    }
}
