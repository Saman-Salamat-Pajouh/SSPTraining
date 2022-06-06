using SSPTraining.DataAccess.Repositories;

namespace SSPTraining.DataAccess.Contracts;

public interface IUnitOfWork
{
	UserRoleRepository? UserRoleRepository { get; }

	PersonRepository? PersonRepository { get; }

	RoleRepository? RoleRepository { get; }

	UserRepository? UserRepository { get; }

	int Commit();

	Task<int> CommitAsync(CancellationToken cancellationToken);
}