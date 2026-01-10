using Moq;

namespace Thesaurus.Core.Tests;

[TestClass]
public sealed class Synonyms_cannot_be_read
{
    private Thesaurus thesaurus;

    [TestInitialize]
    public void Initialize() =>
        thesaurus = new Thesaurus(new Mock<IThesaurusRepository>().Object);

    [TestMethod]
    public void If_word_is_null() =>
        Assert.Throws<ArgumentNullException>(() => thesaurus.GetSynonyms(null));
}
