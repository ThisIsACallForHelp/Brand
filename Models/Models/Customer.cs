using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class Customer : Model //inherit the ID
    {
        public string? CustomerFirstName { get; set; } 
        //Customer's first name
        public string? CustomerLastName { get; set; } 
        //Customer's last name
        public string? CustomerPhoneNumber { get; set; } 
        //Customer's phone number 
        public string? CustomerEmail { get; set; } 
        //Customer's Email
        public int CityID { get; set; } 
        //The ID of the city the customer lives in
        public string? CustomerPassword {  get; set; } 
        //Customer password
        public string? CustomerIMG { get; set; }
        //Customer's Avatar/Profile Picture 
    }
}
