using Hoorbakht.RedisService.Contracts;
using Sieve.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSPTraining.Model.Entities;

public class User : BaseEntity
{
	[Sieve(CanFilter = true, CanSort = true)]
	public string? Username { get; set; }

	public string? Password { get; set; }

	[Sieve(CanSort = true, CanFilter = true)]
	public Person? Person { get; set; }

	[ForeignKey("Person")]
	public int PersonId { get; set; }

	[CacheableContract]
	public virtual ICollection<UserRole>? UserRoles { get; set; }
}