using System;
using System.Collections.Generic;


namespace NET01_FirstPart
{
    public class TrainingLesson : Entity, IVersionable, ICloneable
    {
        public List<TrainingMaterial> TrainingMaterials = new List<TrainingMaterial>();

        private byte[] version = new byte[8] { 0, 0, 0, 0, 0, 0, 0, 0 };

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
                if (item is VideoMaterial)
                    return TypeLesson.VideoLesson;
            }
            return TypeLesson.TextLesson;
        }

        public byte[] GetVersion()
        {
            byte[] result = new byte[version.Length];
            for (int i = 0; i < version.Length; i++)
            {
                result[i] = version[i];
            }
            return result;
        }

        public void SetVersion(params byte[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                version[i] = numbers[i];
            }
        }

        public object Clone()
        {
            var copy = new List<TrainingMaterial>();
            byte[] ver = new byte[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
            foreach (var el in TrainingMaterials)
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
