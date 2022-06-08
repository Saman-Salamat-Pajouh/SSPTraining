using Sieve.Services;
using SSPTraining.DataAccess.Base;
using SSPTraining.DataAccess.Context;
using SSPTraining.Model.Entities;

namespace SSPTraining.DataAccess.Repositories;

public class UserRoleRepository : BaseRepository<UserRole>
{
	public UserRoleRepository(SspTrainingContext context, ISieveProcessor sieveProcessor) : base(context, sieveProcessor)
	{
	}
}