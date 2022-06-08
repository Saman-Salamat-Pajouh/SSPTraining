﻿using SSPTraining.Api.Base;
using SSPTraining.Business.Contract;
using SSPTraining.Model.Entities;

namespace SSPTraining.Api.Controllers;

public class RoleController : BaseController<Role>
{
	public RoleController(IBaseBusiness<Role> business) : base(business)
	{
	}
}