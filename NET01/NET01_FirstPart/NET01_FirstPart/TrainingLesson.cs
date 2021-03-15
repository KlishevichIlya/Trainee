using System;
using System.Collections.Generic;
using System.Text;


namespace NET01_FirstPart
{
    public enum TypeLesson
    {
        VideoLesson,
        TextLesson
    }

    public class TrainingLesson : Entity, IVersionable, ICloneable
    {
        public List<TrainingMaterial> TrainingMaterials = new List<TrainingMaterial>();       

        private byte[] version = new byte[8] { 0, 0, 0, 0, 0, 0, 0, 0 } ;       
        
        public TrainingLesson(Guid guid, string desc)
        {
            Id = guid;            
            Description = desc;              
        }

        public TrainingLesson()
        {
            
        }

        public TypeLesson CheckTypeLesson()
        {
            foreach (var item in TrainingMaterials)   
            {
                VideoMaterial videoMaterial = item as VideoMaterial;
                if (videoMaterial != null)
                    return TypeLesson.VideoLesson;

            }
            return TypeLesson.TextLesson;
        }

        public override string ToString()
        {           
             return Description;         
           
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            TrainingLesson lesson = obj as TrainingLesson;
            if (lesson == null)
                return false;
            return lesson.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public byte[] GetVersion()
        {
            byte[] getversion = new byte[version.Length];
            for(int i = 0; i < version.Length; i++)
            {
                getversion[i] = version[i];
            }
            return getversion;           
        }

        public void SetVersion(params byte[] numbers)
        {
            for(int i = 0; i < numbers.Length; i++)
            {
                version[i] = numbers[i];
            }
        }

        public object Clone()
        {          
            var copy = new List<TrainingMaterial>();
            byte[] ver = new byte[8] { 0, 0, 0, 0, 0, 0, 0, 0 };    
            foreach(var el in TrainingMaterials)
            {
                copy.Add((TrainingMaterial)el.Clone());
            }            
            return new TrainingLesson
            {
                Id = Guid.NewGuid(),
                Description = Description,
                TrainingMaterials = copy,
                version = ver
            };
        }
    }
}
