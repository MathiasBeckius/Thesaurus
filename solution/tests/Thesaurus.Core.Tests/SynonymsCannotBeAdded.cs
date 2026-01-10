using Moq;

namespace Thesaurus.Core.Tests;

[TestClass]
public sealed class Synonyms_cannot_be_added
{
    private Thesaurus thesaurus;

    [TestInitialize]
    public void Initialize() =>
        thesaurus = new Thesaurus(new Mock<IThesaurusRepository>().Object);

    [TestMethod]
    public void If_synonym_list_is_null() =>
        Assert.Throws<ArgumentNullException>(() => thesaurus.AddSynonyms(null));

    [TestMethod]
    [DataRow([])]
    [DataRow(["thing"])]
    public void If_synonym_list_contains_less_than_two_words(IEnumerable<string> synonyms) =>
        Assert.Throws<ArgumentException>(() => thesaurus.AddSynonyms(synonyms));

    [TestMethod]
    [DataRow([null, "thing"])]
    [DataRow(["thing", null])]
    [DataRow(["thing", null, "entity"])]
    [DataRow([null, null, null])]
    public void If_one_or_more_words_are_null(IEnumerable<string> synonyms) =>
        Assert.Throws<ArgumentException>(() => thesaurus.AddSynonyms(synonyms));
}
