﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLog;
using SSPTraining.Api.Filters;
using SSPTraining.Business.Businesses;
using SSPTraining.Common.Helpers;
using SSPTraining.Common.ViewModels;

namespace SSPTraining.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
	private readonly Logger _logger;

	private readonly AccountBusiness? _accountBusiness;

	public AccountController(Logger logger, AccountBusiness accountBusiness)
	{
		_logger = logger;
		_accountBusiness = accountBusiness;
	}

	[HttpPost]
	[Route("Login")]
	[AllowAnonymous]
	public async Task<bool> Login([FromForm] LoginViewModel login, CancellationToken cancellationToken)
	{
		try
		{
			return await _accountBusiness!.LoginAsync(login, HttpContext, cancellationToken);
		}
		catch (Exception ex)
		{
			_logger.Error(new MongoLog
			{
				ControllerName = nameof(UserController),
				ActionName = nameof(Login),
				Request = login,
				Exception = ex,
				Username = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Username")
					?.Value
			}.LogFullData());
			return false;
		}
	}

	[Authorization]
	[HttpGet]
	[Route("Logout")]
	public async Task<IActionResult> Logout()
	{
		try
		{
			await HttpContext.SignOutAsync();
			return RedirectToPage("/Index");
		}
		catch (Exception ex)
		{
			_logger.Error(new MongoLog
			{
				ControllerName = nameof(UserController),
				ActionName = nameof(Logout),
				Exception = ex,
				Username = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Username")
					?.Value
			}.LogFullData());
			return Ok();
		}
	}
}