using SSPTraining.Business.Base;
using SSPTraining.DataAccess.Contracts;
using SSPTraining.Model.Entities;

namespace SSPTraining.Business.Businesses;

public class RoleBusiness : BaseBusiness<Role>
{
	public RoleBusiness(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.RoleRepository!)
	{
	}
}