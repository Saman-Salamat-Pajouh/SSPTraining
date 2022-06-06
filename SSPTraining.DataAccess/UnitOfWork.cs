using Sieve.Services;
using SSPTraining.DataAccess.Context;
using SSPTraining.DataAccess.Contracts;
using SSPTraining.DataAccess.Repositories;

namespace SSPTraining.DataAccess;

public class UnitOfWork : IUnitOfWork
{
	private PersonRepository? _personRepository;

	private RoleRepository? _roleRepository;

	private UserRepository? _userRepository;

	private UserRoleRepository? _userRoleRepository;

	private readonly SspTrainingContext _trainingContext;

	private readonly ISieveProcessor _sieveProcessor;

	public UnitOfWork(SspTrainingContext context, ISieveProcessor sieveProcessor)
	{
		_trainingContext = context;
		_sieveProcessor = sieveProcessor;
	}

	public PersonRepository PersonRepository =>
		_personRepository ??= new PersonRepository(_trainingContext, _sieveProcessor);

	public RoleRepository RoleRepository =>
		_roleRepository ??= new RoleRepository(_trainingContext, _sieveProcessor);

	public UserRepository UserRepository =>
		_userRepository ??= new UserRepository(_trainingContext, _sieveProcessor);

	public UserRoleRepository UserRoleRepository =>
		_userRoleRepository ??= new UserRoleRepository(_trainingContext, _sieveProcessor);

	public int Commit() =>
		_trainingContext.SaveChanges();

	public async Task<int> CommitAsync(CancellationToken cancellationToken) =>
		await _trainingContext.SaveChangesAsync(cancellationToken);
}