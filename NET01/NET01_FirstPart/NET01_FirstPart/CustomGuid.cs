using System;

namespace NET01_FirstPart
{
    public static class CustomGuid
    {
        public static void NewGuid(this Entity entity)
        {
            if (entity == null)
                throw new ArgumentNullException();
            entity.Id = Guid.NewGuid();
        }
    }
}
