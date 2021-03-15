using System;
using System.Collections.Generic;
using System.Text;

namespace NET01_FirstPart
{
    class VideoMaterial : TrainingMaterial, IVersionable, ICloneable
    {        
        public string URL { get; set; }

        public string URI { get; set; }

        private byte[] version = new byte[8] {0,0,0,0,0,0,0,0};

        public enum TypeVideo
        {
            Unknow,
            Avi,
            Mp4,
            Flv
        }

        public VideoMaterial(Guid guid, string desc, string URL, string URI)
            :base(desc)
        {
            Id = guid;
            this.URL = URL;
            this.URI = URI;
        }
        public VideoMaterial()
            
        {
            
        }

        public byte[] GetVersion()
        {
            byte[] getVersion = new byte[version.Length];
            for (int i = 0; i < version.Length; i++)
            {
                getVersion[i] = version[i];
            }
            return getVersion;
        }

        public void SetVersion(params byte[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                version[i] = numbers[i];
            }
        }

        public override object Clone()
        {
            return new VideoMaterial
            {
                Description = Description,
                URI = URI,
                URL = URL
            };
        }
    }
}
