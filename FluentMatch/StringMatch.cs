using System;

namespace DotNetUtils.FluentMatch
{
    /// <summary>
    /// Contains methods to construct <see cref="StringMatcher" /> objects.
    /// </summary>
    public static class StringMatch
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringMatcher" /> class
        /// using an ordinal case-insensitive comparison.
        /// </summary>
        /// <param name="value">The value this instance should attempt to match.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
        public static StringMatcher Equals(string value)
        {
            return new StringMatcher(value, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringMatcher" /> class
        /// using the specified <see cref="StringComparison" />.
        /// </summary>
        /// <param name="value">The value this instance should attempt to match.</param>
        /// <param name="comparison">The <see cref="StringComparison" /> to use when matching input strings.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
        public static StringMatcher Equals(string value, StringComparison comparison)
        {
            return new StringMatcher(value, comparison);
        }
    }
}
