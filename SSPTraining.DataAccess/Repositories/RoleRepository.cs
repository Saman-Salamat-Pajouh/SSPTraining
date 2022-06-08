using Microsoft.EntityFrameworkCore;
using Sieve.Services;
using SSPTraining.DataAccess.Base;
using SSPTraining.DataAccess.Context;
using SSPTraining.Model.Entities;

namespace SSPTraining.DataAccess.Repositories;

public class RoleRepository : BaseRepository<Role>
{
	private readonly SspTrainingContext _context;

	public RoleRepository(SspTrainingContext context, ISieveProcessor sieveProcessor) : base(context, sieveProcessor) =>
		_context = context;

	public async Task<List<Role?>> LoadByUserIdAsync(int userId, CancellationToken cancellationToken = new()) =>
		await _context.UserRoles!
			.Where(x => x.UserId == userId)
			.Include(x => x.Role)
			.Select(x => x.Role)
			.ToListAsync(cancellationToken);
}