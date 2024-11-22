using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Cart : Model
    {
        public Customer CustomerID { get; set; }
        public Customer Customer { get; set; }
        public List<Product> Products { get; set; }
    }
}
