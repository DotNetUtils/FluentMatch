using System;
using Xunit;

namespace DotNetUtils.FluentMatch.Tests
{
    public sealed class StringMatcherBaseTests
    {
        private sealed class AnyStringMatcher : StringMatcher
        {
            public override bool Matches(string input) => true;
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
