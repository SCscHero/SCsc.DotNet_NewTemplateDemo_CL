
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SCsc_DesignPattern.Prototype
{
    public class SerializeHelper
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static string Serializable(object target)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                //TODO:反序列化失效。
                //new BinaryFormatter().Serialize(stream, target);
                //return Convert.ToBase64String(stream.ToArray());
                return null;
            }
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target"></param>
        /// <returns></returns>
        public static T Derializable<T>(string target)
        {
            byte[] targetArray = Convert.FromBase64String(target);
            using (MemoryStream stream = new MemoryStream(targetArray))
            {
                //TODO:反序列化失效。
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                return (T)new BinaryFormatter().Deserialize(stream);
#pragma warning restore SYSLIB0011 // Type or member is obsolete

            }
        }

        public static T DeepClone<T>(T t)
        {
            return Derializable<T>(Serializable(t));
        }
    }
}
