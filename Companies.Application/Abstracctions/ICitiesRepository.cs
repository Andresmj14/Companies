using System;
using Companies.Domain.Entities;
using Companies.Domain.ValueObjects;

namespace Companies.Application.Abstracctions;

public interface ICitiesRepository
{
    Task<Cities?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<Cities?> ByNameAsync(string name, CancellationToken ct = default);
    Task AddAsync(Cities city, CancellationToken ct = default);
    Task UpdateAsync(Cities city, CancellationToken ct = default);
    Task DeleteAsync(Cities city, CancellationToken ct = default);
    Task<bool> ExistsByNameAsync(string name, CancellationToken ct = default);
    Task<IReadOnlyList<Cities?>> GetAllAsync(CancellationToken ct = default);
    Task<IReadOnlyList<Cities?>> GetByCountryAsync(Countries country, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);
}
