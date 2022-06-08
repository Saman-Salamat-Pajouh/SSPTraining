﻿using SSPTraining.Api.Base;
using SSPTraining.Business.Contract;
using SSPTraining.Model.Entities;

namespace SSPTraining.Api.Controllers;

public class PersonController : BaseController<Person>
{
	public PersonController(IBaseBusiness<Person> business) : base(business)
	{
	}
}