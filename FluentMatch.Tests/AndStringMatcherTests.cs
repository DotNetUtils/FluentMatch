using Xunit;

namespace DotNetUtils.FluentMatch.Tests
{
    public sealed class AndStringMatcherTests
    {
        private const string _startString = "start";
        private const string _middleString = "middle";
        private const string _endString = "end";
        private const string _startAndEndString = "start end";
        private const string _completeString = "start middle end";

        [Theory]
        [InlineData(_startString, false)]
        [InlineData(_middleString, false)]
        [InlineData(_endString, false)]
        [InlineData(_startAndEndString, true)]
        [InlineData(_completeString, true)]
        public void Matches_StartsWithAndEndsWith(string input, bool expected)
        {
            StringMatcher matcher = StringMatch.StartsWith(_startString)
                                               .And(StringMatch.EndsWith(_endString));
            bool result = matcher.Matches(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(_startString, false)]
        [InlineData(_middleString, false)]
        [InlineData(_endString, false)]
        [InlineData(_startAndEndString, false)]
        [InlineData(_completeString, true)]
        public void Matches_StartsWithAndEndsWithAndContains(string input, bool expected)
        {
            StringMatcher matcher = StringMatch.StartsWith(_startString)
                                               .And(StringMatch.EndsWith(_endString))
                                               .And(StringMatch.Contains(_middleString));
            bool result = matcher.Matches(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(_startString, false)]
        [InlineData(_middleString, false)]
        [InlineData(_endString, false)]
        [InlineData(_startAndEndString, false)]
        [InlineData(_completeString, true)]
        public void Matches_StartWithAndEndsWithAndContainsTransitivity(string input, bool expected)
        {
            StringMatcher matcher = StringMatch.StartsWith(_startString)
                                               .And(StringMatch.EndsWith(_endString)
                                                               .And(StringMatch.Contains(_middleString)));
            bool result = matcher.Matches(input);
            Assert.Equal(expected, result);
        }
    }
}
