using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Cart : Model //inherit the ID
    {
        public Customer? customer { get; set; } 
        //the owner of the cart
        public Product? Product {  get; set; } 
        //List of products in the cart
    }
}
