using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Brand : Model
    {
        public string BrandName { get; set; }
        public string BrandIMG { get; set; }
        public List<Product> Products { get; set; }
        public List<Sale> Sales { get; set; }

    }
}

