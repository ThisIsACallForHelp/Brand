using Models;
using System.Collections.Generic;
using System.Data;
namespace WebService
{
    public class CartRepository : Repository, IRepository<Cart>
    {
        public CartRepository(DBContext dbContext) : base(dbContext)
        {

        }

        public bool Create(Cart cart)
        {
            string sql = $@"INSERT INTO Cart(CustomerID)
                            VALUES(@CustomerID)";
            base.dbContext.AddParameters("@CartID", cart.ID.ToString());
            base.dbContext.AddParameters("@CustomerID", cart.customer.ID.ToString());
            base.dbContext.AddParameters("@ProductID", cart.Product.ID.ToString());
            return this.dbContext.Create(sql) > 0;
        }
        public Cart GetByID(int ID)
        {
            string sql = $@"SELECT FROM Cart WHERE CartID = @cartID";
            base.dbContext.AddParameters("@CartID", ID.ToString());
            using (IDataReader cart = base.dbContext.Read(sql))
            {
                cart.Read(); //Read the object 
                return this.modelFactory.CartCreator.CreateModel(cart); //return the brand 
            }
        }
        public List<Cart> GetAll()
        {
            List<Cart> Carts = new List<Cart>();
            string sql = $@"SELECT * FROM Cart";
            using (IDataReader cart = base.dbContext.Read(sql))
            {
                while (cart.Read()) //until you have not reached the end...
                {
                    Carts.Add(this.modelFactory.CartCreator.CreateModel(cart)); //add the brand into the list
                }
            }
            return Carts; //return it 
        }
        public bool Update(Cart cart)
        {
            string sql = $@"UPDATE Cart SET CustomerID = @CustomerID
                                             WHERE CartID = @CartID";
            base.dbContext.AddParameters("@CartID", cart.ID.ToString());
            base.dbContext.AddParameters("@CustomerID", cart.customer.ID.ToString());
            return this.dbContext.Update(sql) > 0;
        }
        public bool DeleteByID(int ID)
        {
            string sql = $@"DELETE FROM Cart WHERE CartID = @cartID";
            base.dbContext.AddParameters("@CartID", ID.ToString());
            return dbContext.Delete(sql) > 0;
        }
        public bool Delete(Cart cart)
        {
            string sql = $@"DELETE FROM Cart WHERE CartID = @CartID";
            base.dbContext.AddParameters("@CartID", cart.ID.ToString());
            return dbContext.Delete(sql) > 0;
        }

        

        //TO DO: Add to cart func 
        public bool AddedToCart(int ProductID, int Quantity)
        {
            string sql = $@"INSERT INTO CartProduct(ProductID, Quantity)
                                        VALUES(@ProductID, @Quantity)";
            base.dbContext.AddParameters("@ProductID", ProductID.ToString());
            base.dbContext.AddParameters("@Quantity", Quantity.ToString());
            return this.dbContext.Create(sql) > 0;
        }

        public bool DeleteFromCart(int CartID, int ProductID)
        {
            string sql = "DELETE FROM CartProduct WHERE CartID = @cartID AND ProductID = @ProductID";
            base.dbContext.AddParameters("@CartID", CartID.ToString());
            base.dbContext.AddParameters("@ProductID", ProductID.ToString());
            return this.dbContext.Delete(sql) > 0;
        }

        public bool CreateByID(string CustomerFirstName, string CustomerLastName, string CustomerPassword)
        {
            int CustomerID;
            string sql = $@"SELECT * FROM Customer WHERE CustomerFirstName= @customerFirstName 
                                                    AND CustomerLastName = @customerLastName
                                                    AND CustomerPassword = @customerPassword";
            base.dbContext.AddParameters("@CustomerFirstName", CustomerFirstName);
            base.dbContext.AddParameters("@CustomerLastName", CustomerLastName);
            base.dbContext.AddParameters("@CustomerPassword", CustomerPassword);
            using (IDataReader reader = base.dbContext.Read(sql))
            {
                reader.Read();
                CustomerID = this.modelFactory.CustomerCreator.CreateModel(reader).ID;
                
            }
            return CreateCart(CustomerID);
        }

        public bool CreateCart(int CustomerID)
        {
            string sql = $@"INSERT INTO Cart(CustomerID)
                            VALUES(@customerID)";
            base.dbContext.AddParameters("@CustomerID", CustomerID.ToString());
            return base.dbContext.Create(sql) > 0;
        }

        public bool CreateWithID(int CustomerID)
        {
            string sql = $@"INSERT INTO Cart(CustomerID)
                            VALUES(@CustomerID)";
            base.dbContext.AddParameters("@CustomerID", CustomerID.ToString());
            return this.dbContext.Create(sql) > 0;
        }
    }
}
