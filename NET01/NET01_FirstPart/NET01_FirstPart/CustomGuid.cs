using System;
using System.Collections.Generic;
using System.Text;

namespace NET01_FirstPart
{
    public static class CustomGuid 
    {
        public static void NewGuidForLesson(this TrainingLesson item)
        {
             item.Id = Guid.NewGuid();            
        }


        public static void NewGuidForMaterial(this TrainingMaterial material)
        {
            material.Id = Guid.NewGuid();
        }
    }
}
