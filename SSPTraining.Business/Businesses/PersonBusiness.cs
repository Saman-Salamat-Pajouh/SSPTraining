using SSPTraining.Business.Base;
using SSPTraining.DataAccess.Contracts;
using SSPTraining.Model;

namespace SSPTraining.Business.Businesses;

public class PersonBusiness : BaseBusiness<Person>
{
	public PersonBusiness(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.PersonRepository!)
	{
	}
}