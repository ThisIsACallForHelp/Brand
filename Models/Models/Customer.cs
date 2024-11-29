using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Customer : Model
    {
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerStreet { get; set; }
        public string CustomerPassword { get; set; }
        public Cart Cart { get; set; }



    }
}

