using System;

namespace NET01_FirstPart
{
    class Program
    {
        static void Main(string[] args)
        {
                  
            
            /////2

            TrainingLesson lesson = new TrainingLesson(Guid.NewGuid(), "This is description for Training Lesson");
            
            VideoMaterial video = new VideoMaterial();
            TextMaterial text = new TextMaterial();
            LinkToSite link = new LinkToSite();

            lesson.TrainingMaterials.Add(video);
            lesson.TrainingMaterials.Add(text);
            lesson.TrainingMaterials.Add(link);

            Console.WriteLine(lesson.CheckTypeLesson());


            /////


            /////3

            Console.WriteLine(lesson.ToString());

            LinkToSite linkTo = new LinkToSite(Guid.NewGuid(), "this is description for Link", "some.link");

            Console.WriteLine(linkTo.ToString());

            ////


            /////4


            TextMaterial textMaterial = new TextMaterial();
            textMaterial.NewGuidForMaterial();
            Console.WriteLine(textMaterial.Id);

            ///


            ///5
            Console.WriteLine(textMaterial.Equals(text));
            ///


            ///6
            video.GetVersion();
            video.SetVersion(3, 6, 2);
            video.GetVersion();
            ///


            ///7

            TrainingLesson lesson2 = (TrainingLesson)lesson.Clone();
            Console.WriteLine(lesson.Id);
            Console.WriteLine(lesson2.Id);

            lesson.GetVersion();
            lesson2.GetVersion();

            lesson.SetVersion(1, 1, 1);
            lesson.GetVersion();
            lesson2.GetVersion();
            ///




            Console.ReadKey();
        }
    }
}
