using Hoorbakht.RedisService.Contracts;
using Sieve.Attributes;

namespace SSPTraining.Model.Entities;

public class Role : BaseEntity
{
	[Sieve(CanFilter = true, CanSort = true)]
	public string? Title { get; set; }

	[Sieve(CanSort = true, CanFilter = true)]
	public string? Description { get; set; }

	[CacheableContract]
	public virtual ICollection<UserRole>? UserRoles { get; set; }
}