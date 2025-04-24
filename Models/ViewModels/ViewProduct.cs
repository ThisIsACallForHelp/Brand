using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ViewProduct
    {
        public Product Product { get; set; }
        public string StoreName { get; set; }
        public int? Quantity { get; set; }
    }
}
