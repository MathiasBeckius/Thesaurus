using Thesaurus;

namespace InMemoryThesaurus.Tests;

[TestClass]
public sealed class Synonyms_can_be_read_in_ascending_order
{
    private IThesaurus thesaurus;

    [TestInitialize]
    public void Initialize() =>
        thesaurus = Thesaurus.Create();

    [TestMethod]
    public void If_synonyms_are_added_in_another_order()
    {
        thesaurus.AddSynonyms(["vehicle", "car", "automobile"]);
        Assert.IsTrue(thesaurus.GetSynonyms("car").SequenceEqual(["automobile", "vehicle"]));
        Assert.IsTrue(thesaurus.GetSynonyms("automobile").SequenceEqual(["car", "vehicle"]));
        Assert.IsTrue(thesaurus.GetSynonyms("vehicle").SequenceEqual(["automobile", "car"]));
    }
}
