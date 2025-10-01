using System;
using Companies.Domain.Entities;
using Companies.Domain.ValueObjects;


namespace Companies.Application.Abstracctions;

public interface IBranchesRepository
{
    Task<Branches> GetByIdAsync(int id, CancellationToken ct = default);
    Task<Branches> ByNameAsync(string name, CancellationToken ct = default);
    Task<Branches> GetByAddressAsync(string address, CancellationToken ct = default);
    Task<Branches> GetByEmailAsync(string email, CancellationToken ct = default);
    Task<Branches> GetByPhoneAsync(string phone, CancellationToken ct = default);
    Task<Branches> GetBYContact_nameAsync(string contact_name, CancellationToken ct = default);
    Task AddAsync(Branches branch, CancellationToken ct = default);
    Task UpdateAsync(Branches branch, CancellationToken ct = default);
    Task DeleteAsync(Branches branch, CancellationToken ct = default);
    Task<bool> ExistsByNameAsync(string name, CancellationToken ct = default);
    Task<IReadOnlyList<Branches>> GetAllAsync(CancellationToken ct = default);
    Task<IReadOnlyList<Branches>> GetByCompanyAsync(Companie company, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);
}
