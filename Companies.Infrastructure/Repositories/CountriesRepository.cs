using System;
using Companies.Application.Abstractions;
using Companies.Domain.Entities;
using Companies.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Companies.Domain.ValueObjects;
using Companies.Application.Abstracctions;

namespace Companies.Infrastructure.Repositories;

public sealed class CountriesRepository(AppDbContext db) : ICountriesRepository
{
    public Task<Countries?> GetByIdAsync(int id, CancellationToken ct = default)
        => db.Countries.AsNoTracking().FirstOrDefaultAsync(c => c.id == id, ct);
    public Task<Countries?> ByNameAsync(string name, CancellationToken ct = default)
        => db.Countries.AsNoTracking().FirstOrDefaultAsync(c => c.name == name, ct);
    public async Task AddAsync(Countries countries, CancellationToken ct = default)
    {
        db.Countries.Add(countries);
        //await db.SaveChangesAsync(ct);
        await Task.CompletedTask;
    }

    public async Task UpdateAsync(Countries countries, CancellationToken ct = default)
    {
        db.Countries.Update(countries);
        //await db.SaveChangesAsync(ct);
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(Countries countries, CancellationToken ct = default)
    {
        db.Countries.Remove(countries);
        //await db.SaveChangesAsync(ct);
        await Task.CompletedTask;
    }

    public Task<bool> ExistsByNameAsync(string name, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Countries?>> GetAllAsync(CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Countries?>> GetByRegionAsync(Regions region, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<int> CountAsync(string? search = null, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    /* public Task<int> CountAsync(string? search = null, CancellationToken ct = default)
     {
         var query = db.Countries.AsNoTracking();
         if (!string.IsNullOrWhiteSpace(search))
         {
             var term = search.Trim().ToUpper();
             query = query.Where(c => c.name.ToUpper().Contains(term) || 
         }

         return query.CountAsync(ct);
     }*/
}
