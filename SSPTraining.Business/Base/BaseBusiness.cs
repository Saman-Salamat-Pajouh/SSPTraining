using Sieve.Models;
using SSPTraining.Business.Contract;
using SSPTraining.Common.ViewModels;
using SSPTraining.DataAccess.Contracts;
using SSPTraining.Model;

namespace SSPTraining.Business.Base;

public class BaseBusiness<T> : IBaseBusiness<T> where T : BaseEntity
{
	private readonly IUnitOfWork _unitOfWork;

	private readonly IBaseRepository<T> _repository;

	public BaseBusiness(IUnitOfWork unitOfWork, IBaseRepository<T> repository)
	{
		_unitOfWork = unitOfWork;
		_repository = repository;
	}

	public async Task<SamanSalamatResponse?> CreateAsync(T t, CancellationToken cancellationToken)
	{
		await _repository.CreateAsync(t, cancellationToken);
		await _unitOfWork.CommitAsync(cancellationToken);
		return new SamanSalamatResponse
		{
			IsSuccess = true,
			ChangedId = t.Id,
			Message = "Entity Saved"
		};
	}

	public async Task<SamanSalamatResponse<List<T>>?> LoadAllAsync(SieveModel model, CancellationToken cancellationToken)
	{
		var data = await _repository.LoadAllAsync(model, null, cancellationToken);
		return new SamanSalamatResponse<List<T>>
		{
			Data = data,
			RecordsTotal = data.Count,
			RecordsFiltered = data.Count,
			Message = "Data Loaded",
			IsSuccess = true
		};
	}

	public async Task<SamanSalamatResponse?> UpdateAsync(T t, CancellationToken cancellationToken)
	{
		await _repository.UpdateAsync(t, cancellationToken);
		await _unitOfWork.CommitAsync(cancellationToken);
		return new SamanSalamatResponse
		{
			IsSuccess = true,
			ChangedId = t.Id,
			Message = "Entity Updated"
		};
	}

	public async Task<SamanSalamatResponse?> DeleteAsync(int id, CancellationToken cancellationToken)
	{
		await _repository.DeleteAsync(id, cancellationToken);
		await _unitOfWork.CommitAsync(cancellationToken);
		return new SamanSalamatResponse
		{
			IsSuccess = true,
			ChangedId = id,
			Message = "Entity Deleted"
		};
	}
}