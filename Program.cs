using Practical_Lesson.FruitManagers;
using Practical_Lesson.Fruits;
using Practical_Lesson.Interfaces;
using System.Text.Json.Nodes;

namespace Practical_Lesson
{

    public class Program
    {
        static void Main(string[] args)
        {
            var fruitManager = new FruitManager();

            string inputPath = @"C:\Users\User\Desktop\Practical_lesson_test.txt";
            string txtOutputPath = @"C:\Users\User\Desktop\Export_Practical_lesson_test.txt";
            string jsonOutputPath = @"C:\Users\User\Desktop\Export_Practical_lesson_test.json";
            string xmlOutputPath = @"C:\Users\User\Desktop\Export_Practical_lesson_test.xml";

            Console.WriteLine("TXT import and export:");
            List<IFruit> fruitsFromTxt = fruitManager.FilterByColor(inputPath, "Orange");
            foreach (var fruit in fruitsFromTxt)
            {
                Console.WriteLine(fruit);
            }
            fruitManager.SortAndExport(fruitsFromTxt, txtOutputPath);

            Console.WriteLine("Json export:");
            fruitManager.SortAndExport(fruitsFromTxt, jsonOutputPath);

            Console.WriteLine("Xml export:");
            fruitManager.SortAndExport(fruitsFromTxt, xmlOutputPath);

            Console.WriteLine("Json import:");
            List<IFruit> fruitsFromJson = fruitManager.FilterByColor(jsonOutputPath, "Orange");
            foreach (var fruit in fruitsFromJson)
            {
                Console.WriteLine(fruit);
            }

            Console.WriteLine("Xml import:");
            List<IFruit> fruitsFromXml = fruitManager.FilterByColor(xmlOutputPath, "Orange");
            foreach (var fruit in fruitsFromXml)
            {
                Console.WriteLine(fruit);
            }
        }
    }
}
