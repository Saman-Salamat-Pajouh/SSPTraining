using Sieve.Models;
using SSPTraining.Common.ViewModels;
using SSPTraining.Model.Entities;

namespace SSPTraining.Api.Contracts;

public interface IBaseController<T> where T : BaseEntity
{
	Task<SamanSalamatResponse?> CreateAsync(T t, CancellationToken cancellationToken);

	Task<SamanSalamatResponse<List<T>>?> GetAllAsync(SieveModel sieveModel, CancellationToken cancellationToken);

	Task<SamanSalamatResponse?> UpdateAsync(T t, CancellationToken cancellationToken);

	Task<SamanSalamatResponse?> DeleteAsync(int id, CancellationToken cancellationToken);

	void Options();
}