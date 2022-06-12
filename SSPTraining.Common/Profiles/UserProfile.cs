using AutoMapper;
using AutoMapper.EquivalencyExpression;
using SSPTraining.Common.ViewModels;
using SSPTraining.Model.Entities;

namespace SSPTraining.Common.Profiles;

public class UserProfile : Profile
{
	public UserProfile()
	{
		CreateMap<User, UserViewModel>()
			.EqualityComparison((user, userViewModel) => user.Id == userViewModel.Id)
			.ForMember(destination => destination.PersonFullName,
				option =>
					option.MapFrom(source => source.Person!.FullName))
			.ForMember(destination => destination.Roles,
				option =>
					option.MapFrom(source => source.UserRoles!.Select(x => x.Role!.Title)))
			.ReverseMap();
	}
}