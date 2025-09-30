using Companies.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Headers;


namespace Companies.Domain.Entities
{
    public class Regions
    {
        public int id { get; set; } = Guid.NewGuid().GetHashCode();
        public string name { get; set; } = null!;
        public int Countriesid {get; set; }
        public Countries Countries { get; set; } = null!;
        public List<Cities> citiesid { get; set; } = new List<Cities>();
        protected Regions() { }
        public Regions(string name)
        {
            this.name = name;
        }
        public void UpdateName(string newName)
        {
            name = newName;
        }
    }
}