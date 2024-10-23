using DocStats;
using DocStats.Persistence;
using Moq;

namespace DocuStatTest
{
    [TestClass]
    public class UnitTest1
    {
        private Mock<IFileManager> _mock = null!;
        private DocumentStatistics _docStats = null!;

        [TestInitialize]
        public void InitDocuStatTest()
        {
            _mock = new Mock<IFileManager>();
            _docStats = new DocumentStatistics(_mock.Object);
            _mock.Setup(m => m.Load()).Returns("test");
        }

        [TestMethod]
        public void TestMethod1()
        {

            bool FileContentReadyRaised = false;
            bool textStatisticsReadyRaised = false;
            _docStats.FileContentReady += (sender, args) => FileContentReadyRaised = true;
            _docStats.TextStatisticsReady += (sender, args) => textStatisticsReadyRaised = true;
            _docStats.Load();

            Assert.AreEqual("test", _docStats.FileContent);
            Assert.AreNotEqual(_docStats.DistinctWordCount.Count, 0);
            Assert.IsTrue(FileContentReadyRaised);
            Assert.IsTrue(textStatisticsReadyRaised);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMethod2()
        {
            _mock.Setup(m => m.Load()).Throws(new Exception());
            _docStats = new DocumentStatistics(_mock.Object);
            _docStats.Load();
        }

        [TestMethod]
        public void TestMethod3()
        {
            _mock.Setup(m => m.Load()).Returns("");
            _docStats.Load();
            Assert.AreEqual(0, _docStats.DistinctWordCount.Count);
            Assert.AreEqual(0, _docStats.CharacterCount);

            _mock.Setup(m => m.Load()).Returns("432534!@345:");
            _docStats.Load();
            Assert.AreEqual(0, _docStats.DistinctWordCount.Count);
        }

        [TestMethod]
        public void TestMethod4()
        {
            _mock.Setup(m => m.Load()).Returns("test tEst test test2 tst");
            _docStats.Load();
            Assert.AreEqual(4, _docStats.DistinctWordCount["test"]);
        }

        [TestMethod]
        public void TestMethod5()
        {
            _mock.Setup(m => m.Load()).Returns("testtE testtestfe rest");
            _docStats.Load();
            Assert.AreEqual("testtE testtestfe rest".Length, _docStats.CharacterCount);

            _mock.Setup(m => m.Load()).Returns("tes ttE testt estfe rest");
            _docStats.Load();
            Assert.AreEqual("testtEtesttestferest".Length, _docStats.NonWhiteSpaceCharacterCount);

            _mock.Setup(m => m.Load()).Returns("           ");
            _docStats.Load();
            Assert.AreEqual(0, _docStats.NonWhiteSpaceCharacterCount);
        }

    }
}