

namespace MallWS
{
    public class MallUnitOfWorkRepositery
    {
        BrandRepository brandRepository;
        CartRepository cartRepository;
        CustomerRepository customerRepository;
        ProductRepository productRepository;
        SaleRepository saleRepository;
        StoreRepository storeRepository;

        DBContext dbContext;

        public MallUnitOfWorkRepositery(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public BrandRepository BrandRepository
        {
            get
            {
                if(brandRepository == null)
                {
                    brandRepository = new BrandRepository(DBContext.GetInstance());
                }
                return brandRepository;
            }
        }
        public CartRepository CartRepository
        {
            get
            {
                if (CartRepository == null)
                {
                    cartRepository = new CartRepository(DBContext.GetInstance());
                }
                return CartRepository;
            }
        }
        public CustomerRepository CustomerRepository
        {
            get
            {
                if (CustomerRepository == null)
                {
                    customerRepository = new CustomerRepository(DBContext.GetInstance());
                }
                return customerRepository;
            }
        }
        public ProductRepository ProductRepository
        {
            get
            {
                if (ProductRepository == null)
                {
                    productRepository = new ProductRepository(DBContext.GetInstance());
                }
                return productRepository;
            }
        }
        public SaleRepository SaleRepository
        {
            get
            {
                if (SaleRepository == null)
                {
                    saleRepository = new SaleRepository(DBContext.GetInstance());
                }
                return saleRepository;
            }
        }
        public StoreRepository StoreRepository
        {
            get
            {
                if (StoreRepository == null)
                {
                    storeRepository = new StoreRepository(DBContext.GetInstance());
                }
                return storeRepository;
            }
        }

    }
}
