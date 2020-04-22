using Xunit;

namespace DotNetUtils.FluentMatch.Tests
{
    public class NullOrEmptyStringMatcherTests
    {
        [Theory]
        [InlineData(null, true)]
        [InlineData("", true)]
        [InlineData("a", false)]
        public void Matches_IsNullOrEmpty(string input, bool expected)
        {
            StringMatcher matcher = StringMatch.IsNullOrEmpty();
            bool result = matcher.Matches(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData("a", true)]
        public void Matches_IsNotNullOrEmpty(string input, bool expected)
        {
            StringMatcher matcher = StringMatch.IsNotNullOrEmpty();
            bool result = matcher.Matches(input);
            Assert.Equal(expected, result);
        }
    }
}
