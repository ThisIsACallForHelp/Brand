using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Product : Model //Inherit the ID
    {
        public string? ProductName { get; set; } 
        //Product's name
        public int ProductPrice { get; set; } 
        //The price
        public int? StoreID { get; set; } 
        //the ID of the store which sells the product
        public int? ProductBrand { get; set; } 
        //The ID of the brand that seels the product 
        public string? ProductIMG {  get; set; } 
        //Product's image
        public int SaleID { get; set; } 
        //Sale ID, if the product is put on sale
    }
}
