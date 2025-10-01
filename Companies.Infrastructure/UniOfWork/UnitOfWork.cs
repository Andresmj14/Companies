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
    private ICountriesRepository? _countriesRepository;
    private IRegiosnRepository? _regionsRepository;
    private ICitiesRepository? _citiesRepository;
    private ICompaniesRepository? _companiesRepository;
    private IBranchesRepository? _branchesRepository;

    public UnitOfWork(AppDbContext db)
    {
        _context = db;

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
    // private readonly AppDbContext? _context;
    // private IProductRepository? _productRepository;
    // public UnitOfWork(AppDbContext context)
    // {
    //     _context = context;
    // }
    public ICountriesRepository Countries{
        get
        {
            if(_countriesRepository == null)
            {
                _countriesRepository = new CountriesRepository(_context);
            }
            return _countriesRepository;
        }
    }

}