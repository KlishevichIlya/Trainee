using System;
using System.Collections.Generic;
using System.Text;

namespace NET01_FirstPart
{
    public class TextMaterial : TrainingMaterial
    {
        public string Text;


        public TextMaterial(Guid guid, string desc, string text) 
            : base(desc)
        {
            Id = guid;
            try
            {
                if (text.Length > 10000)
                {
                    throw new Exception("Length field is more than 10000 symbols.");
                }
                Text = text;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error : {ex.Message}");
            }
         
            
        }
        public TextMaterial()
        {

        }
    }
}
