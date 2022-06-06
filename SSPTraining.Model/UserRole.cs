using System.ComponentModel.DataAnnotations.Schema;

namespace SSPTraining.Model;

public class UserRole : BaseEntity
{
	public int UserId { get; set; }

	[ForeignKey("UserId")]
	public User? User { get; set; }

	public int RoleId { get; set; }

	[ForeignKey("RoleId")]
	public Role? Role { get; set; }
}