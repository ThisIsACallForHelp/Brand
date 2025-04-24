using Models;
namespace WebService
{
    public class UnitOfWork
    {
        BrandRepository? brandRepository;
        CartRepository? cartRepository;
        CityRepository? cityRepository;
        CustomerRepository? customerRepository;
        ProductRepository? productRepository;
        SaleRepository? saleRepository;
        StoreRepository? storeRepository;
        StoreTypeRepository? storeTypeRepository;
        CartProductRepository? cartProductRepository;
        StoreOwnerRepository? storeOwnerRepository;

        DBContext dbContext;
        public UnitOfWork(DBContext dbcontext)
        {
            this.dbContext = DBContext.GetInstance();
        }

        public StoreOwnerRepository StoreOwnerRepository
        {
            get
            {
                if (this.storeOwnerRepository == null)
                {
                    this.storeOwnerRepository = new StoreOwnerRepository(this.dbContext);
                }
                return this.storeOwnerRepository;
            }
        }

        public BrandRepository BrandRepository
        {
            get
            {
                if(this.brandRepository == null)
                {
                    this.brandRepository = new BrandRepository(this.dbContext);
                }
                return this.brandRepository;
            }
        }

        public CartRepository CartRepository
        {
            get
            {
                if (this.cartRepository == null)
                {
                    this.cartRepository = new CartRepository(this.dbContext);
                }
                return this.cartRepository;
            }
        }
        public CityRepository CityRepository
        {
            get
            {
                if (this.cityRepository == null)
                {
                    this.cityRepository = new CityRepository(this.dbContext);
                }
                return this.cityRepository;
            }
        }
        public CustomerRepository CustomerRepository
        {
            get
            {
                if (this.customerRepository == null)
                {
                    this.customerRepository = new CustomerRepository(this.dbContext);
                }
                return this.customerRepository;
            }
        }
        public ProductRepository ProductRepository
        {
            get
            {
                if (this.productRepository == null)
                {
                    this.productRepository = new ProductRepository(this.dbContext);
                }
                return this.productRepository;
            }
        }
        public SaleRepository SaleRepository
        {
            get
            {
                if (this.saleRepository == null)
                {
                    this.saleRepository = new SaleRepository(this.dbContext);
                }
                return this.saleRepository;
            }
        }
        public StoreRepository StoreRepository
        {
            get
            {
                if (this.storeRepository == null)
                {
                    this.storeRepository = new StoreRepository(this.dbContext);
                }
                return this.storeRepository;
            }
        }
        public StoreTypeRepository StoreTypeRepository
        {
            get
            {
                if (this.storeTypeRepository == null)
                {
                    this.storeTypeRepository = new StoreTypeRepository(this.dbContext);
                }
                return this.storeTypeRepository;
            }
        }

        public CartProductRepository CartProductRepository
        {
            get
            {
                if (this.cartProductRepository == null)
                {
                    this.cartProductRepository = new CartProductRepository(this.dbContext);
                }
                return this.cartProductRepository;
            }
        }

    }
}
