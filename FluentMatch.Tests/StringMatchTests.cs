using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DotNetUtils.FluentMatch.Tests
{
    public sealed class StringMatchTests
    {
        public static IEnumerable<object[]> GetGeneratorMethods()
        {
            List<Func<string, StringMatcher>> generators = new List<Func<string, StringMatcher>>
            {
                n => StringMatch.Equals(n),
                n => StringMatch.Equals(n, StringComparison.Ordinal)
            };

            return generators.Select(n => new object[] { n });
        }

        [Theory]
        [MemberData(nameof(GetGeneratorMethods))]
        public void Generator_EdgeCase_ThrowsArgumentNullException(Func<string, StringMatcher> func)
        {
            void generateStringMatcher() => func(null);
            Assert.Throws<ArgumentNullException>(generateStringMatcher);
        }
    }
}
