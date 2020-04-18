using System.Text.RegularExpressions;
using Xunit;

namespace DotNetUtils.FluentMatch.Tests
{
    public sealed class RegexMatcherTests
    {
        private const string _pattern = @"^[A-Z]{3} \d{3}$";
        private const string _exactMatch = "ABC 123";
        private const string _mixedCaseMatch = "aBc 123";
        private const string _whitespaceMatch = "ABC123";
        private const string _whitespaceMixedCaseMatch = "aBc123";
        private const string _noMatch = "12345";

        [Theory]
        [InlineData(_exactMatch, true)]
        [InlineData(_mixedCaseMatch, false)]
        [InlineData(_whitespaceMatch, false)]
        [InlineData(_whitespaceMixedCaseMatch, false)]
        [InlineData(_noMatch, false)]
        public void Matches_Default(string input, bool expected)
        {
            StringMatcher matcher = StringMatch.Regex(_pattern);
            bool result = matcher.Matches(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(_exactMatch, true)]
        [InlineData(_mixedCaseMatch, true)]
        [InlineData(_whitespaceMatch, false)]
        [InlineData(_whitespaceMixedCaseMatch, false)]
        [InlineData(_noMatch, false)]
        public void Matches_IgnoreCase(string input, bool expected)
        {
            StringMatcher matcher = StringMatch.Regex(_pattern, RegexOptions.IgnoreCase);
            bool result = matcher.Matches(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(_exactMatch, false)]
        [InlineData(_mixedCaseMatch, false)]
        [InlineData(_whitespaceMatch, true)]
        [InlineData(_whitespaceMixedCaseMatch, true)]
        [InlineData(_noMatch, false)]
        public void Matches_SpecifiedRegex(string input, bool expected)
        {
            Regex regex = new Regex(_pattern, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
            StringMatcher matcher = StringMatch.Regex(regex);
            bool result = matcher.Matches(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Matches_NullReturnsFalse()
        {
            StringMatcher matcher = StringMatch.Regex(_pattern);
            bool result = matcher.Matches(null);
            Assert.False(result);
        }
    }
}
