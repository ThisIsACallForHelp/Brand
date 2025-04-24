using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class City : Model //inherit the ID
    {
        public string? CityName { get; set; } //city name
        //public List<Customer>? CustomersFromCity { get; set; }
        //list of customer's from the same city
    }
}
