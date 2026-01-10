using InMemoryThesaurus.Internal;
using Thesaurus;
using ThesaurusCore = Thesaurus.Core.Thesaurus;

namespace InMemoryThesaurus;

/// <summary>
/// Represents a thesaurus where its contents are stored in memory, not on disc.
/// </summary>
public static class Thesaurus
{
    /// <summary>
    /// Creates an instance of the thesaurus.
    /// </summary>
    /// <returns>An empty thesaurus</returns>
    public static IThesaurus Create() =>
        new ThesaurusCore(new Database());
}
