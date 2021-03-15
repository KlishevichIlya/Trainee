using System;
using System.Collections.Generic;
using System.Text;

namespace NET01_FirstPart
{
    public static class CustomGuid 
    {
        public static void NewGuid(this Entity entity)
        {
            if (entity != null)
            {
                entity.Id = Guid.NewGuid();
            }
            else
            {
                throw new Exception("Object reference is null");
            }
        }
    }
}
