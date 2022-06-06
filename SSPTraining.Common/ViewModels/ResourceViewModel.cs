namespace SSPTraining.Common.ViewModels;

public class ResourceViewModel
{
	public ResourceViewModel(string name, string value)
	{
		Name = name;
		Value = value;
	}

	public string Name { get; set; }

	public string Value { get; set; }
}