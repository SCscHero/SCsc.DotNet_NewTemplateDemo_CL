using Moq;
using NUnit.Framework;
using SCscCL_Model;

namespace SCscCL_NUnitTest
{
    [TestFixture]
    public class MockStrictUnitTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void StrictMockTest()
        {
            var mockSimpleObject1 = new Mock<SimpleObject1>(MockBehavior.Strict);
            
            mockSimpleObject1.SetupProperty(x => x.Id);
            //mockSimpleObject1.Setup(x=>x.Id).Returns(200);
            Assert.Pass();
        }
    }
}
