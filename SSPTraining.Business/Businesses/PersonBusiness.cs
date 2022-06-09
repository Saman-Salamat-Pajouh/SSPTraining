using Hoorbakht.RedisService;
using SSPTraining.Business.Base;
using SSPTraining.DataAccess.Contracts;
using SSPTraining.Model.Entities;

namespace SSPTraining.Business.Businesses;

public class PersonBusiness : BaseBusiness<Person>
{
	public PersonBusiness(IUnitOfWork unitOfWork, IRedisService<List<Person>> redisService) : base(unitOfWork, unitOfWork.PersonRepository!, redisService)
	{
	}
}