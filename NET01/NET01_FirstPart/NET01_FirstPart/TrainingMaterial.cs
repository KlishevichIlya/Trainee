using System;
using System.Collections.Generic;
using System.Text;

namespace NET01_FirstPart
{
     public class TrainingMaterial : Entity, ICloneable
     {        
        public TrainingMaterial(string desc)
        {
            Description = desc;
        }

        public TrainingMaterial()
        {
            
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

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public virtual object Clone()
        {
            return new TrainingMaterial
            {
                Description = Description
            };
        }
    }
}
