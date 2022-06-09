using Hoorbakht.RedisService.Contracts;
using Sieve.Attributes;

namespace SSPTraining.Model.Entities;

public class Person : BaseEntity
{
	[Sieve(CanFilter = true, CanSort = true)]
	public string? Name { get; set; }

	[Sieve(CanFilter = true, CanSort = true)]
	public string? Family { get; set; }

	public string FullName => Name + " " + Family;

	[CacheableContract]
	public virtual User? User { get; set; }
}