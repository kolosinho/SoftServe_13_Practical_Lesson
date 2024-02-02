using Practical_Lesson.Interfaces;
using System.Runtime.Serialization;

namespace Practical_Lesson.Fruits
{
    [DataContract]
    public class Fruit : IFruit
    {
        private string _name;
        private string _color;

        [DataMember]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [DataMember]
        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public Fruit(string name, string color)
        {
            _name = name;
            _color = color;
        }

        public virtual void Input()
        {
            try
            {
                Console.Write("Enter citrus name: ");
                Name = Console.ReadLine();
                Console.Write("Enter citrus color: ");
                Color = Console.ReadLine();

            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static Fruit Input(string line)
        {
            var parts = line.Split(", ").Select(part => part.Split(": ").Last()).ToList();

            return new Fruit(parts[1], parts[2]);
        }

        public virtual void Print()
        {
            Console.WriteLine($"Fruit Name: {Name}, Color: {Color}");
        }

        public override string ToString()
        {
            return $"Type: {GetType().Name}, Name: {Name}, Color: {Color}";
        }
    }
}
