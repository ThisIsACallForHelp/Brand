using Models;
using System.Data;
namespace WebService
{
    public class CartProductRepository : Repository, IRepository<CartProduct>
    {
        public CartProductRepository(DBContext dbContext) : base(dbContext)
        {

        }

        public bool Create(CartProduct cartProduct)
        {
            string sql = $@"INSERT INTO CartProduct(CustomerID, ProductID, Quantity)
					VALUES(@CustomerID, @ProductID, @Quantity)";
            base.dbContext.AddParameters("@CustomerID", cartProduct.CustomerID.ToString());
            base.dbContext.AddParameters("@ProductID", cartProduct.ProductID.ToString());
            base.dbContext.AddParameters("@Quantity", cartProduct.Quantity.ToString());
            return base.dbContext.Create(sql) > 0;
        }

        public bool DeleteByID(int ID)
        {
            string sql = $@"DELETE FROM CartProduct WHERE CartProductID = @CartProductID";
            base.dbContext.AddParameters("@CartProductID", ID.ToString());
            return base.dbContext.Delete(sql) > 0;
        }

        public bool Delete(CartProduct cartProduct)
        {
            string sql = $@"DELETE FROM CartProduct WHERE CartProductID = @CartProductID";
            base.dbContext.AddParameters("@CartProductID", cartProduct.ID.ToString());
            return base.dbContext.Delete(sql) > 0;
        }
        public List<CartProduct> GetAll()
        {
            List<CartProduct> ProductsInCart = new List<CartProduct>();
            string sql = $@"SELECT * FROM CartProduct";
            using (IDataReader products = base.dbContext.Read(sql))
            {
                while (products.Read())
                {
                    ProductsInCart.Add(this.modelFactory.CartProductCreator.CreateModel(products));
                }
            }
            return ProductsInCart;
        }

        public bool Update(CartProduct cartProduct)
        {
            string sql = $@"UPDATE CartProduct SET  
										ProductID = @ProductID
										Quantity = @Quantity
									WHERE CartProductID = @CartProductID";
            base.dbContext.AddParameters("@CustomerID", cartProduct.CustomerID.ToString());
            base.dbContext.AddParameters("@ProductID", cartProduct.ProductID.ToString());
            base.dbContext.AddParameters("@Quantity", cartProduct.Quantity.ToString());
            base.dbContext.AddParameters("@CartProductID", cartProduct.ID.ToString());
            return base.dbContext.Update(sql) > 0;
        }

        public CartProduct GetByID(int ID)
        {
            string sql = $@"SELECT * FROM CartProduct WHERE CartProductID = @cartProductID";
            base.dbContext.AddParameters("@CartProductID", ID.ToString());
            using (IDataReader cartProduct = base.dbContext.Read(sql))
            {
                cartProduct.Read();
                return this.modelFactory.CartProductCreator.CreateModel(cartProduct);
            }

        }

        public bool DeleteByIDs(CartProduct cartProduct)
        {
            string sql = $@"DELETE FROM CartProduct WHERE ProductID = @ProductID AND CustomerID=@CustomerID";
            base.dbContext.AddParameters("@ProductID", cartProduct.ProductID.ToString());
            base.dbContext.AddParameters("@CustomerID", cartProduct.CustomerID.ToString());
            return base.dbContext.Delete(sql) > 0;
        }
    }
}
