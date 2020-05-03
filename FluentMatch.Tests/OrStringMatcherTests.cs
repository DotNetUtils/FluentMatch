using Xunit;

namespace DotNetUtils.FluentMatch.Tests
{
    public sealed class OrStringMatcherTests
    {
        private const string _startString = "start";
        private const string _middleString = "middle";
        private const string _endString = "end";
        private const string _startAndEndString = "start end";
        private const string _completeString = "start middle end";
        private const string _backwardsString = "end middle start";
        private const string _differentString = "first last";

        [Theory]
        [InlineData(_startString, true)]
        [InlineData(_middleString, false)]
        [InlineData(_endString, true)]
        [InlineData(_startAndEndString, true)]
        [InlineData(_completeString, true)]
        [InlineData(_backwardsString, false)]
        [InlineData(_differentString, false)]
        public void Matches_StartsWithOrEndsWith(string input, bool expected)
        {
            StringMatcher matcher = StringMatch.StartsWith(_startString)
                                               .Or(StringMatch.EndsWith(_endString));
            bool result = matcher.Matches(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(_startString, true)]
        [InlineData(_middleString, true)]
        [InlineData(_endString, true)]
        [InlineData(_startAndEndString, true)]
        [InlineData(_completeString, true)]
        [InlineData(_backwardsString, true)]
        [InlineData(_differentString, false)]
        public void Matches_StartsWithOrEndsWithOrContains(string input, bool expected)
        {
            StringMatcher matcher = StringMatch.StartsWith(_startString)
                                               .Or(StringMatch.EndsWith(_endString))
                                               .Or(StringMatch.Contains(_middleString));
            bool result = matcher.Matches(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(_startString, true)]
        [InlineData(_middleString, true)]
        [InlineData(_endString, true)]
        [InlineData(_startAndEndString, true)]
        [InlineData(_completeString, true)]
        [InlineData(_backwardsString, true)]
        [InlineData(_differentString, false)]
        public void Matches_StartsWithOrEndsWithOrContainsTransitivity(string input, bool expected)
        {
            StringMatcher matcher = StringMatch.StartsWith(_startString)
                                               .Or(StringMatch.EndsWith(_endString)
                                                              .Or(StringMatch.Contains(_middleString)));
            bool result = matcher.Matches(input);
            Assert.Equal(expected, result);
        }
    }
}
