using Companies.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace Companies.Domain.Entities
{
    public class Branches
    {
        public int id { get; set; } = Guid.NewGuid().GetHashCode();
        public string number_comercial { get; set; } = null!;
        public string address { get; set; } = null!;
        public string email { get; set; } = null!;
        public string contact_name { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public int Citiesid {get; set; }
        public Cities Cities { get; set; } = null!;
        protected Branches() { }

        public Branches(string number_comercial, string address, string email, string contact_name, string phone)
        {
            this.number_comercial = number_comercial;
            this.address = address;
            this.email = email;
            this.contact_name = contact_name;
            Phone = phone;
        }
        public void UpdateBranch(string newNumberComercial, string newAddress, string newEmail, string newContactName, string newPhone)
        {
            number_comercial = newNumberComercial;
            address = newAddress;
            email = newEmail;
            contact_name = newContactName;
            Phone = newPhone;
        }
     }
    



}

