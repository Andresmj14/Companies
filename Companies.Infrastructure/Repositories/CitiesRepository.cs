using System;
using System;
using Companies.Application.Abstractions;
using Companies.Domain.Entities;
using Companies.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Companies.Domain.ValueObjects;
using Companies.Application.Abstracctions;

namespace Companies.Infrastructure.Repositories;

public class CitiesRepository(AppDbContext db) : ICitiesRepository
{
    public Task<Cities?> GetByIdAsync(int id, CancellationToken ct = default)
            => db.Cities.AsNoTracking().FirstOrDefaultAsync(c => c.id == id, ct);
        public Task<Cities?> ByNameAsync(string name, CancellationToken ct = default)
            => db.Cities.AsNoTracking().FirstOrDefaultAsync(c => c.name == name, ct);
        public async Task AddAsync(Cities cities, CancellationToken ct = default)
        {
            db.Cities.Add(cities);
            //await db.SaveChangesAsync(ct);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Cities cities, CancellationToken ct = default)
        {
            db.Cities.Update(cities);
            //await db.SaveChangesAsync(ct);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Cities cities, CancellationToken ct = default)
        {
            db.Cities.Remove(cities);
            //await db.SaveChangesAsync(ct);
            await Task.CompletedTask;
        }

        public Task<bool> ExistsByNameAsync(string name, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Cities?>> GetAllAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
        public Task<IReadOnlyList<Cities?>> GetByCountryAsync(Countries country, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(string? search = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
