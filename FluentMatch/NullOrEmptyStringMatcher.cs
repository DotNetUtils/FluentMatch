namespace DotNetUtils.FluentMatch
{
    /// <summary>
    /// A <see cref="StringMatcher" /> implementation that matches an input
    /// based on whether or not it is null or empty.
    /// </summary>
    internal sealed class NullOrEmptyStringMatcher : StringMatcher
    {
        private readonly bool _matchesIfNullOrEmpty;

        /// <summary>
        /// Initializes a new instance of the <see cref="NullOrEmptyStringMatcher" /> class.
        /// </summary>
        /// <param name="matchesIfNullOrEmpty">if set to <c>true</c> match only null or empty strings; otherwise, match only non-null and non-empty strings.</param>
        public NullOrEmptyStringMatcher(bool matchesIfNullOrEmpty)
        {
            _matchesIfNullOrEmpty = matchesIfNullOrEmpty;
        }

        /// <summary>
        /// Determines whether this <see cref="StringMatcher" /> matches the specified
        /// input string based on its value and configuration.
        /// </summary>
        /// <param name="input">The <see cref="string" /> input to test.</param>
        /// <returns><c>true</c> if this instance matches the specified input string; otherwise, <c>false</c>.</returns>
        public override bool Matches(string input)
        {
            return string.IsNullOrEmpty(input) == _matchesIfNullOrEmpty;
        }
    }
}
