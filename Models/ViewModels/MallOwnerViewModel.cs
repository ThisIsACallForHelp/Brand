using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class MallOwnerViewModel
    {
        
        public List<Brand>? Brand { get; set; }
        public List<Store>? Store { get; set; }
        public List<Customer>? Customer { get; set; } 
        public List<StoreOwner>? storeOwners { get; set; }
        public int choice { get; set; }
    }
}
