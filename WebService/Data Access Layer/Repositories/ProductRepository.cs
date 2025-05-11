using Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
namespace WebService
{
    public class ProductRepository : Repository, IRepository<Product>
    {
        public ProductRepository(DBContext dbContext) : base(dbContext)
        {

        }
        public bool Create(Product product)
        {

            string sql = $@"INSERT INTO Product(ProductName, ProductPrice, ProductID, StoreID, BrandID, ProductIMG)
                            VALUES('{product.ProductName}',{product.ProductPrice}, {product.ID}, {product.StoreID}, {product.ProductBrand}, '{product.ProductIMG}')";

            //base.dbContext.AddParameters("@ProductID", product.ID.ToString());
            //base.dbContext.AddParameters("@ProductName", product.ProductName);
            //base.dbContext.AddParameters("@ProductPrice", product.ProductPrice.ToString());
            //base.dbContext.AddParameters("@StoreID", product.StoreID.ToString());
            //base.dbContext.AddParameters("@BrandID", product.ProductBrand.ToString());
            //base.dbContext.AddParameters("@ProductIMG", product.ProductIMG);
            return this.dbContext.Create(sql) > 0;
        }
        public Product GetByID(int ProductID)
        {
            Product p = new Product();
            string sql = $@"SELECT * FROM Product WHERE ProductID = @ProductID";
            base.dbContext.AddParameters("@ProductID", ProductID.ToString());
            using (IDataReader product = base.dbContext.Read(sql))
            {
                product.Read(); //Read the object 
                return this.modelFactory.ProductCreator.CreateModel(product); //return the brand
            }
        }
        public List<Product> GetAll()
        {
            List<Product> Products = new List<Product>();
            string sql = $@"SELECT * FROM Product";
            using (IDataReader product = base.dbContext.Read(sql))
            {
                while (product.Read()) //until you have not reached the end...
                {
                    Products.Add(this.modelFactory.ProductCreator.CreateModel(product)); //add the brand into the list
                }
            }
            return Products; //return it 
        }

        public bool Update(Product product)
        {
            string sql = $@"UPDATE Product SET ProductName = @ProductName
                                               ProductPrice = @ProductPrice
                                               StoreID = @StoreID
                                               BrandID = @BrandID
                                               ProductIMG = @ProductIMG
                                           WHERE   ProductID = @ProductID";
            base.dbContext.AddParameters("@ProductID", product.ID.ToString());
            base.dbContext.AddParameters("@ProductName", product.ProductName);
            base.dbContext.AddParameters("@ProductPrice", product.ProductPrice.ToString());
            base.dbContext.AddParameters("@StoreID", product.StoreID.ToString());
            base.dbContext.AddParameters("@BrandID", product.ProductBrand.ToString());
            base.dbContext.AddParameters("@ProductIMG", product.ProductIMG);
            return this.dbContext.Update(sql) > 0;
        }

        public bool DeleteByID(int ProductID)
        {
            Console.WriteLine(ProductID);
            string sql = $@"DELETE FROM Product WHERE ProductID = {ProductID}";
            Console.WriteLine(sql);
            base.dbContext.AddParameters("@ProductID", ProductID.ToString());
            return dbContext.Delete(sql) > 0;
        }

        public bool Delete(Product product)
        {
            string sql = $@"DELETE FROM Product WHERE ProductID = @ProductID";
            base.dbContext.AddParameters("@ProductName", product.ID.ToString());
            return dbContext.Delete(sql) > 0;
        }

        public List<Product> ProductsFromStore(int StoreID)
        {
            string sql = $@"SELECT * FROM Product WHERE StoreID = @StoreID";
            base.dbContext.AddParameters("@StoreID", StoreID.ToString());
            List<Product> products = new List<Product>();
            using (IDataReader Product = base.dbContext.Read(sql)) //Read the command
            {
                while (Product.Read()) //until you didnt reach the end of this table...
                {
                    products.Add(this.modelFactory.ProductCreator.CreateModel(Product)); //add each product to the list
                }
            }
            return products; //return the list
        }

