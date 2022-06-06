using System.ComponentModel.DataAnnotations.Schema;

namespace SSPTraining.Model;

public class User : BaseEntity
{
	public string? Username { get; set; }

	public string? Password { get; set; }

	public Person? Person { get; set; }

	[ForeignKey("Person")]
	public int PersonId { get; set; }

	public virtual ICollection<UserRole>? UserRoles { get; set; }
}