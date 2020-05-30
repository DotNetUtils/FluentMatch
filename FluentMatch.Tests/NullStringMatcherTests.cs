using Xunit;

namespace FluentMatch.Tests
{
    public class NullStringMatcherTests
    {
        [Theory]
        [InlineData(null, true)]
        [InlineData("", false)]
        [InlineData("a", false)]
        public void Matches_IsNull(string input, bool expected)
        {
            StringMatcher matcher = StringMatch.IsNull();
            bool result = matcher.Matches(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData("", true)]
        [InlineData("a", true)]
        public void Matches_IsNotNull(string input, bool expected)
        {
            StringMatcher matcher = StringMatch.IsNotNull();
            bool result = matcher.Matches(input);
            Assert.Equal(expected, result);
        }
    }
}
