using Models;
using System.Data;

namespace MallWS
{
    public class CartRepository : Repository, IRepository<Cart>
    {
        public CartRepository(DBContext dbContext) : base(dbContext)
        {

        }

        public bool Create(Cart model)
        {
            string sql = $@"Insert into Carts (CustomerID)
                            values(@CustomerID)";  //parameters for SQL Injection, extension 1
            this.dbContext.AddParameter("@CustomerID", model.Customer.CustomerID.ToString());
            return this.dbContext.Insert(sql);

        }

        public bool Delete(string ID)
        {
            string sql = "Delete from Carts where CartID=@CartID";
            this.dbContext.AddParameter("@CartsID", ID);
            return this.dbContext.Delete(sql);
        }

        public List<Cart> GetAll()
        {
            List<Cart> list = new List<Cart>();
            string sql = "Select * from Cart";
            using (IDataReader Cart = this.dbContext.Read(sql))
            {
                while (Cart.Read())
                {
                    list.Add(this.modelFactory.CartCreator.CreateModel(Cart));
                }
            }
            return list;
        }

        public Cart GetById(string ID)
        {
            string sql = "Select * from Carts Where CartID = @CartID";
            this.dbContext.AddParameter("@CartID", ID);
            using (IDataReader Cart = this.dbContext.Read(sql))
            {
                Cart.Read();
                return this.modelFactory.CartCreator.CreateModel(Cart);
            }
        }
        public bool Update(Cart model)
        {
            string sql = $@"UPDATE Carts SET CustomerID = CustomerID WHERE CartID = @CartID";
            //parameters for SQL Injection, extension 1
            this.dbContext.AddParameter("@CustomerID", model.Customer.CustomerID.ToString());
            return this.dbContext.Update(sql);
        }
    }
}
