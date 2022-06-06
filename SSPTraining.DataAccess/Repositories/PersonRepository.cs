using Sieve.Services;
using SSPTraining.DataAccess.Base;
using SSPTraining.DataAccess.Context;
using SSPTraining.Model;

namespace SSPTraining.DataAccess.Repositories;

public class PersonRepository : BaseRepository<Person>
{
	public PersonRepository(SspTrainingContext context, ISieveProcessor sieveProcessor) : base(context, sieveProcessor)
	{
	}
}