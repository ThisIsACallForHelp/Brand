using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Product : Model //Inherit the ID
    {
        public string? ProductName { get; set; } //name
        public int ProductPrice { get; set; } //price
        public int? StoreID { get; set; } //home store
        public int? ProductBrand { get; set; } //home brand
        public string? ProductIMG {  get; set; } //image
        public int SaleID { get; set; } // sale (if it is on sale)
    }
}
