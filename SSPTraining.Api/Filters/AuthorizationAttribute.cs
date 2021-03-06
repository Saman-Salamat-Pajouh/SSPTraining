using Microsoft.AspNetCore.Mvc;

namespace SSPTraining.Api.Filters;

public class AuthorizationAttribute : TypeFilterAttribute
{
	public AuthorizationAttribute(params string[] roles) : base(typeof(AuthorizationFilter)) =>
		Arguments = new object[] { roles };
}