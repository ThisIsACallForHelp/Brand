using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Models
{
    public class CatalogViewModel
    {
        public List<Store> Stores { get; set; }        
        public int StoreNumber { get; set; }
        public int BrandID { get; set; }
        public int SaleID {  get; set; }
        public int StoreTypeID {  get; set; }
    }
}
