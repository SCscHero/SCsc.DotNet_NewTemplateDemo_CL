using System;
using System.Collections.Generic;
using System.Text;

namespace SCsc_DesignPattern.Adapter
{
    /// <summary>
    /// 第三方提供的 OpenStack ServiceStack（不能修改）
    /// </summary>
    public class RedisHelperClassAdapter : IHelper
    {
        private RedisHelper _RedisHelper = new RedisHelper();
        public void Add<T>()
        {
            _RedisHelper.AddRedis<T>();
        }

        public void Delete<T>()
        {
            _RedisHelper.DeleteRedis<T>();
        }

        public void Query<T>()
        {
            _RedisHelper.QueryRedis<T>();
        }

        public void Update<T>()
        {
            _RedisHelper.UpdateRedis<T>();
        }
    }
}
