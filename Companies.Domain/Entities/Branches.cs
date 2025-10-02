using Companies.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace Companies.Domain.Entities;

public class Branches
{
    public int Id { get; set; }
    public int Number_Comercial { get; set; } = 0;
    public string Address { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Contact_Name { get; set; } = null!;

    public int CityId { get; set; }
    public virtual Cities? City { get; set; }
    public int CompanyId { get; set; }
    public virtual Companiess? Company { get; set; }

    public Branches() { }
    public Branches(int numberComercial, string address, string email, string contactName, int cityId, int companyId)
    {
        Number_Comercial = numberComercial;
        Address = address;
        Email = email;
        Contact_Name = contactName;
        CityId = cityId;
        CompanyId = companyId;
    }
}
