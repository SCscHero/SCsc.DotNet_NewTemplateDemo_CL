namespace SCsc_DesignPattern.Adapter
{
    /// <summary>
    /// 第三方提供的 OpenStack ServiceStack（不能修改）
    /// </summary>
    public class RedisHelperObjectAdapter : RedisHelper, IHelper
    {
        public void Add<T>()
        {
            base.AddRedis<T>();
        }

        public void Delete<T>()
        {
            base.DeleteRedis<T>();
        }

        public void Query<T>()
        {
            base.QueryRedis<T>();
        }

        public void Update<T>()
        {
            base.UpdateRedis<T>();
        }
    }
}
