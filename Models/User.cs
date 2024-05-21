using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetCoreMvcFull.Models
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string username { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public Address address { get; set; } = new Address();
        public string phone { get; set; } = string.Empty;
        public string website { get; set; } = string.Empty;
        public Company company { get; set; } = new Company();
    }
}
