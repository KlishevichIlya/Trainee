using System;
using System.Collections.Generic;
using System.Text;

namespace NET01_FirstPart
{
    class LinkToSite : TrainingMaterial
    {
       
        public string URI;
        public enum TypeLink : byte
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
    }
}
