using System.Runtime.CompilerServices;
using static MallWebService.IDBContext;

namespace MallWebService
{
    public class UnitOfWork
    {
        BrandRepository? brandRepository;
        CartRepository? cartRepository;
        CustomerRepository? customerRepository;
        ProductRepository? productRepository;
        StoreRepository? storeRepository;
        SaleRepository? saleRepository;
        private DBContext dbContext;

        public UnitOfWork(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public BrandRepository BrandRepository
        {
            get
            {
                if (brandRepository == null)
                {
                    brandRepository = new BrandRepository(dbContext);
                }
                return brandRepository;
            }
        }

        public CartRepository CartRepository
        {
            get
            {
                if (cartRepository == null)
                {
                    cartRepository = new CartRepository(dbContext);
                }
                return cartRepository;
            }
        }

        public CustomerRepository CustomerRepository
        {
            get
            {
                if (customerRepository == null)
                {
                    customerRepository = new CustomerRepository(dbContext);
                }
                return customerRepository;
            }
        }

        public ProductRepository ProductRepository
        {
            get
            {
                if (productRepository == null)
                {
                    productRepository = new ProductRepository(dbContext);
                }
                return productRepository;
            }
        }

        public StoreRepository StoreRepository
        {
            get
            {
                if (storeRepository == null)
                {
                    storeRepository = new StoreRepository(dbContext);
                }
                return storeRepository;
            }
        }

        public SaleRepository SaleRepository
        {
            get
            {
                if (saleRepository == null)
                {
                    saleRepository = new SaleRepository(dbContext);
                }
                return saleRepository;
            }
        }
    }
}
