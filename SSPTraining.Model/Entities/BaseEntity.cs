using Sieve.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSPTraining.Model.Entities;

public class BaseEntity
{
	public BaseEntity() =>
		CreationDate = LastUpdated = DateTime.Now;

	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Sieve(CanFilter = true, CanSort = true)]
	public int Id { get; set; }

	public DateTime CreationDate { get; set; }

	public DateTime LastUpdated { get; set; }
}