        public List<Product> PercentSalesRangeList(int SaleID)
        {
            List<Product> sales = new List<Product>();
            string sql = $@"SELECT Product.ProductID, Product.ProductName, Product.ProductPrice, Product.ProductIMG  
                            FROM Product LEFT JOIN Sales ON Product.SaleID = Sales.SaleID WHERE Sales.SaleID >= @SaleID AND Sales.Percentage <= 100";
            base.dbContext.AddParameters("@SaleID", SaleID.ToString());
            using (IDataReader sale = base.dbContext.Read(sql))
            {
                while (sale.Read()) //until you have not reached the end...
                {
                    sales.Add(this.modelFactory.ProductCreator.CreateModel(sale)); //add the brand into the list
                }
            }
            return sales; //return it 
        }




        public List<Product> ProductsFromBrand(int BrandID)
        {
            List<Product> products = new List<Product>();
            string sql = $@"SELECT * FROM Product WHERE Product.BrandID = @BrandID";
            base.dbContext.AddParameters("@BrandID", BrandID.ToString());
            using (IDataReader brandReader = base.dbContext.Read(sql))
            {
                while (brandReader.Read()) //until you have not reached the end...
                {
                    products.Add(this.modelFactory.ProductCreator.CreateModel(brandReader)); //add the brand into the list
                }
            }
            return products;
        }

        public int GetPrice(int ProductID)
        {
            string sql = $@"SELECT * FROM Product WHERE ProductID = {ProductID}";
            Console.WriteLine(sql);
            base.dbContext.AddParameters("@ProductID", ProductID.ToString());
            using (IDataReader product = base.dbContext.Read(sql))
            {
                product.Read(); //Read the object 
                return this.modelFactory.ProductCreator.CreateModel(product).ProductPrice;
            }
        }

        public bool ChangeSaleID(int ProductID, int SaleID)
        {
            int productPrice = GetPrice(ProductID);
            productPrice -= (productPrice / 100) * (SaleID * 5);
            string sql = $@"UPDATE Product SET 
                                   SaleID = {SaleID},
                                   ProductPrice = {productPrice}
                            WHERE ProductID = {ProductID}";
            base.dbContext.AddParameters("@SaleID", SaleID.ToString());
            base.dbContext.AddParameters("@ProductID", ProductID.ToString());
            return this.dbContext.Update(sql) > 0;
        }

        public List<Product> ProductsFromCart(int CustomerID)
        {
            List<Product> Products = new List<Product>();
            string sql = $@"SELECT Product.ProductName, Product.ProductPrice, Product.ProductID, Product.StoreID, Product.BrandID, Product.ProductIMG, Product.SaleID
                                   FROM Product LEFT JOIN CartProduct ON  
                            CartProduct.ProductID = Product.ProductID WHERE CartProduct.CustomerID = @CustomerID";
            base.dbContext.AddParameters("@CustomerID", CustomerID.ToString());
            using (IDataReader product = base.dbContext.Read(sql))
            {
                while (product.Read()) //until you have not reached the end...
                {
                    Products.Add(this.modelFactory.ProductCreator.CreateModel(product)); //add the brand into the list
                }
            }
            return Products;

        }

        public List<Product> CheckSaleAndStore(int StoreOwnerID, int SaleID)
        {
            List<Product> Products = new List<Product>();
            string sql = $@"SELECT * FROM Product LEFT JOIN StoreOwner
                                     ON Product.StoreID = StoreOwner.StoreID
                                     WHERE Product.SaleID >= @SaleID";
            using (IDataReader product = base.dbContext.Read(sql))
            {
                while (product.Read())
                {
                    Products.Add(this.modelFactory.ProductCreator.CreateModel(product));
                }
                return Products;
            }
        }

        public List<Product> FromBrandAndSale(int SaleID, int BrandID)
        {
            List<Product> Products = new List<Product>();
            string sql = $@"SELECT * FROM Product 
                            WHERE BrandID = @brandID AND SaleID >= @saleID";
            base.dbContext.AddParameters("@SaleID", SaleID.ToString());
            base.dbContext.AddParameters("@BrandID", BrandID.ToString());
            using (IDataReader product = base.dbContext.Read(sql))
            {
                while (product.Read())
                {
                    Products.Add(this.modelFactory.ProductCreator.CreateModel(product));
                }
                return Products;
            }
        }

