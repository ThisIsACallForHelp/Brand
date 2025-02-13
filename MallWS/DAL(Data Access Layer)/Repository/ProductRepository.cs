using Models;
using System.Collections.Generic;
using System.Data;

namespace MallWebService
{
    public class ProductRepository : Repository, IRepository<Product>
    {
        public ProductRepository(DBContext dbContext) : base(dbContext)
        {

        }

        public bool Create(Product model) //Create a model
        {
            string sql = $@"Insert into Products (ProductName, ProductPrice, StoreID, BrandID, ProductIMG)
                            values(@ProductName,@ProductIMG)";  //SQL that says --> "insert to a table named "Products" a new product with those values"
            AddParameters("@ProductName", model.ProductName);                //start 
            AddParameters("@ProductName", model.ProductName);
            AddParameters("@StoreID", model.Store.StoreID.ToString());            //this whole code block CREATES the product
            AddParameters("@BrandID", model.Brand.BrandID.ToString());
            AddParameters("@ProductIMG", model.ProductIMG);                  //end

            return this.dbContext.Create(sql) > 0; //inserts this new product into the DB by executing the SQL command

        }

        public bool Delete(string ID) //Delete a product with a given ID
        {
            string sql = "Delete from Products where ProductID=@ProductID"; //SQL command that say "delete a product from the "Products" table that has the same ID"
            AddParameters("@ProductsID", ID);
            return this.dbContext.Delete(sql) > 0; //executing the SQL command and deleting the product
        }

        public List<Product> GetAll() //get a list of products 
        {
            List<Product> list = new List<Product>();
            string sql = "Select * from Product"; //SQL command that says "Select every column from the "Products" table"
            using (IDataReader Product = this.dbContext.Read(sql)) //Read the command
            {
                while (Product.Read()) //until you didnt reach the end of this table...
                {
                    list.Add(this.modelFactory.ProductCreator.CreateModel(Product)); //add each product to the list
                }
            }
            return list; //return the list 
        }

        public List<Product> GetBySales()
        {
            string sql = "SELECT \r\n   " +
                         " Product.ProductName,\r\n " +
                         "   Product.ProductPrice,\r\n  " +
                         "  Product.ProductID,\r\n  " +
                         "  Product.StoreID,\r\n  " +
                         "  Product.BrandID,\r\n  " +
                         "  Product.ProductIMG,\r\n  " +
                         "  Sale.SaleID,\r\n   " +
                         " Sale.Percentage\r\nFROM \r\n  " +
                         "  Product\r\nINNER JOIN \r\n  " +
                         "  Sale ON Product.ProductID = Sale.ProductID;\r\n";
            //select every piece of data about the product and put it in the sales table
            List<Product> list = new List<Product>(); //make a new list
            using (IDataReader Product = this.dbContext.Read(sql)) //Read the command
            {
                while (Product.Read()) //until you didnt reach the end of this table...
                {
                    list.Add(this.modelFactory.ProductCreator.CreateModel(Product)); //add each product to the list
                }
            }
            return list;
        }
        public Product GetById(string ID) //get product by ID
        {
            string sql = "Select * from Products Where ProductID = @ProductID"; //SQL command that says "pick product with the same ID from "products" table"
            AddParameters("@ProductID", ID);
            using (IDataReader Product = this.dbContext.Read(sql)) //read the command
            {
                Product.Read();
                return this.modelFactory.ProductCreator.CreateModel(Product); //create the model
            }
        }

        public bool Update(Product model) // update something from the product table
        {
            string sql = $@"UPDATE Products SET ProductName = @ProductName, ProductPrice = @ProductPrice, StoreID = @StoreID, BrandID = @BrandID, ProductIMG = @ProductIMG WHERE ProductID == @ProductID)";
            //SQL command that says "update this product's name, price, store ID,brand ID and it's image if it has the same ID"

            AddParameters("@ProductName", model.ProductName);
            AddParameters("@ProductName", model.ProductName);
            AddParameters("@StoreID", model.Store.StoreID.ToString());
            AddParameters("@BrandID", model.Brand.BrandID.ToString());
            AddParameters("@ProductIMG", model.ProductIMG);
            return this.dbContext.Update(sql) > 0;//returns the updated the product
        }
        public List<Product> GetProductsFromStore(Store store)
        {
            string sql = "SELECT \r\n " +
                         "   Product.ProductName,\r\n  " +
                         "  Product.ProductPrice,\r\n  " +
                         "  Product.ProductID,\r\n  " +
                         "  Product.StoreID,\r\n   " +
                         " Product.BrandID,\r\n   " +
                         " Product.ProductIMG,\r\n " +
                         "   Store.StoreName,\r\n  " +
                         "  Store.StoreType,\r\n   " +
                         " Store.StoreIMG,\r\n    " +
                         "Store.StoreFloor,\r\n   " +
                         " Store.StoreDescription\r\nFROM \r\n " +
                         "   Product\r\nINNER JOIN \r\n  " +
                         "  Store ON Product.StoreID = Store.StoreID;\r\n";
            //get the products from a specific store if the IDs match
            List<Product> products = new List<Product>();
            using (IDataReader Product = this.dbContext.Read(sql)) //Read the command
            {
                while (Product.Read()) //until you didnt reach the end of this table...
                {
                    products.Add(this.modelFactory.ProductCreator.CreateModel(Product)); //add each product to the list
                }
            }
            return products; //return the list
        }
    }
}