using System;
using System.Collections.Generic;
using System.Text;

namespace NET01_FirstPart
{
    abstract public class TrainingMaterial
    {
        public Guid Id;
        public string Description { get; private set; }

        public TrainingMaterial(string desc)
        {
            Description = desc;
        }
        public TrainingMaterial()
        {
            this.NewGuidForMaterial();
        }


        public override string ToString()
        {
            return Description;
            
        }


        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            TrainingMaterial material = obj as TrainingMaterial;
            if (material == null)
                return false;
            return material.Id == this.Id;
        }
    }
}
