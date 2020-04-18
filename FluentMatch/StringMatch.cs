using System;
using System.Text.RegularExpressions;

namespace DotNetUtils.FluentMatch
{
    /// <summary>
    /// Contains methods to construct <see cref="StringMatcher" /> objects.
    /// </summary>
    public static class StringMatch
    {
        /// <summary>
        /// Initializes a new <see cref="StringMatcher" /> based on full-string matching
        /// using an ordinal case-insensitive comparison.
        /// </summary>
        /// <param name="value">The value this instance should attempt to match.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
        public static StringMatcher Equals(string value)
        {
            return new EqualsStringMatcher(value, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Initializes a new <see cref="StringMatcher" /> based on full-string matching
        /// using the specified <see cref="StringComparison" />.
        /// </summary>
        /// <param name="value">The value this instance should attempt to match.</param>
        /// <param name="comparison">The <see cref="StringComparison" /> to use when matching input strings.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
        public static StringMatcher Equals(string value, StringComparison comparison)
        {
            return new EqualsStringMatcher(value, comparison);
        }

        /// <summary>
        /// Initializes a new <see cref="StringMatcher" /> based on substring matching
        /// using an ordinal case-insensitive comparison.
        /// </summary>
        /// <param name="value">The value this instance should attempt to match.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
        public static StringMatcher Contains(string value)
        {
            return new ContainsStringMatcher(value, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Initializes a new <see cref="StringMatcher" /> based on substring matching
        /// using the specified <see cref="StringComparison" />.
        /// </summary>
        /// <param name="value">The value this instance should attempt to match.</param>
        /// <param name="comparison">The <see cref="StringComparison" /> to use when matching input strings.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
        public static StringMatcher Contains(string value, StringComparison comparison)
        {
            return new ContainsStringMatcher(value, comparison);
        }

        /// <summary>
        /// Initializes a new <see cref="StringMatcher" /> based on a starting substring
        /// using an ordinal case-insensitive comparison.
        /// </summary>
        /// <param name="value">The value this instance should attempt to match.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
        public static StringMatcher StartsWith(string value)
        {
            return new StartsWithStringMatcher(value, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Initializes a new <see cref="StringMatcher" /> based on a starting substring
        /// using the specified <see cref="StringComparison" />.
        /// </summary>
        /// <param name="value">The value this instance should attempt to match.</param>
        /// <param name="comparison">The <see cref="StringComparison" /> to use when matching input strings.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
        public static StringMatcher StartsWith(string value, StringComparison comparison)
        {
            return new StartsWithStringMatcher(value, comparison);
        }

        /// <summary>
        /// Initializes a new <see cref="StringMatcher" /> based on an ending substring
        /// using an ordinal case-insensitive comparison.
        /// </summary>
        /// <param name="value">The value this instance should attempt to match.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
        public static StringMatcher EndsWith(string value)
        {
            return new EndsWithStringMatcher(value, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Initializes a new <see cref="StringMatcher" /> based on an ending substring
        /// using the specified <see cref="StringComparison" />.
        /// </summary>
        /// <param name="value">The value this instance should attempt to match.</param>
        /// <param name="comparison">The <see cref="StringComparison" /> to use when matching input strings.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
        public static StringMatcher EndsWith(string value, StringComparison comparison)
        {
            return new EndsWithStringMatcher(value, comparison);
        }

        /// <summary>
        /// Initializes a new <see cref="StringMatcher" /> based on a regular expression.
        /// </summary>
        /// <param name="pattern">The regular expression pattern to use for matching strings.</param>
        /// <exception cref="ArgumentException"><paramref name="pattern" /> is not a valid regular expression.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="pattern" /> is null.</exception>
        public static StringMatcher Regex(string pattern)
        {
            Regex regex = new Regex(pattern);
            return new RegexMatcher(regex);
        }

        /// <summary>
        /// Initializes a new <see cref="StringMatcher" /> based on a regular expression.
        /// </summary>
        /// <param name="pattern">The regular expression pattern to use for matching strings.</param>
        /// <param name="options">The <see cref="RegexOptions" /> to use for regular expression testing.</param>
        /// <exception cref="ArgumentException"><paramref name="pattern" /> is not a valid regular expression.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="pattern" /> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="options" /> contains an invalid flag.</exception>
        public static StringMatcher Regex(string pattern, RegexOptions options)
        {
            Regex regex = new Regex(pattern, options);
            return new RegexMatcher(regex);
        }

        /// <summary>
        /// Initializes a new <see cref="StringMatcher" /> based on a regular expression.
        /// </summary>
        /// <param name="regex">The <see cref="System.Text.RegularExpressions.Regex" /> to use for matching strings.</param>
        /// <exception cref="ArgumentNullException"><paramref name="regex" /> is null.</exception>
        public static StringMatcher Regex(Regex regex)
        {
            return new RegexMatcher(regex);
        }
    }
}
