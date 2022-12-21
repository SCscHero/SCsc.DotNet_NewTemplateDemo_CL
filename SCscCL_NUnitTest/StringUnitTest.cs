using NUnit.Framework;

namespace SCscCL_NUnitTest
{
    [TestFixture]
    public class StringUnitTest
    {
        bool? nullableBool;
        string resString = string.Empty;

        [SetUp]
        public void Setup()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void StringAndnullableBoolJoinTest()
        {
            nullableBool = null;
            resString = "Result：" + nullableBool;
            nullableBool = true;
            resString = "Result：" + nullableBool;
            nullableBool = false;
            resString = "Result：" + nullableBool;
            Assert.That(12, Is.EqualTo(12));
        }
    }
}
