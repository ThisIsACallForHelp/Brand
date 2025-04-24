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
        public string? CustomerFirstName { get; set; } //name
        public string? CustomerLastName { get; set; } //last name
        public string? CustomerPhoneNumber { get; set; } //phone num
        public string? CustomerEmail { get; set; } //Email
        public int CityID { get; set; } //Email
        public string? CustomerPassword {  get; set; } //password

        public string? CustomerIMG { get; set; }
    }
}
