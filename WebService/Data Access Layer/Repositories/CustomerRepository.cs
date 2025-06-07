using Models;
using System.Data;
using System.Text;

namespace WebService
{
    public class CustomerRepository : Repository, IRepository<Customer>
    {
        public CustomerRepository(DBContext dbContext) : base(dbContext)
        {

        }
        public bool Create(Customer customer)
        {
            string sql = $@"INSERT INTO Customer(CustomerFirstName, CustomerLastName, CustomerPhoneNumber, CustomerEmail, CityID, CustomerPassword)
                            VALUES(@CustomerFirstName,@CustomerLastName,@CustomerPhoneNumber,@CustomerEmail,@CityID,@CustomerPassword)";
            base.dbContext.AddParameters("@CustomerFirstName", customer.CustomerFirstName);
            base.dbContext.AddParameters("@CustomerLastName", customer.CustomerLastName);
            base.dbContext.AddParameters("@CustomerPhoneNumber", customer.CustomerPhoneNumber);
            base.dbContext.AddParameters("@CustomerEmail", customer.CustomerEmail);
            base.dbContext.AddParameters("@CityID", customer.CityID.ToString());
            base.dbContext.AddParameters("@CustomerPassword", customer.CustomerPassword);
            return base.dbContext.Create(sql) > 0;
        }

        public Customer GetByID(int ID)
        {
            string sql = $@"SELECT * FROM Customer WHERE CustomerID = @customerID";
            base.dbContext.AddParameters("@CustomerID", ID.ToString());
            using (IDataReader customer = base.dbContext.Read(sql))
            {
                customer.Read(); //Read the object 
                return this.modelFactory.CustomerCreator.CreateModel(customer); //return the brand 
            }
        }
        public List<Customer> GetAll()
        {
            List<Customer> Customers = new List<Customer>();
            string sql = $@"SELECT * FROM Customer";
            using (IDataReader customer = base.dbContext.Read(sql))
            {
                while (customer.Read()) //until you have not reached the end...
                {
                    Customers.Add(this.modelFactory.CustomerCreator.CreateModel(customer)); //add the brand into the list
                }
            }
            return Customers; //return it 
        }

        public bool Update(Customer customer)
        {
            string sql = $@"UPDATE Customer SET CustomerFirstName = @CustomerFirstName,
                                                CustomerLastName = @CustomerLastName,
                                                CustomerPhoneNumber = @CusotmerPhoneNumber,
                                                CustomerEmail = @CustomerEmail,
                                                CityID = @CityID,
                                                CustomerPassword = @CustomerPassword,
                                                CustomerIMG = @CustomerIMG
                                            WHERE CustomerID = @CustomerID";
            base.dbContext.AddParameters("@CustomerFirstName", customer.CustomerFirstName);
            base.dbContext.AddParameters("@CustomerLastName", customer.CustomerLastName);
            base.dbContext.AddParameters("@CustomerPhoneNumber", customer.CustomerPhoneNumber);
            base.dbContext.AddParameters("@CustomerEmail", customer.CustomerEmail);
            base.dbContext.AddParameters("@CityID", customer.CityID.ToString());
            base.dbContext.AddParameters("@CustomerPassword", customer.CustomerPassword);
            base.dbContext.AddParameters("@CustomerIMG", customer.CustomerIMG);
            return this.dbContext.Update(sql) > 0;
        }
        public bool DeleteByID(int ID)
        {
            string sql = $@"DELETE FROM Customer WHERE CustomerID = @customerID";
            base.dbContext.AddParameters("@CustomerID", ID.ToString());
            return dbContext.Delete(sql) > 0;

        }

        public bool Delete(Customer customer)
        {
            string sql = $@"DELETE FROM Customer WHERE CustomerID = @CustomerID";
            base.dbContext.AddParameters("@CustomerID", customer.ID.ToString());
            return dbContext.Delete(sql) > 0;
        }

        public int GetCustomerID(string CustomerFirstName, string CustomerLastName, string CustomerPassword)
        {
            string sql = $@"SELECT * FROM Customer WHERE 
                                                    CustomerFirstName = @customerFirstName AND 
                                                    CustomerLastName = @customerLastName AND 
                                                    CustomerPassword = @customerPassword";
            base.dbContext.AddParameters("@CustomerFirstName", CustomerFirstName);
            base.dbContext.AddParameters("@CustomerLastName", CustomerLastName);
            base.dbContext.AddParameters("@CustomerPassword", CustomerPassword);
            using (IDataReader customer = base.dbContext.Read(sql))
            {
                customer.Read();
                return this.modelFactory.CustomerCreator.CreateModel(customer).ID;
            }
        }

        public int CreateAndGetID(Customer customer)
        {
            if (Create(customer) == true)
            {
                Console.WriteLine(base.GetLastID());
                return base.GetLastID();
            }
            return 0;
        }
    }
}
