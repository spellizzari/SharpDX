using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SharpDX.XInput
{
    partial struct State
    {
        // Required by XInputGetStateEx
        private uint Padding;
    }
}
