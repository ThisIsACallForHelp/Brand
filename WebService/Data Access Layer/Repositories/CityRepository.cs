using Models;
using System.Data;

namespace WebService
{
    public class CityRepository : Repository, IRepository<City>
    {
        public CityRepository(DBContext dbContext) : base(dbContext)
        {

        }
        public bool Create(City city)
        {
            string sql = $@"INSERT INTO City(CityID, CityName)
                            VALUES(@CityID, @CityName)";
            base.dbContext.AddParameters("@CityID", city.CityName);
            base.dbContext.AddParameters("@CityName", city.ID.ToString());
            return this.dbContext.Create(sql) > 0;
        }
        public City GetByID(int ID)
        {
            string sql = $@"SELECT FROM City WHERE CityID = @cityID";
            base.dbContext.AddParameters("@CityID", ID.ToString());
            using (IDataReader city = base.dbContext.Read(sql))
            {
                city.Read(); //Read the object 
                return this.modelFactory.CityCreator.CreateModel(city); //return the brand 
            }
        }
        public List<City> GetAll()
        {
            List<City> Cities = new List<City>();
            string sql = $@"SELECT * FROM City";
            using (IDataReader city = base.dbContext.Read(sql))
            {
                while (city.Read()) //until you have not reached the end...
                {
                    Cities.Add(this.modelFactory.CityCreator.CreateModel(city)); //add the brand into the list
                }
            }
            return Cities; //return it 
        }
        public bool Update(City city)
        {
            string sql = $@"UPDATE City SET CityName = @CityName
                                        WHERE CityID = @CityID";
            base.dbContext.AddParameters("@CityID", city.ID.ToString());
            base.dbContext.AddParameters("@CityName", city.CityName);
            return this.dbContext.Update(sql) > 0;
        }

        public bool DeleteByID(int ID)
        {
            string sql = $@"DELETE FROM City WHERE CityID = @cityID";
            base.dbContext.AddParameters("@CityName", ID.ToString());
            return dbContext.Delete(sql) > 0;
        }
        public bool Delete(City city)
        {
            string sql = $@"DELETE FROM City WHERE CityID = @CityID";
            base.dbContext.AddParameters("@CityID", city.ID.ToString());
            return dbContext.Delete(sql) > 0;
        }

        public List<Customer> AllCustomersFromCity(City city)
        {
            List<Customer> customers = new List<Customer>();
            string sql = $@"SELECT * FROM Customer WHERE CityID = @CityID";
            using (IDataReader customer = base.dbContext.Read(sql))
            {
                while (customer.Read()) //until you have not reached the end...
                {
                    customers.Add(this.modelFactory.CustomerCreator.CreateModel(customer)); //add the brand into the list
                }
            }
            return customers;
        }

        public string GetCityByCustomerID(int CustomerID)
        {
            string sql = $@"SELECT City.CityName, City.CityID FROM City LEFT JOIN
                            Customer ON Customer.CityID = City.CityID WHERE Customer.CustomerID = @customerID";
            using (IDataReader reader = base.dbContext.Read(sql))
            {
                reader.Read();
                return this.modelFactory.CityCreator.CreateModel(reader).CityName;
            }
        }
    }
}
