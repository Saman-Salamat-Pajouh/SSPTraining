using FluentValidation;
using SSPTraining.Model;

namespace SSPTraining.Common.Validations;

public class PersonValidator : AbstractValidator<Person>
{
	public PersonValidator()
	{
		RuleFor(x => x.Name).NotEmpty().MaximumLength(20);
		RuleFor(x => x.Family).NotEmpty().MaximumLength(20);
	}
}