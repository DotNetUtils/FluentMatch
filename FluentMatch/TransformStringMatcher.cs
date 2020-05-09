using System;

namespace DotNetUtils.FluentMatch
{
    /// <summary>
    /// A <see cref="StringMatcher" /> implementation that applies a transformation function
    /// to an input and then tests the transformed input against a specified string matcher.
    /// </summary>
    internal sealed class TransformStringMatcher : StringMatcher
    {
        private readonly StringMatcher _coreStringMatcher;
        private readonly Func<string, string> _transformFunction;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransformStringMatcher" /> class.
        /// </summary>
        /// <param name="coreStringMatcher">The <see cref="StringMatcher" /> to use after the transform is applied.</param>
        /// <param name="transformFunction">The transformation to apply to the input string before matching.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="coreStringMatcher" /> is null.
        /// <para>or</para>
        /// <paramref name="transformFunction" /> is null.
        /// </exception>
        public TransformStringMatcher(StringMatcher coreStringMatcher, Func<string, string> transformFunction)
        {
            _coreStringMatcher = coreStringMatcher ?? throw new ArgumentNullException(nameof(coreStringMatcher));
            _transformFunction = transformFunction ?? throw new ArgumentNullException(nameof(transformFunction));
        }

        /// <summary>
        /// Determines whether this <see cref="StringMatcher" /> matches the specified
        /// input string based on its value and configuration.
        /// </summary>
        /// <param name="input">The <see cref="string" /> input to test.</param>
        /// <returns><c>true</c> if this instance matches the specified input string; otherwise, <c>false</c>.</returns>
        public override bool Matches(string input)
        {
            string transformedInput = _transformFunction(input);
            return _coreStringMatcher.Matches(transformedInput);
        }
    }
}
