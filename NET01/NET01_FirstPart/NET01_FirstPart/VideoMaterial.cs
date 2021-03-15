using System;

namespace NET01_FirstPart
{
    public enum TypeVideo
    {
        Unknow,
        Avi,
        Mp4,
        Flv
    }

    public class VideoMaterial : TrainingMaterial, IVersionable, ICloneable
    {
        public string VideoURI { get; set; }

        public string ImageURI { get; set; }

        private byte[] version = new byte[8] { 0, 0, 0, 0, 0, 0, 0, 0 };

        public VideoMaterial(Guid guid, string desc, string VideoURI, string ImageURI)
            : base(desc)
        {
            Id = guid;
            this.VideoURI = VideoURI;
            this.ImageURI = ImageURI;
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
                ImageURI = ImageURI,
                VideoURI = VideoURI
            };
        }
    }
}
