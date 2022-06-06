using Microsoft.EntityFrameworkCore.Query;
using Sieve.Models;
using SSPTraining.Model;

namespace SSPTraining.DataAccess.Contracts;

public interface IBaseRepository<T> where T : BaseEntity
{
	Task<T> CreateAsync(T t, CancellationToken cancellationToken);

	Task<List<T>> LoadAllAsync(SieveModel sieveModel, Func<IQueryable<T>, IIncludableQueryable<T, object?>>? include = null, CancellationToken cancellationToken = new());

	Task<T> UpdateAsync(T t, CancellationToken cancellationToken);

	Task<T> DeleteAsync(T t, CancellationToken cancellationToken);

	Task<T> DeleteAsync(int id, CancellationToken cancellationToken);
}