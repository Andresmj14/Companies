using System;
using Companies.Application.Abstracctions;
using Companies.Domain.Entities;
using Companies.Domain.ValueObjects;
using Companies.Infrastructure.Persistence;

namespace Companies.Infrastructure.Repositories;
public sealed class CompaniesRepository(AppDbContext db) : ICompaniesRepository
{

    public async Task<Companiess> GetByIdAsync(int id, CancellationToken ct = default)
    {
        var company = await db.Companiess.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id, ct);
        if (company == null)
            throw new KeyNotFoundException($"Company with Id '{id}' not found.");
        return company;
    }


    public async Task<Companiess> GetByNameAsync(string name, CancellationToken ct = default)
    {
        var company = await db.Companiess.FirstOrDefaultAsync(c => c.Name == name, ct);
        if (company == null)
            throw new KeyNotFoundException($"Company with Name '{name}' not found.");
        return company;
    }

    public Task<bool> ExistUkniuAsync(Ukniu ukniu, CancellationToken ct = default)
        => db.Companiess.AnyAsync(c => c.Ukniu == ukniu, ct);

    public Task<Companiess> GetByUkniuAsync(Ukniu ukniu, CancellationToken ct = default)
        => db.Companiess.FirstOrDefaultAsync(c => c.Ukniu == ukniu, ct);

    public async Task AddAsync(Companiess company, CancellationToken ct = default)
    {
        await db.Companiess.AddAsync(company, ct);
    }

    public async Task UpdateAsync(Companiess company, CancellationToken ct = default)
    {
        db.Companiess.Update(company);
        await db.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(Companiess company, CancellationToken ct = default)
    {
        db.Companiess.Remove(company);
        await db.SaveChangesAsync(ct);
    }

    public Task<int> CountAsync(string? search = null, CancellationToken ct = default)
    {
        var query = db.Companiess.AsNoTracking();
        if (!string.IsNullOrWhiteSpace(search))
        {
            var term = search.Trim().ToUpper();
            query = query.Where(p =>
                p.Name.ToUpper().Contains(term) ||
                p.Ukniu.Value.ToUpper().Contains(term));
        }
        return query.CountAsync(ct);
    }

    public async Task DeleteAsync(int id, CancellationToken ct = default)
    {
        var company = await db.Companiess.FindAsync([id], ct);
        if (company is not null)
        {
            db.Companiess.Remove(company);
            await Task.CompletedTask;
        }
    }

    public async Task<IEnumerable<Companiess>> GetAllAsync(CancellationToken ct = default)
        => await db.Companiess.AsNoTracking().ToListAsync(ct);
}
