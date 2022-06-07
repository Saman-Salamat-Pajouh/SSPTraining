using Sieve.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSPTraining.Model;

public class UserRole : BaseEntity
{
	[Sieve(CanFilter = true, CanSort = true)]
	public int UserId { get; set; }

	[ForeignKey("UserId")]
	public User? User { get; set; }

	[Sieve(CanFilter = true, CanSort = true)]
	public int RoleId { get; set; }

	[ForeignKey("RoleId")]
	public Role? Role { get; set; }
}