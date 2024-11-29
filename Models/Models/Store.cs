using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Store : Model
    {
        //Store Name Store Type Store IMG

        
        public string StoreName { get; set; }
        public string StoreType { get; set; }
        public string StoreIMG { get; set; }
        public int StoreFloor { get; set; }
        public string StoreDescription { get; set; }
        public List<Product> Products { get; set; }

    }
}

