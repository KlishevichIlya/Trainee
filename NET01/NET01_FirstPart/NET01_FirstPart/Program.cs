using System;

namespace NET01_FirstPart
{
    class Program
    {
        static void Main(string[] args)
        {
            TrainingLesson t1 = new TrainingLesson(Guid.NewGuid(), "desc");
            VideoMaterial v1 = new VideoMaterial(Guid.NewGuid(), "video", "ll", "ll");
            TextMaterial txt = new TextMaterial(Guid.NewGuid(), "text", "asdas");
            LinkToSite link = new LinkToSite(Guid.NewGuid(), "desc", "url", TypeLink.Image);
            t1.TrainingMaterials.Add(v1);
            t1.TrainingMaterials.Add(txt);
            foreach (var i in t1.TrainingMaterials)
            {
                Console.WriteLine(i);
            }

            TrainingLesson t2 = (TrainingLesson)t1.Clone();
            foreach (var i in t2.TrainingMaterials)
            {
                Console.WriteLine(i);
            }


            Console.WriteLine(t1.ToString());

            Console.ReadKey();
        }
    }
}
