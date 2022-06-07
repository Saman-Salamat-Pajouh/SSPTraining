using System.ComponentModel.DataAnnotations;

namespace SSPTraining.Common.ViewModels;

public class LoginViewModel
{
	[Display(Name = "نام کاربری")]
	[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
	public string? Username { get; set; }

	[Display(Name = "کلمه عبور")]
	[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
	public string? Password { get; set; }

	[Display(Name = "مرا به خاطر بسپار")]
	public bool RememberMe { get; set; }
}