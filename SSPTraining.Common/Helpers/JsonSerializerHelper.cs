using System.Text.Json;
using System.Text.Json.Serialization;

namespace SSPTraining.Common.Helpers;

public class JsonSerializerHelper
{
	public static JsonSerializerOptions DefaultSerializerOptions => new()
	{
		DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
	};

	public static JsonSerializerOptions DefaultDeserializerOptions => new()
	{
		PropertyNameCaseInsensitive = true
	};
}