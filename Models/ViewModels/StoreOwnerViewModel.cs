using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class StoreOwnerViewModel
    {
        public List<Product>? Products { get; set; }
        public bool? OnSale {  get; set; }
        public int StoreOwnerID { get; set; }
        //public int Choice {  get; set; }
    }
}
