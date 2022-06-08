using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace SSPTraining.Test.Integration;

public class HealthCheckTests : IClassFixture<WebApplicationFactory<Program>>
{
	private readonly HttpClient _httpClient;

	public HealthCheckTests(WebApplicationFactory<Program> factory) =>
		_httpClient = factory.CreateDefaultClient();

	[Fact]
	public async Task HealthCheckReturnExpectedResponse()
	{
		var response = await _httpClient.GetStringAsync("/HealthCheck");

		response.Should().Be("Healthy");
	}
}