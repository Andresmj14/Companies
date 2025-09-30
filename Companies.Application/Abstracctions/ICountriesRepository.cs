using System;
using Companies.Domain.Entities;
using Companies.Domain.ValueObjects;

namespace Companies.Application.Abstracctions;

public interface ICountriesRepository
{
    Task<Countries> GetVyIdAsync(int id, CancellationToken ct = default);
    Task<Countries> ByNameAsync(string name, CancellationToken ct = default);
    Task AddAsync(Countries country, CancellationToken ct = default);
    Task UpdateAsync(Countries country, CancellationToken ct = default);
    Task DeleteAsync(Countries country, CancellationToken ct = default);
    Task<bool> ExistsByNameAsync(string name, CancellationToken ct = default);
}
