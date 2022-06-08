namespace SSPTraining.Common.Constants;

public class QueryConstant
{
	#region [Views]

	public const string AddUserRolesView = @"Create View UserRolesView
		As
		Select 
			u.Username,
			p.Name + ' ' + p.Family As FullName,
			r.Title As RoleTitle
		From Users u
		Join Persons p On u.PersonId = p.Id
		Join UserRoles ur On ur.UserId = u.Id
		Join Roles r On ur.RoleId = r.Id";

	public const string DeleteUserRolesView = "Drop View UserRolesView";

	#endregion
}