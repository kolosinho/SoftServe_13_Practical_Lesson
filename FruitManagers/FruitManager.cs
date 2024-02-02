using Practical_Lesson.FileManagers;
using Practical_Lesson.Interfaces;

namespace Practical_Lesson.FruitManagers
{
    public class FruitManager
    {
        //here you can add new fileExtension
        private IFileManager CreateFileManager(string? filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                string fileExtension = Path.GetExtension(filePath);

                switch (fileExtension)
                {
                    case ".txt":
                        return new TxtFileManager();
                    case ".json":
                        return new JsonFileManager();
                    case ".xml":
                        return new XmlFileManager();
                    default:
                        throw new ArgumentException("Unsupported file extension");
                }
            }
            else
            {
                throw new ArgumentNullException("File path cannot be empty or null");
            }
        }

        public List<IFruit> FilterByColor(List<IFruit>? fruits)
        {
            if (fruits != null && fruits.Count > 0)
            {
                Console.WriteLine("Please enter fruit color:");
                string? color = Console.ReadLine();

                if (string.IsNullOrEmpty(color))
                {
                    throw new ArgumentNullException("color", "Color cannot be empty or null");
                }

                return fruits.Where(fruit => fruit.Color.Equals(color, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else
            {
                throw new ArgumentNullException("Fruits list cannot be empty or null");
            }
        }

        public List<IFruit> FilterByColor(List<IFruit>? fruits, string? color)
        {
            if (fruits != null && fruits.Count > 0 && !string.IsNullOrEmpty(color))
            {
                return fruits.Where(fruit => fruit.Color.Equals(color, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else
            {
                throw new ArgumentNullException("Fruits list or color cannot be empty or null");
            }
        }

        public List<IFruit> FilterByColor(string? inputFilePath)
        {
            if (!string.IsNullOrEmpty(inputFilePath))
            {
                Console.WriteLine("Please enter fruit color:");

                string? color = Console.ReadLine();

                if (!string.IsNullOrEmpty(color))
                {
                    IFileManager fileManager = CreateFileManager(inputFilePath);
                    List<IFruit> fruits = fileManager.ImportFruits(inputFilePath);

                    return fruits.Where(fruit => fruit.Color.Equals(color, StringComparison.OrdinalIgnoreCase)).ToList();
                }
                else
                {
                    throw new ArgumentNullException("Color cannot be empty or null");
                }
            }
            else
            {
                throw new ArgumentNullException("File path cannot be empty or null");
            }
        }

        public List<IFruit> FilterByColor(string? inputFilePath, string? color)
        {
            if (!string.IsNullOrEmpty(inputFilePath) && !string.IsNullOrEmpty(color))
            {
                IFileManager fileManager = CreateFileManager(inputFilePath);
                List<IFruit> fruits = fileManager.ImportFruits(inputFilePath);

                return fruits.Where(fruit => fruit.Color.Equals(color, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else
            {
                throw new ArgumentNullException("File path or color cannot be empty or null");
            }
        }

        public void SortAndExport(List<IFruit>? fruits, string? outputFilePath)
        {
            if (fruits != null && fruits.Count > 0 && !string.IsNullOrEmpty(outputFilePath))
            {
                IFileManager fileManager = CreateFileManager(outputFilePath);

                fruits.OrderBy(fruit => fruit.Name).ToList();

                fileManager.ExportFruits(fruits, outputFilePath);
                Console.WriteLine($"File successfully saved: {outputFilePath}");
            }
            else
            {
                throw new ArgumentNullException("Fruits list or file path cannot be empty or null");
            }
        }

        public void SortAndExport(string? inputFilePath, string? outputFilePath)
        {
            if (!string.IsNullOrEmpty(inputFilePath) && !string.IsNullOrEmpty(outputFilePath))
            {
                IFileManager fileManager = CreateFileManager(outputFilePath);

                List<IFruit> fruits = fileManager.ImportFruits(inputFilePath)
                                                    .OrderBy(fruit => fruit.Name).ToList();

                fileManager.ExportFruits(fruits, outputFilePath);
                Console.WriteLine($"File successfully saved: {outputFilePath}");
            }
            else
            {
                throw new ArgumentNullException("File path cannot be empty or null");
            }
            }
        }
    }
