using Companies.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace Companies.Domain.Entities
{

    public class Cities
    {
        public int id { get; set; } = Guid.NewGuid().GetHashCode();
        public string name { get; set; } = null!;
        public int Regionsid {get; set; }
        public Regions Regions { get; set; } = null!;
        public List<Companie> companiesid { get; set; } = new List<Companie>();
        public List<Branches> branchesid { get; set; } = new List<Branches>();


        protected Cities() { }
        public Cities(string Name)
        {
            this.name = Name;
        }
        public void UpdateName(string newName)
        {
            name = newName;
        }
    }
    



}
