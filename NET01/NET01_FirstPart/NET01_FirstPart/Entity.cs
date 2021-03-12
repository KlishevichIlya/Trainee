using System;
using System.Collections.Generic;
using System.Text;

namespace NET01_FirstPart
{
    public class Entity
    {
        public Guid Id { get; set; }

        private string description; 
        public string Description 
        { 
            get
            {
                return description;
            } 
            set 
            {
                
                if (value.Length > 256)
                {
                    throw new Exception("Length description more than 256 symbols");
                }
                
                description = value;
            }
        
        }
    }
}
