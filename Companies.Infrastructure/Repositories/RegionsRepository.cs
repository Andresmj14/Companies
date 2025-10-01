using System;
using Companies.Application.Abstractions;
using Companies.Domain.Entities;
using Companies.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Companies.Domain.ValueObjects;
using Companies.Application.Abstracctions;

namespace Companies.Infrastructure.Repositories;

public sealed class RegionsRepository(AppDbContext db) : IRegiosnRepository
{
    public Task<Regions?> GetByIdAsync(int id, CancellationToken ct = default)
        => db.Regions.AsNoTracking().FirstOrDefaultAsync(r => r.id == id, ct);
    public Task<Regions?> ByNameAsync(string name, CancellationToken ct = default)
        => db.Regions.AsNoTracking().FirstOrDefaultAsync(c => c.name == name, ct);
    public async Task AddAsync(Regions regions, CancellationToken ct = default)
    {
        db.Regions.Add(regions);
        //await db.SaveChangesAsync(ct);
        await Task.CompletedTask;
    }

    public async Task UpdateAsync(Regions regions, CancellationToken ct = default)
    {
        db.Regions.Update(regions);
        //await db.SaveChangesAsync(ct);
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(Regions regions, CancellationToken ct = default)
    {
        db.Regions.Remove(regions);
        //await db.SaveChangesAsync(ct);
        await Task.CompletedTask;
    }

    public Task<bool> ExistsByNameAsync(string name, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Regions?>> GetAllAsync(CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }


    public Task<int> CountAsync(string? search = null, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
}