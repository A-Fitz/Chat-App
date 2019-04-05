﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Interfaces
{
    public interface IServerConnection
    {
        int Read([In, Out] byte[] buffer, int offset, int size);
        void Write(byte[] buffer, int offset, int size);
        char ReadByte();
        bool DataAvailable { get; }
    }
}
