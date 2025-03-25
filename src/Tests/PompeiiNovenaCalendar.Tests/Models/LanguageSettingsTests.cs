using PompeiiNovenaCalendar.Domain.Models;
using Shouldly;

namespace PompeiiNovenaCalendar.Shared.Tests.Models
{
    public class LanguageSettingsTests
    {
        [Theory]
        [InlineData("en", "en")]
        [InlineData("pl", "pl")]
        [InlineData("Pl", "pl")]
        [InlineData("PL", "pl")]
        [InlineData("", "en")]
        [InlineData("es", "en")]
        [InlineData("tt", "en")]
        public void WhenAppFetchSystemLanguage_ShouldGenerateValidResult(string fakeSystemLanguage, string expectedResult)
        {
            new LanguageSettings(fakeSystemLanguage).Language.ShouldBe(expectedResult);
        }
    }
}