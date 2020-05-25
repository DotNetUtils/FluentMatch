using Xunit;

namespace FluentMatch.Tests
{
    public sealed class PredicateStringMatcherTests
    {
        [Theory]
        [InlineData("123", true)]
        [InlineData("yes", true)]
        [InlineData("no", false)]
        public void Matches_LengthPredicate(string input, bool expected)
        {
            StringMatcher matcher = StringMatch.Where(n => n.Length == 3);
            bool result = matcher.Matches(input);
            Assert.Equal(expected, result);
        }
    }
}
