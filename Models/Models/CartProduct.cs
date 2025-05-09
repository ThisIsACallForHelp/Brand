using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CartProduct:Model
    {
        public int ProductID { get; set; }
        //The chosen product's ID 
        public int CustomerID { get; set; }
        //Customer's ID
        public int Quantity { get; set; }
        //Quantity, or the amount of the same product
    }
}
