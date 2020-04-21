using System;

namespace DotNetUtils.FluentMatch
{
    /// <summary>
    /// A <see cref="StringMatcher" /> implementation that matches an input
    /// based on a consumer-specified predicate function.
    /// </summary>
    internal sealed class PredicateStringMatcher : StringMatcher
    {
        private readonly Func<string, bool> _predicate;

        /// <summary>
        /// Initializes a new instance of the <see cref="PredicateStringMatcher" /> class.
        /// </summary>
        /// <param name="predicate">The predicate to use for matching strings.</param>
        /// <exception cref="ArgumentNullException"><paramref name="predicate" /> is null.</exception>
        public PredicateStringMatcher(Func<string, bool> predicate)
        {
            _predicate = predicate ?? throw new ArgumentNullException(nameof(predicate));
        }

        /// <summary>
        /// Determines whether this <see cref="StringMatcher" /> matches the specified
        /// input string based on its value and configuration.
        /// </summary>
        /// <param name="input">The <see cref="string" /> input to test.</param>
        /// <returns><c>true</c> if this instance matches the specified input string; otherwise, <c>false</c>.</returns>
        public override bool Matches(string input)
        {
            return _predicate(input);
        }
    }
}
