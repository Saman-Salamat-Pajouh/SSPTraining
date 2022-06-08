using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using SSPTraining.Api.Contracts;
using SSPTraining.Api.Filters;
using SSPTraining.Business.Contract;
using SSPTraining.Common.ViewModels;
using SSPTraining.Model.Entities;

namespace SSPTraining.Api.Base;

[ApiController]
[Route("api/[controller]")]
[Authorization]
public class BaseController<T> : ControllerBase, IBaseController<T> where T : BaseEntity
{
	private readonly IBaseBusiness<T> _business;

	public BaseController(IBaseBusiness<T> business) =>
		_business = business;

	[HttpGet]
	[HttpHead]
	public async Task<SamanSalamatResponse<List<T>>?> GetAllAsync([FromQuery] SieveModel sieveModel, CancellationToken cancellationToken) =>
		await _business.LoadAllAsync(sieveModel, cancellationToken);

	[HttpPost]
	public async Task<SamanSalamatResponse?> CreateAsync(T t, CancellationToken cancellationToken) =>
		await _business.CreateAsync(t, cancellationToken);

	[HttpPut]
	public async Task<SamanSalamatResponse?> UpdateAsync(T t, CancellationToken cancellationToken) =>
		await _business.UpdateAsync(t, cancellationToken);

	[HttpDelete]
	[Route("{id:int}")]
	public async Task<SamanSalamatResponse?> DeleteAsync(int id, CancellationToken cancellationToken) =>
		await _business.DeleteAsync(id, cancellationToken);

	[HttpOptions]
	public void Options() =>
		Response.Headers.Add("Allow", "POST,PUT,DELETE,GET,HEAD,OPTIONS");
}