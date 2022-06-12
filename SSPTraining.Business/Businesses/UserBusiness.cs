using SSPTraining.Business.Base;
using SSPTraining.DataAccess.Contracts;
using SSPTraining.Model.Entities;

namespace SSPTraining.Business.Businesses;

public class UserBusiness : BaseBusiness<User>
{
	public UserBusiness(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.UserRepository!)
	{
	}
}