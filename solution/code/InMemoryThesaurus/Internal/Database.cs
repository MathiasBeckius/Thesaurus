using Thesaurus.Core;

namespace InMemoryThesaurus.Internal;

internal class Database : IThesaurusRepository
{
    private readonly Dictionary<string, IEnumerable<string>> dictionary = [];

    public void AddSynonyms(IEnumerable<string> synonyms) =>
        dictionary.AddSynonyms(synonyms);

    public IEnumerable<string> ReadSynonymsFor(string word) =>
        dictionary.ReadSynonymsFor(word).Order();

    public IEnumerable<string> ReadAllWords() =>
        dictionary.ReadAllWords().Order();
}