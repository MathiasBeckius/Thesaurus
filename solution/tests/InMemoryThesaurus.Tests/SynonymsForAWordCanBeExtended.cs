using Thesaurus;

namespace InMemoryThesaurus.Tests;

[TestClass]
public sealed class Synonyms_for_a_word_can_be_extended
{
    private IThesaurus thesaurus;

    [TestInitialize]
    public void Initialize() =>
        thesaurus = Thesaurus.Create();

    [TestMethod]
    public void If_different_synonyms_for_a_word_are_added_at_different_times()
    {
        thesaurus.AddSynonyms(["record", "disc", "audio recording"]);
        Assert.IsTrue(thesaurus.GetSynonyms("record").SequenceEqual(["audio recording", "disc"]));
        thesaurus.AddSynonyms(["record", "achievement"]);
        Assert.IsTrue(thesaurus.GetSynonyms("record").SequenceEqual(["achievement", "audio recording", "disc"]));
    }
}
