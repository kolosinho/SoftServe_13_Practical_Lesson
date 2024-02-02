using Newtonsoft.Json;
using Practical_Lesson.Fruits;
using Practical_Lesson.Interfaces;

public class JsonFileManager : IFileManager
{
    public void ExportFruits(List<IFruit> fruits, string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var fruit in fruits)
            {
                string json = JsonConvert.SerializeObject(new
                {
                    Type = fruit.GetType().Name,
                    Data = fruit
                });

                writer.WriteLine(json);
            }
        }
    }

    public List<IFruit> ImportFruits(string filePath)
    {
        List<IFruit> fruits = new List<IFruit>();

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var jsonObject = JsonConvert.DeserializeAnonymousType(line, new
                {
                    Type = "",
                    Data = (object)null
                });

                if (jsonObject != null && !string.IsNullOrEmpty(jsonObject.Type))
                {
                    Type fruitType = Type.GetType(typeof(Fruit).Namespace + "." + jsonObject.Type);
                    var fruitData = JsonConvert.DeserializeObject(jsonObject.Data.ToString(), fruitType);
                    if (fruitData is IFruit fruit)
                    {
                        fruits.Add(fruit);
                    }
                }
            }
        }

        return fruits;
    }
}

