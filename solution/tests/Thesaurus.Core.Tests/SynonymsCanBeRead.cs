using Moq;

namespace Thesaurus.Core.Tests;

[TestClass]
public sealed class Synonyms_can_be_read
{
    private Thesaurus thesaurus;

    [TestInitialize]
    public void Initialize() =>
        thesaurus = new Thesaurus(new Mock<IThesaurusRepository>().Object);

    [TestMethod]
    public void If_word_is_valid() =>
        // The expectation is that no exceptions are thrown, which makes the test pass!
        thesaurus.GetSynonyms("thing");
}
