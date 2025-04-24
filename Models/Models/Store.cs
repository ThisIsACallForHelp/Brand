using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public  class Store : Model //inherit the ID
    {
        public string? StoreName { get; set; } //name  
        public int? StoreTypeID { get; set; }   //Type ID
        public string? StoreIMG { get; set; } //image
        public int? StoreFloor {  get; set; } //floor
        public string? StoreDescription { get; set; } //desc
    }
}
