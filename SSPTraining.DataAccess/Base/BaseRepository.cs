using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Sieve.Models;
using Sieve.Services;
using SSPTraining.DataAccess.Context;
using SSPTraining.DataAccess.Contracts;
using SSPTraining.Model.Entities;

namespace SSPTraining.DataAccess.Base;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
	private readonly DbSet<T> _dbSet;

	private readonly ISieveProcessor _processor;

	public BaseRepository(SspTrainingContext context, ISieveProcessor processor)
	{
		_processor = processor;
		_dbSet = context.Set<T>();
	}

	public async Task<T> CreateAsync(T t, CancellationToken cancellationToken = new()) =>
		(await _dbSet.AddAsync(t, cancellationToken)).Entity;

	public async Task<List<T>> LoadAllAsync(SieveModel sieveModel, Func<IQueryable<T>, IIncludableQueryable<T, object?>>? include = null,
		CancellationToken cancellationToken = new())
	{
		var query = _dbSet.AsNoTracking();
		if (include != null)
			query = include(query);
		return await _processor.Apply(sieveModel, query).ToListAsync(cancellationToken);
	}

	public async Task<T> UpdateAsync(T t, CancellationToken cancellationToken = new())
	{
		t.LastUpdated = DateTime.Now;
		return (await Task.FromResult(_dbSet.Update(t))).Entity;
	}

	public async Task<T> DeleteAsync(T t, CancellationToken cancellationToken = new()) =>
		(await Task.FromResult(_dbSet.Remove(t))).Entity;

	public async Task<T> DeleteAsync(int id, CancellationToken cancellationToken = new())
	{
		var record = await _dbSet.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
		if (record != null)
			return await DeleteAsync(record, cancellationToken);
		return Activator.CreateInstance<T>();
	}
}