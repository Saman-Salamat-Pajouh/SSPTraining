using Microsoft.AspNetCore.Mvc.RazorPages;
using SSPTraining.Api.Filters;

namespace SSPTraining.Web.Pages.Persons;

[Authorization("Admin")]
public class IndexModel : PageModel
{
	public void OnGet()
	{
	}
}