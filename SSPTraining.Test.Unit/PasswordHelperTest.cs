using FluentAssertions;
using SSPTraining.Common.Helpers;

namespace SSPTraining.Test.Unit;

public class PasswordHelperTest
{
	[Theory]
	[MemberData(nameof(PasswordData))]
	public async Task PasswordHelperWorkCorrectly(string plainText, string correctEncryptedText)
	{
		var encryptedText = await plainText.GetHashStringAsync();

		encryptedText.Should().Be(correctEncryptedText);
	}

	public static IEnumerable<object[]> PasswordData() =>
		new List<object[]>
		{
			new object[]
			{
				"admin",
				"c7ad44cbad762a5da0a452f9e854fdc1e0e7a52a38015f23f3eab1d80b931dd472634dfac71cd34ebc35d16ab7fb8a90c81f975113d6c7538dc69dd8de9077ec"
			},
			new object[]
			{
				"amarlu",
				"5dcd58b93f68aea2077c8fdeb74473aa1882ffc7b5a4bf8e73109f92301e93d8502c111388b81bbfeae16dbb740f777ee09cb1fabd88229adb22f8847a181e47"
			}
		};
}