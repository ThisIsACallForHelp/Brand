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
        //Store Owner's first name
        public string? StoreOwnerLastName {  get; set; }
        //Store Owner's last name
        public string? StoreOwnerPhoneNumber { get; set; }
        //Store Owner's Phone number 
        public string? StoreOwnerEmail { get; set; }
        //Store Owner's Email
        public int StoreID  { get; set; }
        //The ID of the store which the owner controls 
        public string? StoreOwnerIMG { get; set; }
        //Profile picture/Avatar 
    }
}
