# FluentMatch

FluentMatch is a simple .NET library for string comparison and matching using a fluent syntax.

## Getting Started

FluentMatch represents a string matching rule with the `StringMatcher` class.  To create a `StringMatcher`, use one of the static methods available on the `StringMatch` class:

```C#
StringMatcher dogMatcher = StringMatch.Equals("dog");
```

The `StringMatcher` can then be used to test strings with the `Matches` method:

```C#
bool dogMatches = dogMatcher.Matches("dog");  // returns true
bool catMatches = dogMatcher.Matches("cat");  // returns false
```

`StringMatcher` can also operate on collections of strings:

```C#
string[] pets = new[] { "dog", "cat", "bird" };
bool hasDog = dogMatcher.MatchesAny(pets);    // returns true
bool onlyDogs = dogMatcher.MatchesAll(pets);  // returns false
```

FluentMatch includes a variety of string matching rules and options:

```C#
StringMatch.Contains("dog", StringComparison.Ordinal);
StringMatch.IsNotNullOrEmpty();
StringMatch.Regex(@"^[A-Z]{3} \d{3}$");
```


## Complex Scenarios

FluentMatch provides options for combining multiple string matchers to create complex rules:

```C#
// Match any string containing either "dog" or "cat"
StringMatch.Contains("dog").Or(StringMatch.Contains("cat"));

// Match strings with specified start and end
StringMatch.StartsWith("a").And(StringMatch.EndsWith("z"));
```

`StringMatcher` can also be configured to apply a transformation to input strings before testing:

```C#
StringMatcher matcher = StringMatch.Equals("abc").WithTransform(n => n.Trim());
bool result = matcher.Matches("  abc ");  // returns true
```

## Custom Matching Logic

If the built-in matching rules do not cover your use case, you can create a `StringMatcher` based on a delegate:

```C#
StringMatcher threeCharacters = StringMatch.Where(n => n.Length == 3);
```

You can also define matching logic by creating a custom `StringMatcher` class.

```C#
class ProductKeyMatcher : StringMatcher
{
    public override bool Matches(string input)
    {
        return input.StartsWith("PN-") && input.Skip(3).All(n => char.IsDigit(n));
    }
}

/* snip */

StringMatcher productKeyMatcher = new ProductKeyMatcher();
bool valid = productKeyMatcher.Matches("PN-1234");
```
