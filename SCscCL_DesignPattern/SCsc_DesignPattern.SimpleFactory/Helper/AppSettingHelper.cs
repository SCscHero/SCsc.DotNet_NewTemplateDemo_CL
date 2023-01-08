using Microsoft.Extensions.Configuration;
using System.IO;

namespace SCsc_DesignPattern.SimpleFactory.Helper
{
    /// <summary>
    /// 
    /// </summary>
    public class AppSettingHelper
    {
        private static readonly object objLock = new object();
        private static AppSettingHelper instance = null;

        private IConfigurationRoot Config { get; }


        static AppSettingHelper()
        {
            var builder = new ConfigurationBuilder();
        }

        public static AppSettingHelper GetInstance()
        {
            if (instance == null)
            {
                lock (objLock)
                {
                    if (instance == null)
                    {
                        instance = new AppSettingHelper();
                    }
                }
            }

            return instance;
        }


        #region 获取配置文件信息
        /// <summary>
        /// 获取配置文件信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetConfig(string name)
        {
            return GetInstance().Config.GetSection(name).Value;
        }
        #endregion
    }
}
