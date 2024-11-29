using Models;
using System.Data;

namespace MallWS
{
    public class CustomerRepository : Repository, IRepository<Customer>
    {
        public CustomerRepository(DBContext dbContext) : base(dbContext)
        {

        }
        public bool Create(Customer model)
        {
            string sql = $@"Insert into Customers (CustomerFirstName, CustomerLastName, CustomerPhoneNumber, CustomerEmail, CustomerCity, CustomerStreet, CustomerPassword)
                            values(@CustomerFirstName,@CustomerLastName, @CustomerPhoneNumber, @CustomerEmail, @CustomerCity, @CustomerStreet, @CustomerPassword)";  //parameters for SQL Injection, extension 1
            this.dbContext.AddParameter("@CustomerFirstName", model.CustomerFirstName);
            this.dbContext.AddParameter("@CustomerLastName", model.CustomerLastName);
            this.dbContext.AddParameter("@CustomerPhoneNumber", model.CustomerPhoneNumber);
            this.dbContext.AddParameter("@CustomerEmail", model.CustomerEmail);
            this.dbContext.AddParameter("@CustomerCity", model.CustomerCity);
            this.dbContext.AddParameter("@CustomerStreet", model.CustomerStreet);
            this.dbContext.AddParameter("@CustomerPassword", model.CustomerPassword);
            return this.dbContext.Insert(sql);

        }

        public Customer LoginAttempt(Customer customer)
        {
            string sql = "SELECT * FROM Customers WHERE CustomerID = @CustomerID";
            using (IDataReader customerLogin = this.dbContext.Read(sql))
            {
                customerLogin.Read();
                return this.modelFactory.CustomerCreator.CreateModel(customerLogin);
            }
        }

        public bool Delete(string ID)
        {
            string sql = "Delete from Customers where CustomerID=@CustomerID";
            this.dbContext.AddParameter("@CustomersID", ID);
            return this.dbContext.Delete(sql);
        }

        public List<Customer> GetAll()
        {
            List<Customer> list = new List<Customer>();
            string sql = "Select * from Customer";
            using (IDataReader Customer = this.dbContext.Read(sql))
            {
                while (Customer.Read())
                {
                    list.Add(this.modelFactory.CustomerCreator.CreateModel(Customer));
                }
            }
            return list;
        }

        public Customer GetById(string ID)
        {
            string sql = "Select * from Customers Where CustomerID = @CustomerID";
            this.dbContext.AddParameter("@CustomerID", ID);
            using (IDataReader Customer = this.dbContext.Read(sql))
            {
                Customer.Read();
                return this.modelFactory.CustomerCreator.CreateModel(Customer);
            }
        }
        public bool Update(Customer model)
        {
            string sql = $@"Insert into Customers CustomerFirstName = @CustomerFirstName, CustomerLastName = @CustomerLastName, CustomerPhoneNumber = @CustomerPhoneNumber, CustomerEmail = @CustomerEmail, CustomerCity = @CustomerCity, CustomerStreet = @CustomerStreet, CustomerPassword = @CustomerPassword WHERE CustomerID = @CustomerID";
            //parameters for SQL Injection, extension 1
            this.dbContext.AddParameter("@CustomerFirstName", model.CustomerFirstName);
            this.dbContext.AddParameter("@CustomerLastName", model.CustomerLastName);
            this.dbContext.AddParameter("@CustomerPhoneNumber", model.CustomerPhoneNumber);
            this.dbContext.AddParameter("@CustomerEmail", model.CustomerEmail);
            this.dbContext.AddParameter("@CustomerCity", model.CustomerCity);
            this.dbContext.AddParameter("@CustomerStreet", model.CustomerStreet);
            this.dbContext.AddParameter("@CustomerPassword", model.CustomerPassword);
            return this.dbContext.Update(sql);
        }
    }
}
