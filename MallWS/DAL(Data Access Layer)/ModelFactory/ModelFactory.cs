namespace MallWS
{
    public class ModelFactory
    {
        BrandCreator Brandcreator;
        CartCreator Cartcreator;
        CustomerCreator Customercreator;
        ProductCreator Productcreator;
        SaleCreator Salecreator;
        StoreCreator Storecreator;

        /// <summary>
        /// 
        /// </summary>
        public BrandCreator BrandCreator
        {
            get
            {
                if (this.Brandcreator == null)
                {
                    this.Brandcreator = new BrandCreator();
                }
                return this.Brandcreator;
            }
        }
        public CartCreator CartCreator
        {
            get
            {
                if (this.Cartcreator == null)
                {
                    this.Cartcreator = new CartCreator();
                }
                return this.Cartcreator;
            }
        }
        public CustomerCreator CustomerCreator
        {
            get
            {
                if (this.Customercreator == null)
                {
                    this.Customercreator = new CustomerCreator();
                }
                return this.Customercreator;
            }

        }
        public ProductCreator ProductCreator
        {
            get
            {
                if(this.Productcreator == null)
                {
                    this.Productcreator = new ProductCreator();
                }
                return this.Productcreator;
            }
        }
        public SaleCreator SaleCreator
        {
            get
            {
                if(this.Salecreator == null)
                {
                    this.Salecreator = new SaleCreator();
                }
                return this.Salecreator;
            }
            
        }
        public StoreCreator StoreCreator
        {
            get
            {
                if(this.Storecreator == null)
                {
                    this.Storecreator = new StoreCreator();
                }
                return this.Storecreator;
            }
        }
        
    }
}
