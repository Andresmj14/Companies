using Companies.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Sockets;

namespace Companies.Domain.Entities
{
    public class Companies
    {
        public int id { get; set; } = Guid.NewGuid().GetHashCode();
        public string name { get; set; } = null!;
        public Ukniu Ukniu { get; set; } = null!;
        public string address { get; set; } = null!;
        public List<Cities> citiesid { get; set; } = new List<Cities>();
        public string email { get; set; } = null!;

        protected Companies() { }

        public Companies(string name, Ukniu ukniu, string address, string email)
        {
            this.name = name;
            Ukniu = ukniu;
            this.address = address;
            this.email = email;
        }

    }

}   

