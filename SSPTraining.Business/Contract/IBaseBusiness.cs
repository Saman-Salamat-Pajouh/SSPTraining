using Sieve.Models;
using SSPTraining.Common.ViewModels;
using SSPTraining.Model.Entities;

namespace SSPTraining.Business.Contract;

public interface IBaseBusiness<T> where T : BaseEntity
{
	Task<SamanSalamatResponse?> CreateAsync(T t, CancellationToken cancellationToken);

	Task<SamanSalamatResponse<List<T>>?> LoadAllAsync(SieveModel sieveModel, CancellationToken cancellationToken);

	Task<SamanSalamatResponse?> UpdateAsync(T t, CancellationToken cancellationToken);

	Task<SamanSalamatResponse?> DeleteAsync(int id, CancellationToken cancellationToken);
}