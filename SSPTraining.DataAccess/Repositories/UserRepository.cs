using Microsoft.EntityFrameworkCore;
using Sieve.Services;
using SSPTraining.DataAccess.Base;
using SSPTraining.DataAccess.Context;
using SSPTraining.Model;

namespace SSPTraining.DataAccess.Repositories;

public class UserRepository : BaseRepository<User>
{
	private readonly SspTrainingContext _context;

	public UserRepository(SspTrainingContext context, ISieveProcessor sieveProcessor) : base(context, sieveProcessor) =>
		_context = context;

	public async Task<bool> IsUsernameAndPasswordValidAsync(string username, string password, CancellationToken cancellationToken = new()) =>
		await _context.Users!.AnyAsync(x =>
			x.Username == username && x.Password == password, cancellationToken);

	public async Task<User> LoadByUsernameAsync(string username, CancellationToken cancellationToken = new()) =>
		(await _context.Users!
			.Include(x => x.Person)
			.SingleOrDefaultAsync(x => x.Username == username, cancellationToken))!;

	public async Task<bool> IsUsernameExistAsync(string username, CancellationToken cancellationToken = new()) =>
		await _context.Users!
			.AnyAsync(x => string.Equals(x.Username, username, StringComparison.CurrentCultureIgnoreCase),
				cancellationToken);
}