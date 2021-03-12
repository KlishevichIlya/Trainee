using System;
using System.Collections.Generic;
using System.Text;

namespace NET01_FirstPart
{
    class VideoMaterial : TrainingMaterial, IVersionable
    {
        
        public string URL;

        public string URI;

        public byte[] version = new byte[8] {0,0,0,0,0,0,0,0};

        public enum TypeVideo : byte
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

        public void GetVersion()
        {
            for (int i = 0; i < version.Length; i++)
            {
                Console.Write(version[i] + " ");
            }
            Console.WriteLine();
        }

        public void SetVersion(params byte[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                version[i] = numbers[i];
            }
        }
    }
}
