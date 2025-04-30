using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CatalogViewModel
    {
        public List<Product>? Products {  get; set; }
        //list of products
        public int? Percentage { get; set; }
        //sale percentage 
        public List<StoreType>? storeTypes { get; set; }
        public List<Store>? stores { get; set; }
        public List<Brand>? Brands { get; set; }
        public int PageNumber { get; set; }

        public int? StoreTypeID { get; set; }
        public int? BrandID { get; set; }
        public int? StoreID { get; set; }
        public int? MaxPage { get; set; }
    }
}
