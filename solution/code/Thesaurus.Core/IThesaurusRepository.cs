namespace Thesaurus.Core;

/// <summary>
/// Represents a repository, for storage of a thesaurus' contents.
/// </summary>
public interface IThesaurusRepository
{
    /// <summary>
    /// Add the given synonyms.
    /// </summary>
    /// <param name="synonyms"></param>
    void AddSynonyms(IEnumerable<string> synonyms);

    /// <summary>
    /// Reads the synonyms for a given word.
    /// </summary>
    /// <param name="word"></param>
    /// <returns>All synonyms for the given word, if there are any.</returns>
    IEnumerable<string> ReadSynonymsFor(string word);

    /// <summary>
    /// Reads all words from the repository.
    /// </summary>
    /// <returns></returns>
    IEnumerable<string> ReadAllWords();
}
