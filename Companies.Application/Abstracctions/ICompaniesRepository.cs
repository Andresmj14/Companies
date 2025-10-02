using System;
using Companies.Domain.Entities;
using Companies.Domain.ValueObjects;

namespace Companies.Application.Abstracctions;
public interface ICompaniesRepository
{
    Task<Companiess> GetByIdAsync(int id, CancellationToken ct = default);
    Task<IEnumerable<Companiess>> GetAllAsync(CancellationToken ct = default);
    Task<Companiess> GetByNameAsync(string name, CancellationToken ct = default);
    Task<bool> ExistUkniuAsync(Ukniu ukniu, CancellationToken ct = default);
    Task<Companiess> GetByUkniuAsync(Ukniu ukniu, CancellationToken ct = default);
    Task AddAsync(Companiess company, CancellationToken ct = default);
    Task UpdateAsync(Companiess company, CancellationToken ct = default);
    Task DeleteAsync(int id, CancellationToken ct = default);
    Task<int> CountAsync(string? q, CancellationToken ct = default);
}
