using System;
using System.Collections.Generic;
using System.Linq;

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

        /// <summary>
        /// Determines whether this <see cref="StringMatcher" /> matches any of the specified input strings.
        /// </summary>
        /// <param name="inputs">The collection of input strings to test.</param>
        /// <returns><c>true</c> if this instance matches any of the specified input strings; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="inputs" /> is null.</exception>
        public bool MatchesAny(IEnumerable<string> inputs)
        {
            if (inputs is null)
            {
                throw new ArgumentNullException(nameof(inputs));
            }

            return inputs.Any(n => Matches(n));
        }

        /// <summary>
        /// Determines whether this <see cref="StringMatcher" /> matches all of the specified input strings.
        /// </summary>
        /// <param name="inputs">The collection of input strings to test.</param>
        /// <returns><c>true</c> if this instance matches all of the specified input strings; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="inputs" /> is null.</exception>
        public bool MatchesAll(IEnumerable<string> inputs)
        {
            if (inputs is null)
            {
                throw new ArgumentNullException(nameof(inputs));
            }

            return inputs.All(n => Matches(n));
        }

        /// <summary>
        /// Finds all of the specified input strings that this <see cref="StringMatcher" /> matches.
        /// </summary>
        /// <param name="inputs">The collection of input strings to test.</param>
        /// <returns>A collection containing all the matching input strings.  (This collection uses deferred execution.)</returns>
        /// <exception cref="ArgumentNullException"><paramref name="inputs" /> is null.</exception>
        public IEnumerable<string> FindMatches(IEnumerable<string> inputs)
        {
            if (inputs is null)
            {
                throw new ArgumentNullException(nameof(inputs));
            }

            return inputs.Where(n => Matches(n));
        }

        /// <summary>
        /// Adds an additional <see cref="StringMatcher" /> that must also be satisfied for an input to match.
        /// </summary>
        /// <param name="additionalStringMatcher">The additional <see cref="StringMatcher" /> object.</param>
        /// <exception cref="ArgumentNullException"><paramref name="additionalStringMatcher" /> is null.</exception>
        public StringMatcher And(StringMatcher additionalStringMatcher)
        {
            if (additionalStringMatcher is null)
            {
                throw new ArgumentNullException(nameof(additionalStringMatcher));
            }

            return new AndStringMatcher(this, additionalStringMatcher);
        }

        /// <summary>
        /// Adds an alternate <see cref="StringMatcher" /> that can be satisfied for an input to match.
        /// </summary>
        /// <param name="alternateStringMatcher">The alternate <see cref="StringMatcher" /> object.</param>
        /// <exception cref="ArgumentNullException"><paramref name="alternateStringMatcher" /> is null.</exception>
        public StringMatcher Or(StringMatcher alternateStringMatcher)
        {
            if (alternateStringMatcher is null)
            {
                throw new ArgumentNullException(nameof(alternateStringMatcher));
            }

            return new OrStringMatcher(this, alternateStringMatcher);
        }

        /// <summary>
        /// Defines a transformation function that will be applied to input strings before matching.
        /// </summary>
        /// <param name="transformFunction">The transformation to apply to input strings.</param>
        /// <exception cref="ArgumentNullException"><paramref name="transformFunction" /> is null.</exception>
        public StringMatcher WithTransform(Func<string, string> transformFunction)
        {
            if (transformFunction is null)
            {
                throw new ArgumentNullException(nameof(transformFunction));
            }

            return new TransformStringMatcher(this, transformFunction);
        }
    }
}
