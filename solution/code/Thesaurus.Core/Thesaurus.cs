namespace Thesaurus.Core;

/// <summary>
/// Represents a thesaurus.
/// </summary>
/// <param name="thesaurusRepository">
/// Repository where all the words are stored.
/// </param>
public class Thesaurus(IThesaurusRepository thesaurusRepository) : IThesaurus
{
    private readonly IThesaurusRepository repository = thesaurusRepository;

    /// <summary>
    /// Adds the given synonyms to the thesaurus
    /// </summary>
    /// <param name="synonyms"></param>
    /// <exception cref="ArgumentNullException">
    /// If <see cref="synonyms"/> is null.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// If the content of <see cref="synonyms"/> is invalid.
    /// </exception>
    public void AddSynonyms(IEnumerable<string> synonyms)
    {
        ArgumentNullException.ThrowIfNull(synonyms);
        if (synonyms.Count() < 2 || synonyms.Any(word => word is null))
            throw new ArgumentException(null, nameof(synonyms));
        repository.AddSynonyms(synonyms);
    }

    /// <summary>
    /// Gets the synonyms for a given word.
    /// </summary>
    /// <param name="word"></param>
    /// <returns>All synonyms for the given word, if any.</returns>
    /// <exception cref="ArgumentNullException">
    /// If <see cref="word"/> is null.
    /// </exception>
    public IEnumerable<string> GetSynonyms(string word)
    {
        ArgumentNullException.ThrowIfNull(word);
        return repository.ReadSynonymsFor(word);
    }

    /// <inheritdoc/>
    public IEnumerable<string> GetWords() =>
        repository.ReadAllWords();
}
