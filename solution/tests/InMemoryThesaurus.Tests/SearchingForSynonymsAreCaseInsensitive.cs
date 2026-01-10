using Thesaurus;

namespace InMemoryThesaurus.Tests;

[TestClass]
public sealed class Searching_for_synonyms_are_case_insensitive
{
    private IThesaurus thesaurus;

    [TestInitialize]
    public void Initialize() =>
        thesaurus = Thesaurus.Create();

    [TestMethod]
    public void If_synonyms_with_different_mixed_case_letters_are_added()
    {
        thesaurus.AddSynonyms(["vehiCle", "CAR", "Automobile"]);
        Assert.IsTrue(thesaurus.GetSynonyms("Car").SequenceEqual(["Automobile", "vehiCle"]));
        Assert.IsTrue(thesaurus.GetSynonyms("autoMobile").SequenceEqual(["CAR", "vehiCle"]));
        Assert.IsTrue(thesaurus.GetSynonyms("VEHICLE").SequenceEqual(["Automobile", "CAR"]));
    }
}
