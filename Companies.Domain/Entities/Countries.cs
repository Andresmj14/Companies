using System;
using Companies.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace Companies.Domain.Entities;

public class Countries
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<Regions> Regions { get; set; } = new List<Regions>();

    public Countries() { }
    public Countries(string name)
    {
        Name = name;
    }
}
