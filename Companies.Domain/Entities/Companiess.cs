using Companies.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Sockets;

namespace Companies.Domain.Entities;

public class Companiess
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public Ukniu Ukniu { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string Email { get; set; } = null!;

    public int CityId { get; set; }
    public virtual Cities? City { get; set; }

    public ICollection<Branches> Branches { get; set; } = new List<Branches>();

    public Companiess() { }
    public Companiess(string name, Ukniu ukniu, string address, string email, int cityId)
    {
        Name = name;
        Ukniu = ukniu;
        Address = address;
        Email = email;
        CityId = cityId;
    }
}
