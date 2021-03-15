using System;
using System.Collections.Generic;
using System.Text;

namespace NET01_FirstPart
{
    public class TextMaterial : TrainingMaterial, ICloneable
    {
        private string text;
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                if(value.Length > 10000)
                {
                    throw new Exception("Text is too long. You can write less than 10000 symbols.");
                }
                text = value;
            }
        }

        public TextMaterial(Guid guid, string desc, string text) 
            : base(desc)
        {
            Id = guid;
            Text = text;           
        }

        public TextMaterial()
        {

        }

        public override object Clone()
        {
            return new TextMaterial
            {
                Description = Description,
                Text = Text
            };

        }
    }
}
