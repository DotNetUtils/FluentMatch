﻿using System;
using Xunit;

namespace DotNetUtils.FluentMatch.Tests
{
    public sealed class EqualsStringMatcherTests
    {
        private const string _testString = "encyclopaedia";
        private const string _testStringUpperCase = "ENCYCLOPAEDIA";
        private const string _testStringMixedCase = "EnCyClOpAeDiA";
        private const string _differentString = "thesaurus";
        private const string _longerString = "encyclopaedia encyclopaedia";
        private const string _cultureEquivalentString = "encyclopædia";
        private const string _cultureEquivalentStringUpperCase = "ENCYCLOPÆDIA";

        [Theory]
        [InlineData(_testString, true)]
        [InlineData(_testStringUpperCase, false)]
        [InlineData(_testStringMixedCase, false)]
        [InlineData(_differentString, false)]
        [InlineData(_longerString, false)]
        [InlineData(_cultureEquivalentString, false)]
        [InlineData(_cultureEquivalentStringUpperCase, false)]
        public void Matches_Ordinal(string input, bool expected)
        {
            StringMatcher matcher = StringMatch.Equals(_testString, StringComparison.Ordinal);
            bool result = matcher.Matches(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(_testString, true)]
        [InlineData(_testStringUpperCase, true)]
        [InlineData(_testStringMixedCase, true)]
        [InlineData(_differentString, false)]
        [InlineData(_longerString, false)]
        [InlineData(_cultureEquivalentString, false)]
        [InlineData(_cultureEquivalentStringUpperCase, false)]
        public void Matches_OrdinalIgnoreCase(string input, bool expected)
        {
            StringMatcher matcher = StringMatch.Equals(_testString, StringComparison.OrdinalIgnoreCase);
            bool result = matcher.Matches(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(_testString, true)]
        [InlineData(_testStringUpperCase, false)]
        [InlineData(_testStringMixedCase, false)]
        [InlineData(_differentString, false)]
        [InlineData(_longerString, false)]
        [InlineData(_cultureEquivalentString, true)]
        [InlineData(_cultureEquivalentStringUpperCase, false)]
        public void Matches_CurrentCulture(string input, bool expected)
        {
            StringMatcher matcher = StringMatch.Equals(_testString, StringComparison.CurrentCulture);
            bool result = matcher.Matches(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(_testString, true)]
        [InlineData(_testStringUpperCase, true)]
        [InlineData(_testStringMixedCase, true)]
        [InlineData(_differentString, false)]
        [InlineData(_longerString, false)]
        [InlineData(_cultureEquivalentString, true)]
        [InlineData(_cultureEquivalentStringUpperCase, true)]
        public void Matches_CurrentCultureIgnoreCase(string input, bool expected)
        {
            StringMatcher matcher = StringMatch.Equals(_testString, StringComparison.CurrentCultureIgnoreCase);
            bool result = matcher.Matches(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Matches_NullReturnsFalse()
        {
            StringMatcher matcher = StringMatch.Equals(_testString);
            bool result = matcher.Matches(null);
            Assert.False(result);
        }
    }
}
