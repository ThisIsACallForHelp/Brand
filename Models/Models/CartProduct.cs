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
        public int CustomerID { get; set; }

        //public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
