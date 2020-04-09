using System;

namespace DotNetUtils.FluentMatch
{
    /// <summary>
    /// A <see cref="StringMatcher" /> implementation that matches an input
    /// if it starts with a specific substring.
    /// </summary>
    internal sealed class StartsWithStringMatcher : StringMatcher
    {
        private readonly string _value;
        private readonly StringComparison _comparison;

        /// <summary>
        /// Initializes a new instance of the <see cref="StartsWithStringMatcher" /> class.
        /// </summary>
        /// <param name="value">The value this instance should attempt to match.</param>
        /// <param name="comparison">The <see cref="StringComparison" /> to use when matching input strings.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value" /> is null.</exception>
        public StartsWithStringMatcher(string value, StringComparison comparison)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
            _comparison = comparison;
        }

        /// <summary>
        /// Determines whether this <see cref="StringMatcher" /> matches the specified
        /// input string based on its value and configuration.
        /// </summary>
        /// <param name="input">The <see cref="string" /> input to test.</param>
        /// <returns><c>true</c> if this instance matches the specified input string; otherwise, <c>false</c>.</returns>
        public override bool Matches(string input)
        {
            return input?.StartsWith(_value, _comparison) == true;
        }
    }
}
