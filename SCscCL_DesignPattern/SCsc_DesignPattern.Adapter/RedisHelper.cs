using System;
using System.Collections.Generic;
using System.Text;

namespace SCsc_DesignPattern.Adapter
{
    /// <summary>
    /// 第三方提供的 OpenStack ServiceStack（不能修改）
    /// </summary>
    public class RedisHelper
    {
        public void AddRedis<T>()
        {

        }

        public void DeleteRedis<T>()
        {
            throw new NotImplementedException();
        }

        public void QueryRedis<T>()
        {
            throw new NotImplementedException();
        }

        public void UpdateRedis<T>()
        {
            throw new NotImplementedException();
        }
    }
}
