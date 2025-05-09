using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Brand : Model //inherit the ID
    {
        public string? BrandName { get; set; } //name
        public string? BrandIMG {  get; set; } //image 

    }
}
