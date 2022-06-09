using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using SSPTraining.Common.Helpers;
using SSPTraining.Common.ViewModels;
using SSPTraining.DataAccess.Contracts;
using SSPTraining.Model.Entities;
using System.Security.Claims;

namespace SSPTraining.Business.Businesses;

public class AccountBusiness
{
	private readonly IUnitOfWork _unitOfWork;

	public AccountBusiness(IUnitOfWork unitOfWork) =>
		_unitOfWork = unitOfWork;

	public async Task<bool> IsUsernameAndPasswordValidAsync(LoginViewModel loginViewModel, CancellationToken cancellationToken = new()) =>
		await _unitOfWork.UserRepository!.IsUsernameAndPasswordValidAsync(loginViewModel.Username!,
			await loginViewModel.Password!.GetHashStringAsync(), cancellationToken);

	public async Task<User> LoadByUsernameAsync(string username, CancellationToken cancellationToken = new()) =>
		await _unitOfWork.UserRepository!.LoadByUsernameAsync(username, cancellationToken);

	public async Task<bool> IsUsernameExistAsync(string username,
		CancellationToken cancellationToken = new()) =>
		await _unitOfWork.UserRepository!.IsUsernameExistAsync(username, cancellationToken);

	public async Task<bool> LoginAsync(LoginViewModel login, HttpContext context, CancellationToken cancellationToken = new())
	{
		var isValid = await IsUsernameAndPasswordValidAsync(login, cancellationToken);

		if (!isValid) return false;
		var user = await LoadByUsernameAsync(login.Username!, cancellationToken);

		var claims = new List<Claim>
			{
				new(ClaimTypes.NameIdentifier, user.Id.ToString()),
				new("FullName", user.Person!.FullName),
				new("Username", user.Username!)
			};

		var roles = await _unitOfWork.RoleRepository!.LoadByUserIdAsync(user.Id, cancellationToken);

		claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role!.Title!)));

		var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
		var principal = new ClaimsPrincipal(identity);

		var properties = new AuthenticationProperties
		{
			IsPersistent = login.RememberMe
		};

		await context.SignInAsync(principal, properties);

		return true;
	}
}