using System;
using Companies.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace Companies.Domain.Entities
{
    public class Countries
    {
        public int id { get; set; } = Guid.NewGuid().GetHashCode();
        public string name { get; set; } = null!;
        public ICollection<Regions> Regions { get; set; } = new List<Regions>();


        protected Countries() { }
        public Countries(string name)
        {
            this.name = name;
        }
        public void UpdateCountry(int newId, string newName)
        {
            id = newId;
            name = newName;
        }
    }
}


