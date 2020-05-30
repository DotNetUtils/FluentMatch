using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FluentMatch.Tests
{
    public sealed class StringMatcherBaseTests
    {
        private sealed class AnyStringMatcher : StringMatcher
        {
            public override bool Matches(string input) => true;
        }

        [Theory]
        [InlineData(new[] { "abc", "xyz", "123" }, true)]
        [InlineData(new[] { "xyz", "abc", "123" }, true)]
        [InlineData(new[] { "123", "xyz" }, false)]
        [InlineData(new string[0], false)]
        public void MatchesAny(string[] inputs, bool expected)
        {
            StringMatcher matcher = StringMatch.Equals("abc");
            bool result = matcher.MatchesAny(inputs);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new[] { "abc", "abc" }, true)]
        [InlineData(new[] { "abc", "xyz" }, false)]
        [InlineData(new[] { "123", "xyz" }, false)]
        [InlineData(new string[0], true)]
        public void MatchesAll(string[] inputs, bool expected)
        {
            StringMatcher matcher = StringMatch.Equals("abc");
            bool result = matcher.MatchesAll(inputs);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new[] { "abc", "abc" }, 2)]
        [InlineData(new[] { "abc", "xyz" }, 1)]
        [InlineData(new[] { "123", "xyz" }, 0)]
        [InlineData(new string[0], 0)]
        public void FindMatches(string[] inputs, int expectedCount)
        {
            StringMatcher matcher = StringMatch.Equals("abc");
            IEnumerable<string> result = matcher.FindMatches(inputs);
            Assert.Equal(expectedCount, result.Count());
        }

        [Fact]
        public void MatchesAny_ThrowsNullArgumentException()
        {
            static object callMatchesAnyWithNull() => new AnyStringMatcher().MatchesAny(null);
            Assert.Throws<ArgumentNullException>(callMatchesAnyWithNull);
        }

        [Fact]
        public void MatchesAll_ThrowsNullArgumentException()
        {
            static object callMatchesAllWithNull() => new AnyStringMatcher().MatchesAll(null);
            Assert.Throws<ArgumentNullException>(callMatchesAllWithNull);
        }

        [Fact]
        public void FindMatches_ThrowsNullArgumentException()
        {
            static object callFindMatchesWithNull() => new AnyStringMatcher().FindMatches(null);
            Assert.Throws<ArgumentNullException>(callFindMatchesWithNull);
        }

        [Fact]
        public void And_ThrowsNullArgumentException()
        {
            static object callAndWithNull() => new AnyStringMatcher().And(null);
            Assert.Throws<ArgumentNullException>(callAndWithNull);
        }

        [Fact]
        public void Or_ThrowsNullArgumentException()
        {
            static object callOrWithNull() => new AnyStringMatcher().Or(null);
            Assert.Throws<ArgumentNullException>(callOrWithNull);
        }

        [Fact]
        public void WithTransform_ThrowsNullArgumentException()
        {
            static object callWithTransformWithNull() => new AnyStringMatcher().WithTransform(null);
            Assert.Throws<ArgumentNullException>(callWithTransformWithNull);
        }
    }
}
