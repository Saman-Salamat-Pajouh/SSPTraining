namespace SSPTraining.Model;

public class Role : BaseEntity
{
	public string? Title { get; set; }

	public string? Description { get; set; }

	public virtual ICollection<UserRole>? UserRoles { get; set; }
}