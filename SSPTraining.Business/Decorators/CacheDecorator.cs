using Hoorbakht.RedisService;
using Sieve.Models;
using SSPTraining.Business.Contract;
using SSPTraining.Common.ViewModels;
using SSPTraining.Model.Entities;

namespace SSPTraining.Business.Decorators;

public class CacheDecorator<T> : IBaseBusiness<T> where T : BaseEntity
{
	private readonly IBaseBusiness<T> _baseBusiness;

	private readonly IRedisService<T> _redisService;

	public CacheDecorator(IBaseBusiness<T> baseBusiness, IRedisService<T> redisService)
	{
		_baseBusiness = baseBusiness;
		_redisService = redisService;
	}

	public async Task<SamanSalamatResponse?> CreateAsync(T t, CancellationToken cancellationToken)
	{
		var response = await _baseBusiness.CreateAsync(t, cancellationToken);

		if (response?.IsSuccess ?? false)
			await _redisService.SetHashAsync(t.Id.ToString(), t);

		return response;
	}

	public async Task<SamanSalamatResponse<List<T>>?> LoadAllAsync(SieveModel sieveModel, CancellationToken cancellationToken)
	{
		//var cacheData = await _redisService.GetHashAsync("All");

		//if (cacheData != null)
		//	return new SamanSalamatResponse<List<T>>
		//	{
		//		Data = new List<T> { cacheData },
		//		IsSuccess = true,
		//		RecordsTotal = 1,
		//		RecordsFiltered = 1,
		//		Message = "Data Loaded from Cache",
		//		Result = 1
		//	};

		var response = await _baseBusiness.LoadAllAsync(sieveModel, cancellationToken);

		if (response is not { IsSuccess: true } || response.Data == null) return response;

		foreach (var item in response.Data)
			await _redisService.SetHashAsync(item.Id.ToString(), item);

		return response;
	}

	public async Task<SamanSalamatResponse?> UpdateAsync(T t, CancellationToken cancellationToken)
	{
		var response = await _baseBusiness.UpdateAsync(t, cancellationToken);

		if (!response?.IsSuccess ?? false) return response;

		await _redisService.DeleteAsync(t.Id.ToString());
		await _redisService.SetHashAsync(t.Id.ToString(), t);

		return response;
	}

	public async Task<SamanSalamatResponse?> DeleteAsync(int id, CancellationToken cancellationToken)
	{
		var response = await _baseBusiness.DeleteAsync(id, cancellationToken);

		if (response?.IsSuccess ?? false)
			await _redisService.DeleteAsync(id.ToString());

		return response;
	}
}