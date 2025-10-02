using System;
using Companies.Application.Abstractions;

namespace Companies.Application.Abstractions;

public interface IUnitOfWork
{
    IBranchesRepository Branches { get; }
    ICompaniesRepository Companies { get; }
    ICitiesRepository Cities { get; }
    IRegionsRepository Regions { get; }
    ICountriesRepository Countries { get; }
    Task<int> SaveChangesAsync(CancellationToken ct = default);
    Task ExecuteInTransactionAsync(Func<CancellationToken, Task> operation, CancellationToken ct = default);
}
