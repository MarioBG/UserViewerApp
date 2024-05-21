using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetCoreMvcFull.Models
{
    public class Address
    {
        public string street { get; set; } = string.Empty;
        public string suite { get; set; } = string.Empty;
        public string city { get; set; } = string.Empty;
        public string zipcode { get; set; } = string.Empty;
        public Geo geo { get; set; } = new Geo();
    }
}
