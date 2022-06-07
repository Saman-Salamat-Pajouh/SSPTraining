using FluentValidation;
using SSPTraining.Common.ViewModels;

namespace SSPTraining.Common.Validations
{
	public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
	{
		public LoginViewModelValidator()
		{
			RuleFor(x => x.Username).NotEmpty().MaximumLength(20).MinimumLength(8);
			RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
		}
	}
}
