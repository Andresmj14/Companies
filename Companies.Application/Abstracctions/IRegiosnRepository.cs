using System;
using Companies.Domain.Entities;
using Companies.Domain.ValueObjects;

namespace Companies.Application.Abstracctions;

public interface IRegiosnRepository
{
    Task<Regions> GetByIdAsync(int id, CancellationToken ct = default);
    Task<Regions> ByNameAsync(string name, CancellationToken ct = default);
    Task AddAsync(Regions region, CancellationToken ct = default);
    Task UpdateAsync(Regions region, CancellationToken ct = default);
    Task DeleteAsync(Regions region, CancellationToken ct = default);
    Task<bool> ExistsByNameAsync(string name, CancellationToken ct = default);
    Task<IReadOnlyList<Regions>> GetAllAsync(CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);
}
