using System;
using System.Collections.Generic;
using System.Text;

namespace NET01_FirstPart
{
    interface IVersionable
    {
        void GetVersion();
        void SetVersion(params byte[] numbers);
    }
}
