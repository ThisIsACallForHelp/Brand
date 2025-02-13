namespace MallWebService
{
    public class ModelFactory
    {
        BrandCreator Brandcreator; //Brand creator
        CartCreator Cartcreator; //Cart creator
        CustomerCreator Customercreator; //Customer creator
        ProductCreator Productcreator; //Product creator
        SaleCreator Salecreator; //Sale creator
        StoreCreator Storecreator; //Store creator 

        
        public BrandCreator BrandCreator //lazy initialization
        {
            get 
            {
                if (this.Brandcreator == null) //if this creator object is null
                {
                    this.Brandcreator = new BrandCreator(); //assemble the Model 
                }
                return this.Brandcreator;
            }
        }
        public CartCreator CartCreator //lazy initialization
        {
            get
            {
                if (this.Cartcreator == null) //if this creator object is null
                {
                    this.Cartcreator = new CartCreator(); //create a new object
                }
                return this.Cartcreator;
            }
        }
        public CustomerCreator CustomerCreator //lazy initialization
        {
            get
            {
                if (this.Customercreator == null) //if this creator object is null
                {
                    this.Customercreator = new CustomerCreator(); //create a new object
                }
                return this.Customercreator; 
            }

        }
        public ProductCreator ProductCreator //lazy initialization
        {
            get
            {
                if(this.Productcreator == null) //if this creator object is null
                {
                    this.Productcreator = new ProductCreator(); //create a new object
                }
                return this.Productcreator;
            }
        }
        public SaleCreator SaleCreator //lazy initialization
        {
            get
            {
                if(this.Salecreator == null) //if this creator object is null
                {
                    this.Salecreator = new SaleCreator(); //create a new object
                }
                return this.Salecreator;
            }
            
        }
        public StoreCreator StoreCreator //lazy initialization
        {
            get
            {
                if(this.Storecreator == null) //if this creator object is null
                {
                    this.Storecreator = new StoreCreator(); //create a new object
                }
                return this.Storecreator;
            }
        }
        
    }
}
