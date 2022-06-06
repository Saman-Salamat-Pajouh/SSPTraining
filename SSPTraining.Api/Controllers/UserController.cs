using SSPTraining.Api.Base;
using SSPTraining.Business.Contract;
using SSPTraining.Model;

namespace SSPTraining.Api.Controllers;

public class UserController : BaseController<User>
{
	public UserController(IBaseBusiness<User> business) : base(business)
	{
	}
}