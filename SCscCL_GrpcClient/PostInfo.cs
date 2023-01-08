using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCscCL_GrpcClient
{
    /// <summary>
    /// Protobuf格式
    /// </summary>
    [ProtoContract]
    public class PostInfo
    {
        [ProtoMember(1)]
        public long P_ID { get; set; }

        [ProtoMember(2)]
        public string P_Title { get; set; }

        [ProtoMember(3)]
        public string P_Content { get; set; }

        [ProtoMember(4)]
        public string P_CreateTime { get; set; }
    }
}
