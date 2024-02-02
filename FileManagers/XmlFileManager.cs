using Practical_Lesson.Fruits;
using Practical_Lesson.Interfaces;
using System.Runtime.Serialization;

public class XmlFileManager : IFileManager
{
    // here you can add another type for new IFruit object
    private readonly List<Type> _availableTypes = new List<Type>()
    {
        typeof(Citrus),
        typeof(Fruit)
    };

    public void ExportFruits(List<IFruit> fruits, string filePath)
    {
        DataContractSerializer serializer = new DataContractSerializer(typeof(List<IFruit>), _availableTypes);

        using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
        {
            serializer.WriteObject(fileStream, fruits);
        }
    }

    public List<IFruit> ImportFruits(string filePath)
    {
        List<IFruit> fruits = new List<IFruit>();

        DataContractSerializer serializer = new DataContractSerializer(typeof(List<IFruit>), _availableTypes);

        using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
        {
            fruits = (List<IFruit>)serializer.ReadObject(fileStream);
        }

        return fruits;
    }
}

