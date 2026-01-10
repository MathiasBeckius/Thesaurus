using Thesaurus;

namespace InMemoryThesaurus.Tests;

[TestClass]
public sealed class Thesaurus_is_empty
{
    private IThesaurus thesaurus;

    [TestInitialize]
    public void Initialize() =>
        thesaurus = Thesaurus.Create();

    [TestMethod]
    public void If_no_words_have_been_added() =>
        Assert.IsFalse(thesaurus.GetWords().Any());
}
