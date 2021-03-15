using System;

namespace NET01_FirstPart
{
    public class LinkToSite : TrainingMaterial, ICloneable
    {
        public string ImageURI { get; set; }

        public TypeLink TypeLink { get; set; }

        public LinkToSite(Guid guid, string desc, string ImageURI, TypeLink typeLink)
            : base(desc)
        {
            Id = guid;
            this.ImageURI = ImageURI;
            TypeLink = typeLink;
        }

        public LinkToSite()
        {

        }

        public override object Clone()
        {
            return new LinkToSite
            {
                Description = Description,
                ImageURI = ImageURI,
                TypeLink = TypeLink
            };
        }
    }
}
