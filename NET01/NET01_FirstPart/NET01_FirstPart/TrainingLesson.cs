using System;
using System.Collections.Generic;
using System.Text;


namespace NET01_FirstPart
{
    public class TrainingLesson : IVersionable, ICloneable
    {
        public Guid Id;

        public string Description;

        public List<TrainingMaterial> TrainingMaterials = new List<TrainingMaterial>();

        public byte[] version = new byte[8] {0,0,0,0,0,0,0,0};

        public enum TypeLesson : byte       
        {
            VideoLesson,
            TextLesson
        }
        public TrainingLesson(Guid guid, string desc)
        {
            Id = guid;
            try 
            {
                if(desc.Length > 256)
                {
                    throw new Exception("Length description more than 256 symbols");
                }
                Description = desc;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error : {ex.Message}");
            }
            
        }
        public TrainingLesson()
        {
            this.NewGuidForLesson();
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

        public void GetVersion()
        {
            for(int i=0; i < version.Length; i++)
            {
                Console.Write(version[i] + " ");
            }
            Console.WriteLine();
        }

        public void SetVersion(params byte[] numbers)
        {
            for(int i=0; i < numbers.Length; i++)
            {
                version[i] = numbers[i];
            }
        }

        public object Clone()
        {
            List<TrainingMaterial> materials = new List<TrainingMaterial>();
            byte[] ver = new byte[8] { 0, 0, 0, 0, 0, 0, 0, 0 };

            return new TrainingLesson
            {
                Id = Guid.NewGuid(),
                Description = this.Description,
                TrainingMaterials = materials,
                version = ver

            };
        }
    }
}
