using NUnit.Framework;

namespace SCscCL_NUnitTest
{
    [TestFixture]
    public class AssertUnitTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test()
        {
            Assert.That(12, Is.EqualTo(12));
        }
    }
}
