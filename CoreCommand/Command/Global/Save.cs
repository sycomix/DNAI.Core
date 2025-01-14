﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreControl;

namespace CoreCommand.Command.Global
{
    public class Save : ICommand<EmptyReply>
    {
        [BinarySerializer.BinaryFormat]
        public string Filename { get; set; }

        public EmptyReply Resolve(Controller controller)
        {
            controller.SaveTo(Filename);
            return null;
        }
    }
}
