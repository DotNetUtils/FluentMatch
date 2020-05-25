using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace FluentMatch.Tests
{
    public sealed class StringMatchTests
    {
        public static IEnumerable<object[]> GetGeneratorMethods()
        {
            List<Func<string, StringMatcher>> generators = new List<Func<string, StringMatcher>>
            {
                n => StringMatch.Equals(n),
                n => StringMatch.Equals(n, StringComparison.Ordinal),
                n => StringMatch.Contains(n),
                n => StringMatch.Contains(n, StringComparison.Ordinal),
                n => StringMatch.StartsWith(n),
                n => StringMatch.StartsWith(n, StringComparison.Ordinal),
                n => StringMatch.EndsWith(n),
                n => StringMatch.EndsWith(n, StringComparison.Ordinal),
                n => StringMatch.Regex(n),
                n => StringMatch.Regex(n, RegexOptions.None),
                n => StringMatch.Regex(null as Regex),
                n => StringMatch.Where(null)
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
