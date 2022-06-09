using Hoorbakht.RedisService;
using SSPTraining.Business.Base;
using SSPTraining.DataAccess.Contracts;
using SSPTraining.Model.Entities;

namespace SSPTraining.Business.Businesses;

public class RoleBusiness : BaseBusiness<Role>
{
	public RoleBusiness(IUnitOfWork unitOfWork, IRedisService<List<Role>> redisService) : base(unitOfWork, unitOfWork.RoleRepository!, redisService)
	{
	}
}