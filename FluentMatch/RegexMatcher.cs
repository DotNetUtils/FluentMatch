using System;
using System.Text.RegularExpressions;

namespace DotNetUtils.FluentMatch
{
    /// <summary>
    /// A <see cref="StringMatcher" /> implementation that matches an input
    /// based on a regular expression.
    /// </summary>
    internal sealed class RegexMatcher : StringMatcher
    {
        private readonly Regex _regex;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegexMatcher" /> class.
        /// </summary>
        /// <param name="regex">The <see cref="Regex" /> to use for matching strings.</param>
        /// <exception cref="ArgumentNullException"><paramref name="regex" /> is null.</exception>
        public RegexMatcher(Regex regex)
        {
            _regex = regex ?? throw new ArgumentNullException(nameof(regex));
        }

        /// <summary>
        /// Determines whether this <see cref="StringMatcher" /> matches the specified
        /// input string based on its value and configuration.
        /// </summary>
        /// <param name="input">The <see cref="string" /> input to test.</param>
        /// <returns><c>true</c> if this instance matches the specified input string; otherwise, <c>false</c>.</returns>
        public override bool Matches(string input)
        {
            return input != null && _regex.IsMatch(input);
        }
    }
}
