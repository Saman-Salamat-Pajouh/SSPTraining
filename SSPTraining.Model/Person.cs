namespace SSPTraining.Model;

public class Person : BaseEntity
{
	public string? Name { get; set; }

	public string? Family { get; set; }

	public string FullName => Name + " " + Family;

	public virtual User? User { get; set; }
}