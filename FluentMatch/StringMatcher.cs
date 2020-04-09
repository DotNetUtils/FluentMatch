namespace DotNetUtils.FluentMatch
{
    /// <summary>
    /// Provides methods for string matching based on implementation-specific logic.
    /// </summary>
    public abstract class StringMatcher
    {
        /// <summary>
        /// Determines whether this <see cref="StringMatcher" /> matches the specified
        /// input string based on its value and configuration.
        /// </summary>
        /// <param name="input">The <see cref="string" /> input to test.</param>
        /// <returns><c>true</c> if this instance matches the specified input string; otherwise, <c>false</c>.</returns>
        public abstract bool Matches(string input);
    }
}
