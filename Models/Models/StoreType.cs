using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class StoreType : Model //inherit the ID
    {
        public string? StoreTypeName { get; set; } //type name
        //public List<Store> TypeStores { get; set; } 
        //list of stores that match the type 

    }
}
