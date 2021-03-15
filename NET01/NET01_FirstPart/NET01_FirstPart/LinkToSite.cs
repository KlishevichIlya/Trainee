using System;
using System.Collections.Generic;
using System.Text;

namespace NET01_FirstPart
{
    class LinkToSite : TrainingMaterial, ICloneable
    {       
        public string URI { get; set; }
        public enum TypeLink 
        {
            Unknow,
            Html,
            Image,
            Audio,
            Video
        }

        public LinkToSite(Guid guid, string desc, string URI)
            :base(desc)
        {
            Id = guid;
            this.URI = URI;
        }

        public LinkToSite()
        {

        }

        public override object Clone()
        {
            return new LinkToSite
            {
                Description = Description,
                URI = URI
            };
        }
    }
}
