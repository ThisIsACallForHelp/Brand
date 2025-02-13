using Models;
using System.Data;
using System.Reflection;

namespace MallWebService
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
            AddParameters("@CustomerID", model.Customer.CustomerID.ToString());
            return this.dbContext.Create(sql) > 0; //inserts the new cart 

        }

        public bool Delete(string ID) //delete the cart by its ID 
        {
            string sql = "Delete from Carts where CartID=@CartID";
            //SQL statement that says "delete a cart from Carts that matches this ID"
            AddParameters("@CartsID", ID);
            return this.dbContext.Create(sql) > 0; //delete
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
            AddParameters("@CartID", ID);
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

            AddParameters("@CustomerID", model.Customer.CustomerID.ToString());
            return this.dbContext.Create(sql) > 0; //Update
        }
        public bool ProductIntoCart(Product product) //insert a product into a cart 
        {
            string sql = "ALTER TABLE Cart ADD ProductID INT;" +
                         "\r\nALTER TABLE Cart ADD Quantity INT;\r\n" +
                         "INSERT INTO Cart (CartID, ProductID, Quantity)\r\n" +
                         "VALUES (@CartID, @ProductID);\r\n";
            //enter the product into the cart
            AddParameters("@ProductID", product.ProductID.ToString());
            return this.dbContext.Create(sql) > 0;
            //update the cart
        }
        public bool DeleteProductInCart(Product product) //delete a product from cart
        {
            string sql = "\r\nDELETE FROM Cart\r\nWHERE CartID = @CartID AND ProductID = @ProductID;\r\n";
            //delete the product with this ID from a cart with this ID 
            AddParameters("@ProductID", product.ProductID.ToString());
            return this.dbContext.Delete(sql) > 0; //execute 
        }
    }
}