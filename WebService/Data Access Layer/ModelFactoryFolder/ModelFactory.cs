using Models;

namespace WebService
{
    public class ModelFactory
    {
        StoreOwnerCreator? storeOwnerCreator;
        BrandCreator? brandCreator;
        CityCreator? cityCreator;
        CustomerCreator? customerCreator;
        ProductCreator? productCreator;
        SaleCreator? saleCreator;
        StoreCreator? storeCreator;
        StoreTypeCreator? storeTypeCreator;
        CartProductCreator? cartProductCreator;

        public StoreOwnerCreator StoreOwnerCreator
        {
            get
            {
                if(this.storeOwnerCreator == null)
                {
                    this.storeOwnerCreator = new StoreOwnerCreator();
                }
                return this.storeOwnerCreator;
            }
        }
        public BrandCreator BrandCreator
        {
            get
            {
                if(this.brandCreator == null)
                {
                    this.brandCreator = new BrandCreator();
                }
                return this.brandCreator;
            }
        }
        public CityCreator CityCreator
        {
            get
            {
                if (this.cityCreator == null)
                {
                    this.cityCreator = new CityCreator();
                }
                return this.cityCreator;
            }
        }
        public CustomerCreator CustomerCreator
        {
            get
            {
                if (this.customerCreator == null)
                {
                    this.customerCreator = new CustomerCreator();
                }
                return this.customerCreator;
            }
        }
        public ProductCreator ProductCreator
        {
            get
            {
                if (this.productCreator == null)
                {
                    this.productCreator = new ProductCreator();
                }
                return this.productCreator;
            }
        }
        public SaleCreator SaleCreator
        {
            get
            {
                if (this.saleCreator == null)
                {
                    this.saleCreator = new SaleCreator();
                }
                return this.saleCreator;
            }
        }
        public StoreCreator StoreCreator
        {
            get
            {
                if (this.storeCreator == null)
                {
                    this.storeCreator = new StoreCreator();
                }
                return this.storeCreator;
            }
        }
        public StoreTypeCreator StoreTypeCreator
        {
            get
            {
                if (this.storeTypeCreator == null)
                {
                    this.storeTypeCreator = new StoreTypeCreator();
                }
                return this.storeTypeCreator;
            }
        }

        public CartProductCreator CartProductCreator
        {
            get
            {
                if(cartProductCreator == null)
                {
                    this.cartProductCreator = new CartProductCreator();
                }
                return this.cartProductCreator;
            }
        }

    }
}
