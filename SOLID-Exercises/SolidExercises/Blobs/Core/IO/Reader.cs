﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blobs.Interfaces;

namespace Blobs.Core.IO
{
    public class Reader:IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
