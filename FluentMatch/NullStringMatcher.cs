namespace FluentMatch
{
    /// <summary>
    /// A <see cref="StringMatcher" /> implementation that matches an input
    /// based on whether or not it is null.
    /// </summary>
    internal sealed class NullStringMatcher : StringMatcher
    {
        private readonly bool _matchesIfNull;

        /// <summary>
        /// Initializes a new instance of the <see cref="NullStringMatcher" /> class.
        /// </summary>
        /// <param name="matchesIfNull">if set to <c>true</c> match only null strings; otherwise, match only non-null strings.</param>
        public NullStringMatcher(bool matchesIfNull)
        {
            _matchesIfNull = matchesIfNull;
        }

        /// <summary>
        /// Determines whether this <see cref="StringMatcher" /> matches the specified
        /// input string based on its value and configuration.
        /// </summary>
        /// <param name="input">The <see cref="string" /> input to test.</param>
        /// <returns><c>true</c> if this instance matches the specified input string; otherwise, <c>false</c>.</returns>
        public override bool Matches(string input)
        {
            return (input is null) == _matchesIfNull;
        }
    }
}
