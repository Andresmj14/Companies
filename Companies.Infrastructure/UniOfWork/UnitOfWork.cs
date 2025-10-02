using System;
using Companies.Application.Abstracctions;
using Companies.Application.Abstractions;
using Companies.Infrastructure.Persistence;
using Companies.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;


namespace Companies.Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private ICompaniesRepository? _companiesRepository;
    private IBranchesRepository? _branchesRepository;
    private ICitiesRepository? _citiesRepository;
    private IRegionsRepository? _regionsRepository;
    private ICountriesRepository? _countriesRepository;
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }
    public Task<int> SaveChangesAsync(CancellationToken ct = default)
        => _context.SaveChangesAsync(ct);
    public async Task ExecuteInTransactionAsync(Func<CancellationToken, Task> operation, CancellationToken ct = default)
    {
        await using var tx = await _context.Database.BeginTransactionAsync(ct);
        try
        {
            await operation(ct);
            await _context.SaveChangesAsync(ct);
            await tx.CommitAsync(ct);
        }
        catch
        {
            await tx.RollbackAsync(ct);
            throw;
        }
    }
    public IBranchesRepository Branches => _branchesRepository ??= new BranchesRepository(_context);
    public ICompaniesRepository Companies => _companiesRepository ??= new CompaniesRepository(_context);
    public ICitiesRepository Cities => _citiesRepository ??= new CitiesRepository(_context);
    public IRegionsRepository Regions => _regionsRepository ??= new RegionsRepository(_context);
    public ICountriesRepository Countries => _countriesRepository ??= new CountriesRepository(_context);


}

