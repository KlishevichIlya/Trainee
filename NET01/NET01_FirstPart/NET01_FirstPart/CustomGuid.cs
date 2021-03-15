using System;

namespace NET01_FirstPart
{
    public static class CustomGuid
    {
        public static void NewGuid(this Entity entity)
        {
            if (entity == null)
                throw new ArgumentException("Object reference is null");
            else
                entity.Id = Guid.NewGuid();
        }
    }
}
