using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public  class Store : Model //inherit the ID
    {
        public string? StoreName { get; set; } 
        //Store's name  
        public int? StoreTypeID { get; set; }   
        //Store's Type ID
        public int? StoreFloor {  get; set; } 
        //Store's floor
        public string? StoreDescription { get; set; } 
        //description
    }
}
