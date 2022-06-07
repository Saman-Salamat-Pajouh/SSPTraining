using Sieve.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSPTraining.Model;

public class User : BaseEntity
{
	[Sieve(CanFilter = true,CanSort = true)]
	public string? Username { get; set; }

	public string? Password { get; set; }

	[Sieve(CanSort = true,CanFilter = true)]
	public Person? Person { get; set; }

	[ForeignKey("Person")]
	public int PersonId { get; set; }

	public virtual ICollection<UserRole>? UserRoles { get; set; }
}