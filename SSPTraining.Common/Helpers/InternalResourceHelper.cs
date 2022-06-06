using Newtonsoft.Json;
using SSPTraining.Common.ViewModels;

namespace SSPTraining.Common.Helpers;

public static class InternalResourceHelper
{
	#region [Method]

	public static string LoadAllResources() =>
		JsonConvert.SerializeObject(typeof(Messages)
				.GetProperties()
				.Select(x => new ResourceViewModel(x.Name, x.GetValue(new Messages())?.ToString()!)).ToList())
			.ToString();

	#endregion
}