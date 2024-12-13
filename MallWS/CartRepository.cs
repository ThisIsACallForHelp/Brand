using Models;
using System.Data;
using System.Reflection;

namespace MallWS
{
    public class CartRepository : Repository, IRepository<Cart>
    {
        public CartRepository(DBContext dbContext) : base(dbContext)
        {

        }

        public bool Create(Cart model) //create a cart 
        {
            string sql = $@"Insert into Carts (CustomerID)
                            values(@CustomerID)";
            //SQL statement that says "insert a new cart with this info into the Carts table"
            this.dbContext.AddParameter("@CustomerID", model.Customer.CustomerID.ToString());
            return this.dbContext.Insert(sql); //inserts the new cart 

        }

        public bool Delete(string ID) //delete the cart by its ID 
        {
            string sql = "Delete from Carts where CartID=@CartID";
            //SQL statement that says "delete a cart from Carts that matches this ID"
            this.dbContext.AddParameter("@CartsID", ID);
            return this.dbContext.Delete(sql); //delete
        }

        public List<Cart> GetAll() //get all carts 
        {
            List<Cart> list = new List<Cart>(); //new list 
            string sql = "Select * from Cart";
            //SQL statement that says "select every column from carts"
            using (IDataReader Cart = this.dbContext.Read(sql)) //read the SQL command
            {
                while (Cart.Read()) //until you reach the end of the table....
                {
                    list.Add(this.modelFactory.CartCreator.CreateModel(Cart));
                    //add every cart to the list 
                }
            }
            return list; //return the list 
        }

        public Cart GetById(string ID) //get a cart by its ID
        {
            string sql = "Select * from Carts Where CartID = @CartID";
            //SQL statement that says "select every column from carts where the ID matches"
            this.dbContext.AddParameter("@CartID", ID);
            using (IDataReader Cart = this.dbContext.Read(sql)) //read the SQL command 
            {
                Cart.Read();
                return this.modelFactory.CartCreator.CreateModel(Cart); //return the cart with the matching ID
            }
        }
        public bool Update(Cart model)
        {
            string sql = $@"UPDATE Carts SET CustomerID = CustomerID WHERE CartID = @CartID";
            //SQL statement that says "update the cart from carts that has this ID"

            this.dbContext.AddParameter("@CustomerID", model.Customer.CustomerID.ToString());
            return this.dbContext.Update(sql); //Update
        }
        public bool ProductIntoCart(Product product)
        {
            string sql = "ALTER TABLE Cart ADD ProductID INT;" +
                         "\r\nALTER TABLE Cart ADD Quantity INT;\r\n" +
                         "INSERT INTO Cart (CartID, ProductID, Quantity)\r\n" +
                         "VALUES (@CartID, @ProductID);\r\n";
            this.dbContext.AddParameter("@ProductID", product.ProductID.ToString());
            return this.dbContext.Update(sql);
        }
        public bool DeleteProductInCart(Product product)
        {
            string sql = "\r\nDELETE FROM Cart\r\nWHERE CartID = @CartID AND ProductID = @ProductID;\r\n";
            this.dbContext.AddParameter("@ProductID", product.ProductID.ToString());
            return this.dbContext.Delete(sql);
        }
    }
}