        public bool DeleteSale(int ProductID)
        {
            string sql = $@"UPDATE Product SET SaleID=0 WHERE ProductID = {ProductID}";
            Console.WriteLine(sql);
            base.dbContext.AddParameters("@ProductID", ProductID.ToString());
            return base.dbContext.Update(sql) > 0;
        }

        public List<Product> GetByOwnerID(int StoreOwnerID)
        {
            string sql = $@"SELECT Product.ProductName, Product.ProductPrice, 
                                   Product.ProductID, Product.StoreID, 
                                   Product.BrandID, Product.ProductIMG, 
                                   Product.SaleID 
                                   FROM Product LEFT JOIN StoreOwner 
                                   ON Product.StoreID = StoreOwner.StoreID
                                   WHERE StoreOwner.StoreOwnerID = {StoreOwnerID}";
            List<Product> products = new List<Product>();
            base.dbContext.AddParameters("@StoreOwnerID", StoreOwnerID.ToString());
            Console.WriteLine(sql);
            using (IDataReader reader = base.dbContext.Read(sql))
            {
                while (reader.Read())
                {
                    products.Add(this.modelFactory.ProductCreator.CreateModel(reader));
                }
                return products;
            }
        }

        public List<Product> OwnerSales(int StoreOwnerID)
        {
            List<Product> Products = new List<Product>();
            string sql = $@"SELECT Product.ProductName, Product.ProductPrice, 
                                   Product.ProductID, Product.StoreID, 
                                   Product.BrandID, Product.ProductIMG, 
                                   Product.SaleID FROM Product LEFT JOIN StoreOwner
                                     ON Product.StoreID = StoreOwner.StoreID
                                     WHERE Product.SaleID > 0";
            base.dbContext.AddParameters("@StoreOwnerID", StoreOwnerID.ToString());
            using (IDataReader product = base.dbContext.Read(sql))
            {
                while (product.Read())
                {
                    Products.Add(this.modelFactory.ProductCreator.CreateModel(product));
                }
                return Products;
            }
        }

        public List<Product> SaleAndStore(int SaleID, int StoreID)
        {
            string sql = $@"SELECT * FROM Product WHERE SaleID >= {SaleID} AND StoreID = {StoreID}";
            Console.WriteLine(sql);
            List<Product> product = new List<Product>();
            base.dbContext.AddParameters("@SaleID", SaleID.ToString());
            base.dbContext.AddParameters("@StoreID", StoreID.ToString());
            using (IDataReader reader = base.dbContext.Read(sql))
            {
                while (reader.Read())
                {
                    product.Add(this.modelFactory.ProductCreator.CreateModel(reader));
                }
                return product;
            }
        }

        public List<Product> SaleAndBrand(int SaleID, int BrandID)
        {
            string sql = $@"SELECT * FROM Product WHERE SaleID >= @SaleID AND BrandID = @BrandID";
            List<Product> products = new List<Product>();
            base.dbContext.AddParameters("@SaleID", SaleID.ToString());
            base.dbContext.AddParameters("@BrandID", BrandID.ToString());
            using (IDataReader reader = base.dbContext.Read(sql))
            {
                while (reader.Read())
                {
                    products.Add(this.modelFactory.ProductCreator.CreateModel(reader));
                }
                return products;
            }
        }

        public int GetTotalPrice(int CustomerID, List<Product> products)
        {
            int i = 0;
            string sql = $@"SELECT * FROM CartProduct WHERE CustomerID = @CustomerID";
            base.dbContext.AddParameters("@CustomerID", CustomerID.ToString());
            using (IDataReader reader = base.dbContext.Read(sql))
            {
                while (reader.Read())
                {
                    products[i].ProductPrice *= this.modelFactory.CartProductCreator.CreateModel(reader).Quantity;
                    i++;
                }
                return products.Sum(p => p.ProductPrice);
            }
        }
    }
}
