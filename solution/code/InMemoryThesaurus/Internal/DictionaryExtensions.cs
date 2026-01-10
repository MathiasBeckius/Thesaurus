namespace InMemoryThesaurus.Internal;

internal static class DictionaryExtensions
{
    public static void AddSynonyms(this Dictionary<string, IEnumerable<string>> dictionary, IEnumerable<string> synonyms)
    {
        // Make sure that each word is stored in the dictionary.
        // Each word will have its own list of synonyms.
        foreach (var word in synonyms)
            dictionary.AddSynonyms(word, synonyms.Except(word));
    }

    public static IEnumerable<string> ReadSynonymsFor(this Dictionary<string, IEnumerable<string>> dictionary, string word) =>
        dictionary.TryGetValue(word.ToLowerCase(), out var synonyms) ? synonyms : [];

    public static IEnumerable<string> ReadAllWords(this Dictionary<string, IEnumerable<string>> dictionary) =>
        dictionary
            // Since all the words should be preserved as they were provided to the dictionary,
            // we must aggregate the list of words from the dictionary's "values", i.e. lists
            // of synonyms for each added word.
            .SelectMany(x => x.Value)
            // Remove duplicate synonyms in the final list (case-sensitive check)
            .Distinct();

    private static void AddSynonyms(this Dictionary<string, IEnumerable<string>> dictionary, string word, IEnumerable<string> synonyms)
    {
        var currentSynonymsForWord = dictionary
            .ReadSynonymsFor(word)
            // Append synonyms to existing ones (if any).
            .Concat(synonyms);
        dictionary[word.ToLowerCase()] = currentSynonymsForWord;
    }

    private static string ToLowerCase(this string word) =>
        word.ToLowerInvariant();

    private static IEnumerable<string> Except(this IEnumerable<string> synonyms, string synonym) =>
        synonyms.Where(word => !word.Equals(synonym));
}