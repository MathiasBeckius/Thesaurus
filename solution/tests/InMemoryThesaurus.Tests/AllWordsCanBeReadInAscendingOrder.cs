using Thesaurus;

namespace InMemoryThesaurus.Tests;

[TestClass]
public sealed class All_words_can_be_read_in_ascending_order
{
    private IThesaurus thesaurus;

    [TestInitialize]
    public void Initialize() =>
        thesaurus = Thesaurus.Create();

    [TestMethod]
    public void If_synonyms_are_added_in_another_order()
    {
        thesaurus.AddSynonyms(["vehicle", "car", "automobile"]);
        thesaurus.AddSynonyms(["thing", "entity"]);
        var expectedWords = new List<string> { "automobile", "car", "entity", "thing", "vehicle" };
        Assert.IsTrue(thesaurus.GetWords().SequenceEqual(expectedWords));
    }
}
