using System;

namespace FluentMatch
{
    /// <summary>
    /// A <see cref="StringMatcher" /> implementation that tests an input against two other string matchers
    /// and matches the input only if it matches both of the others.
    /// </summary>
    internal sealed class AndStringMatcher : StringMatcher
    {
        private readonly StringMatcher _firstStringMatcher;
        private readonly StringMatcher _secondStringMatcher;

        /// <summary>
        /// Initializes a new instance of the <see cref="AndStringMatcher" /> class.
        /// </summary>
        /// <param name="firstStringMatcher">The first <see cref="StringMatcher" /> to check when matching strings.</param>
        /// <param name="secondStringMatcher">The second <see cref="StringMatcher" /> to check when matching strings.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="firstStringMatcher" /> is null.
        /// <para>or</para>
        /// <paramref name="secondStringMatcher" /> is null.
        /// </exception>
        public AndStringMatcher(StringMatcher firstStringMatcher, StringMatcher secondStringMatcher)
        {
            _firstStringMatcher = firstStringMatcher ?? throw new ArgumentNullException(nameof(firstStringMatcher));
            _secondStringMatcher = secondStringMatcher ?? throw new ArgumentNullException(nameof(secondStringMatcher));
        }

        /// <summary>
        /// Determines whether this <see cref="StringMatcher" /> matches the specified
        /// input string based on its value and configuration.
        /// </summary>
        /// <param name="input">The <see cref="string" /> input to test.</param>
        /// <returns><c>true</c> if this instance matches the specified input string; otherwise, <c>false</c>.</returns>
        public override bool Matches(string input)
        {
            return _firstStringMatcher.Matches(input) && _secondStringMatcher.Matches(input);
        }
    }
}
