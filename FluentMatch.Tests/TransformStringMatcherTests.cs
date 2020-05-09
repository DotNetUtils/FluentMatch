using Xunit;

namespace DotNetUtils.FluentMatch.Tests
{
    public sealed class TransformStringMatcherTests
    {
        [Theory]
        [InlineData("abc", true)]
        [InlineData(" abc ", true)]
        [InlineData("a b c", false)]
        public void Matches_TrimTransform(string input, bool expected)
        {
            StringMatcher matcher = StringMatch.Equals("abc").WithTransform(n => n.Trim());
            bool result = matcher.Matches(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("abc", true)]
        [InlineData("abcdefg", true)]
        [InlineData("xyz", false)]
        public void Matches_TruncateTransform(string input, bool expected)
        {
            StringMatcher matcher = StringMatch.Equals("abc").WithTransform(n => n.Substring(0, 3));
            bool result = matcher.Matches(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("abc", false)]
        [InlineData("0abc", true)]
        public void Matches_SkipFirstTransform(string input, bool expected)
        {
            StringMatcher matcher = StringMatch.Equals("abc").WithTransform(n => n.Substring(1));
            bool result = matcher.Matches(input);
            Assert.Equal(expected, result);
        }
    }
}
