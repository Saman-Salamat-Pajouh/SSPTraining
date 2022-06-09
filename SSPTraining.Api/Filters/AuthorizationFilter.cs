using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace SSPTraining.Api.Filters;

public class AuthorizationFilter : AuthorizeAttribute, IAuthorizationFilter
{
	private readonly string[] _roles;

	public AuthorizationFilter(string[] roles) =>
		_roles = roles;

	public void OnAuthorization(AuthorizationFilterContext context)
	{
		if (context.ActionDescriptor.EndpointMetadata.Any(x => typeof(AllowAnonymousAttribute) == x.GetType()))
			return;
		if (_roles.Length != 0)
		{
			if (context.HttpContext.User.Claims.Any(x =>
				    x.Type == ClaimTypes.Role && _roles.Contains(x.Value)))
				return;
			context.Result = new ForbidResult();
		}
		if (context.HttpContext.User.Claims.Any(x => x.Type == ClaimTypes.Role))
			return;
		if (context.ActionDescriptor.DisplayName?.StartsWith('/') ?? false)
			context.Result = new ForbidResult();
		else
		{
			context.HttpContext.Response.StatusCode = 403;
			context.HttpContext.Response.Body = Stream.Null;
		}
	}
}