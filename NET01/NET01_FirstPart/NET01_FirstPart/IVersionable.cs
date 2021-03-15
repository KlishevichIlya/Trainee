using System;
using System.Collections.Generic;
using System.Text;

namespace NET01_FirstPart
{
    interface IVersionable
    {
        byte[] GetVersion();
        void SetVersion(params byte[] numbers);
    }
}
