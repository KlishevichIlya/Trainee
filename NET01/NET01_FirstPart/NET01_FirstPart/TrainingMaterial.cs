using System;

namespace NET01_FirstPart
{
    public abstract class TrainingMaterial : Entity, ICloneable
    {
        public TrainingMaterial(string desc)
        {
            Description = desc;
        }

        public TrainingMaterial()
        {

        }

        public abstract object Clone();

    }
}
