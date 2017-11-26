﻿using CoreControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCommand.Command
{
    [ProtoBuf.ProtoContract]
    public class ChangeVisibility
    {
        [ProtoBuf.ProtoMember(1)]
        public EntityFactory.ENTITY EntityType { get; set; }

        [ProtoBuf.ProtoMember(2)]
        public UInt32 ContainerID { get; set; }

        [ProtoBuf.ProtoMember(3)]
        public string Name { get; set; }

        [ProtoBuf.ProtoMember(4)]
        public EntityFactory.VISIBILITY NewVisi { get; set; }
    }
}
