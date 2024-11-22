using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Sale : Model
    {
        public int Percentage { get; set; }       
        public Product Product { get; set; }
        public Brand Brand { get; set; }

    }
}
