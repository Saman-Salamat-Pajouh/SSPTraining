using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSPTraining.Model;

public class BaseEntity
{
	public BaseEntity() =>
		CreationDate = LastUpdated = DateTime.Now;

	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }

	public DateTime CreationDate { get; set; }

	public DateTime LastUpdated { get; set; }
}