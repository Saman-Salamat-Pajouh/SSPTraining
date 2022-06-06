using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SSPTraining.Web.Pages.Account;

[AllowAnonymous]
public class LoginModel : PageModel
{
	public void OnGet()
	{
	}
}