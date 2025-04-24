using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CustomerCartViewModel
    {
        public List<Product>? products {  get; set; }
        //list of products
        public int CustomerID { get; set; }
        
    }
}
