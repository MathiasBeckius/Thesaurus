using Moq;

namespace Thesaurus.Core.Tests;

[TestClass]
public sealed class Synonyms_can_be_added
{
    private Thesaurus thesaurus;

    [TestInitialize]
    public void Initialize() =>
        thesaurus = new Thesaurus(new Mock<IThesaurusRepository>().Object);

    [TestMethod]
    [DataRow(["thing", "entity"])]
    [DataRow(["car", "automobile", "vehicle"])]
    public void If_synonym_list_contains_at_least_two_words(IEnumerable<string> synonyms) =>
        thesaurus.AddSynonyms(synonyms);
}
