using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AJAXViewModel
    {
        public List<Product> products { get; set; }
        public List<Store> stores { get; set; }
        public int PageNumber { get; set; }
        public int MaxPage {  get; set; }
        public int? StoreTypeID { get; set; }
        public int? BrandID { get; set; }
        public int? StoreID { get; set; }
        public int? SaleID { get; set; }
    }
}
