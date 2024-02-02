using Practical_Lesson.Fruits;
using Practical_Lesson.Interfaces;

namespace Practical_Lesson.FileManagers
{
    public class TxtFileManager : IFileManager
    {
        // here you can add another condition for new IFruit object
        private IFruit ParseFruit(StreamReader stream, string line)
        {
            if (line.Contains("Vitamin C"))
            {
                return Citrus.Input(line);
            }
            else
            {
                return Fruit.Input(line);
            }
        }

        public List<IFruit> ImportFruits(string filePath)
        {
            var fruits = new List<IFruit>();

            using (var stream = new StreamReader(filePath))
            {
                while (!stream.EndOfStream)
                {
                    string? line = stream.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                    {
                        var fruit = ParseFruit(stream, line);
                        fruits.Add(fruit);
                    }
                }
            }

            return fruits;
        }

        public void ExportFruits(List<IFruit> fruits, string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                foreach (var fruit in fruits)
                {
                    writer.WriteLine(fruit.ToString());
                }
            }
        }
    }
}
