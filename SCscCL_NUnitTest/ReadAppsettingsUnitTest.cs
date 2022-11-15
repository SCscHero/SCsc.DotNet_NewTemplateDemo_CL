using NUnit.Framework;

namespace SCscCL_NUnitTest
{
    [TestFixture]
    public class ReadAppsettingsUnitTest
    {
        private readonly IConfigurationRoot Configuration;

        [SetUp]
        public void Setup()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true);

            Configuration = builder.Build();
        }

        [Test]
        public void Test()
        {
            var connectionStr = Configuration.GetConnectionString(key);
        }
    }
}
