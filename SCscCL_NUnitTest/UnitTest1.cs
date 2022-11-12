using Moq;
using NUnit.Framework;
using SCscCL_Model;
using System.Security.Cryptography.X509Certificates;

namespace SCscCL_NUnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        /// <summary>
        /// 可以使用Mock创建对象
        /// </summary>
        [Test]
        public void MockTest()
        {
            var mockSimpleObject1 = new Mock<SimpleObject1>() { DefaultValue = DefaultValue.Mock};

            #region Exception fold
            //mockSimpleObject1.Setup(x => new SimpleObject1() { Id = It.IsAny<long>() });
            /*
              Message: 
            System.ArgumentException : Unsupported expression: new SimpleObject1() { Id= It.IsAny<long>() }

              Stack Trace: 
            ExpressionExtensions.Split(LambdaExpression expression, Boolean allowNonOverridableLastProperty) line 159
            Mock.SetupRecursive[TSetup](Mock mock, LambdaExpression expression, Func`4 setupLast, Boolean allowNonOverridableLastProperty) line 643
            Mock.Setup(Mock mock, LambdaExpression expression, Condition condition) line 498
            Mock`1.Setup[TResult](Expression`1 expression) line 452
            Tests.MockTest() line 23
             */
            #endregion
            mockSimpleObject1.SetupAllProperties();
            //mockSimpleObject1.Setup(x => x.Id).Returns(300);//可以这样赋值，但前提是得是虚方法属性且有setget访问器。

            var mockSimpleObject2 = new Mock<SimpleObject2>();
            var mockComplexObject = new Mock<ComplexObject>(mockSimpleObject1.Object, mockSimpleObject2.Object);

            mockSimpleObject2.Setup(x => x.Id).Returns(It.IsAny<long>());

            var complexObject = new ComplexObject(mockSimpleObject1.Object, mockSimpleObject2.Object);


            Assert.Pass();
            //Assert.That(complexObject.ProcessEnd(), Is.False);
        }
    }
}