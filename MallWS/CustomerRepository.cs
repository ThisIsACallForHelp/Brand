using Models;
using System.Data;

namespace MallWS
{
    public class CustomerRepository : Repository, IRepository<Customer>
    {
        public CustomerRepository(DBContext dbContext) : base(dbContext)
        {

        }
        public bool Create(Customer model) //create a customer
        {
            string sql = $@"Insert into Customers (CustomerFirstName, CustomerLastName, CustomerPhoneNumber, CustomerEmail, CustomerCity, CustomerStreet, CustomerPassword)
                            values(@CustomerFirstName,@CustomerLastName, @CustomerPhoneNumber, @CustomerEmail, @CustomerCity, @CustomerStreet, @CustomerPassword)";  
            //enter a new customer to the DB 
            this.dbContext.AddParameter("@CustomerFirstName", model.CustomerFirstName);
            this.dbContext.AddParameter("@CustomerLastName", model.CustomerLastName);
            this.dbContext.AddParameter("@CustomerPhoneNumber", model.CustomerPhoneNumber);
            this.dbContext.AddParameter("@CustomerEmail", model.CustomerEmail);
            this.dbContext.AddParameter("@CustomerCity", model.CustomerCity);
            this.dbContext.AddParameter("@CustomerStreet", model.CustomerStreet);
            this.dbContext.AddParameter("@CustomerPassword", model.CustomerPassword);
            return this.dbContext.Insert(sql); //execute the sql

        }

        public Customer LoginAttempt(string CustomerFirstName, string CustomerLastName, string CustomerPassword)
        {
            string sql = "SELECT * FROM Customers WHERE CustomerPassword = @CustomerPassword AND CustomerFirstName=@CustomerFirstName AND CustomerLastName=@CustomerLastName";
            using (IDataReader customerLogin = this.dbContext.Read(sql))
            {
                customerLogin.Read();
                return this.modelFactory.CustomerCreator.CreateModel(customerLogin);
            }
        }

        public bool Delete(string ID) //delete a specific customer 
        {
            string sql = "Delete from Customers where CustomerID=@CustomerID";
            //delete the customer if there is a mach in the IDs
            this.dbContext.AddParameter("@CustomersID", ID);
            return this.dbContext.Delete(sql); //execute
        }

        public List<Customer> GetAll()
        {
            List<Customer> list = new List<Customer>(); //create a list
            string sql = "Select * from Customer"; //select everything from the customer table
            using (IDataReader Customer = this.dbContext.Read(sql))
            {
                while (Customer.Read()) //while you are still reading the customer table...
                {
                    list.Add(this.modelFactory.CustomerCreator.CreateModel(Customer)); 
                    //add every customer to the list
                }
            }
            return list;
            //return the list 
        }

        public Customer GetById(string ID) // get a customer by a specific ID
        {
            string sql = "Select * from Customers Where CustomerID = @CustomerID"; 
            //select every column from the customer table if it matches the ID
            this.dbContext.AddParameter("@CustomerID", ID);
            using (IDataReader Customer = this.dbContext.Read(sql))
            {
                Customer.Read(); //read the customer
                return this.modelFactory.CustomerCreator.CreateModel(Customer); //return the customer
            }
        }
        public bool Update(Customer model) //update the customer Info
        {
            string sql = $@"Insert into Customers CustomerFirstName = @CustomerFirstName, CustomerLastName = @CustomerLastName, CustomerPhoneNumber = @CustomerPhoneNumber, CustomerEmail = @CustomerEmail, CustomerCity = @CustomerCity, CustomerStreet = @CustomerStreet, CustomerPassword = @CustomerPassword WHERE CustomerID = @CustomerID";
            //update the Customer info where there is a match in the ID
            this.dbContext.AddParameter("@CustomerFirstName", model.CustomerFirstName);
            this.dbContext.AddParameter("@CustomerLastName", model.CustomerLastName);
            this.dbContext.AddParameter("@CustomerPhoneNumber", model.CustomerPhoneNumber);
            this.dbContext.AddParameter("@CustomerEmail", model.CustomerEmail);
            this.dbContext.AddParameter("@CustomerCity", model.CustomerCity);
            this.dbContext.AddParameter("@CustomerStreet", model.CustomerStreet);
            this.dbContext.AddParameter("@CustomerPassword", model.CustomerPassword);
            return this.dbContext.Update(sql); //execute the update 
        }

    }
}
