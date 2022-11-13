using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCscCL_NUnitTest
{
    /// <summary>
    /// Demo Reference Link：https://stackoverflow.com/questions/55541912/using-an-app-config-file-with-nunit3-in-a-net-core-console-app
    /// Private TC Note：https://docs.qq.com/sheet/DTVFVVk12Y3FVcUVl?create_type=5&folder=5nPx_100003&from_page=doc_list_new&u%5B0%5D=85d1627fb6be49c9bc5ef65e507be70d&u%5B1%5D=85d1627fb6be49c9bc5ef65e507be70d&u%5B2%5D=85d1627fb6be49c9bc5ef65e507be70d&u%5B3%5D=85d1627fb6be49c9bc5ef65e507be70d&tab=u3m85z&u=3dae509943df4d1e82d5c23d9a0a580b
    /// </summary>
    internal class ReadConfigFileInNUnitTest
    {
        [SetUp]
        public void Setup()
        {
            //1of5:Add a Config
            //2of5:Set the Config file to always copy
            //3of5:Install System.Configuration.ConfigurationManager Nuget package

            //4of5:Rename the App.config file according to the config name printed in the following code.
            var filePath = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).FilePath;
            //5of5:Test whether the connection string can be obtained
            var conn = ConfigurationManager.ConnectionStrings["DbContext"];

        }

        [Test]
        public void Test()
        {

        }
    }
}
