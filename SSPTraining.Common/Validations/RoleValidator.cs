using FluentValidation;
using SSPTraining.Model;

namespace SSPTraining.Common.Validations;

public class RoleValidator : AbstractValidator<Role>
{
	public RoleValidator() =>
		RuleFor(x => x.Title).NotEmpty();
}