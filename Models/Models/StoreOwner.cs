using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class StoreOwner : Model
    {
        public string? StoreOwnerName { get; set; }
        public string? StoreOwnerLastName {  get; set; }
        public string? StoreOwnerPhoneNumber { get; set; }
        public string? StoreOwnerEmail { get; set; }
        public int StoreID  { get; set; }
        public string? StoreOwnerIMG { get; set; }
    }
}
