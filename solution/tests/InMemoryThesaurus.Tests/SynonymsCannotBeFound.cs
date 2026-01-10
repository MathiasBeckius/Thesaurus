using Thesaurus;

namespace InMemoryThesaurus.Tests;

[TestClass]
public sealed class Synonyms_cannot_be_found
{
    private IThesaurus thesaurus;

    [TestInitialize]
    public void Initialize() =>
        thesaurus = Thesaurus.Create();

    [TestMethod]
    public void If_no_words_have_been_added() =>
        Assert.IsFalse(thesaurus.GetSynonyms("foobar").Any());

    [TestMethod]
    public void If_the_word_has_not_been_added_to_the_thesaurus()
    {
        thesaurus.AddSynonyms(["foo", "bar"]);
        Assert.IsFalse(thesaurus.GetSynonyms("foobar").Any());
    }
}
