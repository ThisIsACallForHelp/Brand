using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Product : Model
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double ProductPrice { get; set; }
        public int BrandID { get; set; }
        public string ProductIMG { get; set; }
        public Store Store { get; set; }
        public Sale Sale { get; set; }
        public Brand Brand { get; set; }
        public Cart Cart { get; set; }


    }
}

