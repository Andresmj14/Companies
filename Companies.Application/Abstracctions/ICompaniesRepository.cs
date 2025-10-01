using System;
using Companies.Domain.Entities;
using Companies.Domain.ValueObjects;

namespace Companies.Application.Abstracctions;

public interface ICompaniesRepository
{
    Task<Companie> GetByIdAsync(int id, CancellationToken ct = default);
    Task<Companie> ByNameAsync(string name, CancellationToken ct = default);
    Task<Companie> GetByUkniuAsync(Ukniu ukniu, CancellationToken ct = default);
    Task<Companie> GetByAddressAsync(string address, CancellationToken ct = default);
    Task<Companie> GetByEmailAsync(string email, CancellationToken ct = default);
    Task AddAsync(Companie company, CancellationToken ct = default);
    Task UpdateAsync(Companie company, CancellationToken ct = default);
    Task DeleteAsync(Companie company, CancellationToken ct = default);
    Task<bool> ExistsByNameAsync(string name, CancellationToken ct = default);
    Task<IReadOnlyList<Companie>> GetAllAsync(CancellationToken ct = default);
    Task<IReadOnlyList<Companie>> GetByCityAsync(Cities city, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);
}
