using Companies.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Sockets;

namespace Companies.Domain.Entities
{
    public class Companie
    {
        public int id { get; set; } = Guid.NewGuid().GetHashCode();
        public string name { get; set; } = null!;
        public Ukniu Ukniu { get; set; } = null!;
        public string address { get; set; } = null!;
        public int Citiesid {get; set; }
        public Cities Cities { get; set; } = null!;
        public string email { get; set; } = null!;

        protected Companie() { }

        public Companie(string name, Ukniu ukniu, string address, string email)
        {
            this.name = name;
            Ukniu = ukniu;
            this.address = address;
            this.email = email;
        }

    }

}   

