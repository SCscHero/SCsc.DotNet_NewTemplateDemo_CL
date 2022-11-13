using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCscCL_NUnitTest
{
    [TestFixture]
    public class MockMethodUnitTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void MockMethod()
        {
            var userIdProviderMock = new Mock<IUserIdProvider>();
            userIdProviderMock.Setup(x => x.GetUserId()).Returns("SpecifiedValue");
            Assert.AreEqual("SpecifiedValue", userIdProviderMock.Object.GetUserId());
        }


        [Test]
        public void MockMethodWithParam()
        {
            var repositoryMock = new Mock<IRepository>();
            //It.IsAny来匹配任意类型的值
            repositoryMock.Setup(x => x.Delete(It.IsAny<int>()))
                .Returns(true);
            //It.Is来匹配Lambda条件的值
            repositoryMock.Setup(x => x.GetById(It.Is<int>(r => r > 0)))
                .Returns((int id) => new TestResModel()
                {
                    Id = id
                });

            var service = new TestService(repositoryMock.Object);
            var deleted = service.Delete(new TestResModel());
            Assert.True(deleted);

            var result = service.GetById(1);
            Assert.NotNull(result);
            Assert.AreEqual(1, result.Id);

            result = service.GetById(-1);
            Assert.Null(result);

            repositoryMock.Setup(x => x.GetById(It.Is<int>(_ => _ <= 0)))
                .Returns(() => new TestResModel()
                {
                    Id = -1
                });
            result = service.GetById(0);
            Assert.NotNull(result);
            Assert.AreEqual(-1, result.Id);
        }

        [Test]
        public async Task MockAsyncMethod1()
        {
            var repositoryMock = new Mock<IRepository>();

            // Task.FromResult方法
            repositoryMock.Setup(x => x.GetCountAsync())
                .Returns(Task.FromResult(10));
            // ReturnAsync方法
            repositoryMock.Setup(x => x.GetCountAsync())
                .ReturnsAsync(10);
            // Mock Result, start from 4.16方法
            repositoryMock.Setup(x => x.GetCountAsync().Result)
                .Returns(10);

            var service = new TestService(repositoryMock.Object);
            var result = await service.GetCountAsync();

            Assert.True(result > 0);
        }

        [Test]
        public async Task MockAsyncMethod2()
        {
            var repositoryMock = new Mock<IRepository>();
            //This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
            repositoryMock.Setup(x => x.GetCountAsync()).Returns(async () => 10);

            var service = new TestService(repositoryMock.Object);
            var result = await service.GetCountAsync();

            Assert.True(result > 0);
        }

        [Test]
        public void MockGenericType()
        {
            var repositoryMock = new Mock<IRepository>();
            var service = new TestService(repositoryMock.Object);

            repositoryMock.Setup(x => x.GetResult<int>(It.IsAny<string>()))
                .Returns(1);
            Assert.AreEqual(1, service.GetResult(""));

            repositoryMock.Setup(x => x.GetResult<string>(It.IsAny<string>()))
                .Returns("test");
            Assert.AreEqual("test", service.GetResult<string>(""));
        }

        [Test]
        public void MockGenericTypeMatch()
        {
            var repositoryMock = new Mock<IRepository>();
            var service = new TestService(repositoryMock.Object);

            repositoryMock.Setup(m => m.GetNum<It.IsAnyType>())
                .Returns(-1);
            repositoryMock.Setup(m => m.GetNum<It.IsSubtype<TestResModel>>())
                .Returns(0);
            repositoryMock.Setup(m => m.GetNum<string>())
                .Returns(1);
            repositoryMock.Setup(m => m.GetNum<int>())
                .Returns(2);

            Assert.AreEqual(0, service.GetNum<TestResModel>());
            Assert.AreEqual(1, service.GetNum<string>());
            Assert.AreEqual(2, service.GetNum<int>());
            Assert.AreEqual(-1, service.GetNum<byte>());
        }



    }

/// <summary>
/// 
/// </summary>
public interface IUserIdProvider
    {
        public string GetUserId();
    }
    public class TestResModel
    {
        public int Id { get; set; }
    }
    public interface IRepository
    {
        public int Version { get; set; }

        public int GetCount();

        public Task<int> GetCountAsync();

        public TestResModel GetById(int id);

        public List<TestResModel> GetList();

        public TResult GetResult<TResult>(string sql);

        public int GetNum<T>();

        public bool Delete(int id);
    }

    public class TestService
    {
        private readonly IRepository _repository;
        public TestService(IRepository repository)
        {
            _repository = repository;
        }
        internal int Version
        {
            get => _repository.Version;
            set => _repository.Version = value;
        }
        public List<TestResModel> GetList() => _repository.GetList();
        public TResult GetResult<TResult>(string sql) => _repository.GetResult<TResult>(sql);
        public int GetResult(string sql) => _repository.GetResult<int>(sql);
        public int GetNum<T>() => _repository.GetNum<T>();
        public int GetCount() => _repository.GetCount();
        public Task<int> GetCountAsync() => _repository.GetCountAsync();
        public TestResModel GetById(int id) => _repository.GetById(id);
        public bool Delete(TestResModel model) => _repository.Delete(model.Id);
    }
}
