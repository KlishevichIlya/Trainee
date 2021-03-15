using System;

namespace NET01_FirstPart
{
    public class Entity
    {
        private string description;

        public Guid Id { get; set; }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();
                if (value.Length > 256)
                    throw new ArgumentException("Length description more than 256 symbols");
                description = value;
            }
        }

        public Entity()
        {
            this.NewGuid();
        }

        public override string ToString()
        {
            return Description;
        }

        public override bool Equals(object obj)
        {
            if (obj is TrainingLesson less && less != null)
                return less.Id == this.Id;
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
