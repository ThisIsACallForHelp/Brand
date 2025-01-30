

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
        public BrandRepository BrandRepository //create a repository
        {
            //lazy initialization technique 
            get
            {
                if(brandRepository == null) //if this repositroy doesnt exist
                {
                    brandRepository = new BrandRepository(DBContext.GetInstance());
                    //make a new one
                }
                return brandRepository; //return it 
            }
        }
        public CartRepository CartRepository //create a repository
        {
            //lazy initialization technique 
            get
            {
                if (CartRepository == null) //if this repositroy doesnt exist
                {
                    cartRepository = new CartRepository(DBContext.GetInstance());
                    //make a new one
                }
                return CartRepository;
                //return it 
            }
        }
        public CustomerRepository CustomerRepository //create a repository
        {
            //lazy initialization technique 
            get
            {
                if (CustomerRepository == null) //if this repositroy doesnt exist
                {
                    customerRepository = new CustomerRepository(DBContext.GetInstance());
                    //make a new one
                }
                return customerRepository;
                //return it 
            }
        }
        public ProductRepository ProductRepository //create a repository
        {
            //lazy initialization technique 
            get
            {
                if (ProductRepository == null) //if this repositroy doesnt exist
                {
                    productRepository = new ProductRepository(DBContext.GetInstance());
                    //make a new one
                }
                return productRepository;
                //return it 
            }
        }
        public SaleRepository SaleRepository //create a repository
        {
            //lazy initialization technique 
            get
            {
                if (SaleRepository == null)//if this repositroy doesnt exist
                {
                    saleRepository = new SaleRepository(DBContext.GetInstance());
                    //make a new one
                }
                return saleRepository;
                //return it 
            }
        }
        public StoreRepository StoreRepository //create a repository
        {
            //lazy initialization technique 
            get
            {
                if (StoreRepository == null) //if this repositroy doesnt exist
                {
                    storeRepository = new StoreRepository(DBContext.GetInstance());
                    //make a new one
                }
                return storeRepository;
                //return it 
            }
        }

    }
}
