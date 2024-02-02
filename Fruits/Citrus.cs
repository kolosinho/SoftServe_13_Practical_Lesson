using System.Runtime.Serialization;

namespace Practical_Lesson.Fruits
{
    [DataContract]
    public class Citrus : Fruit
    {
        private double _vitaminC;

        [DataMember]
        public double VitaminC
        {
            get { return _vitaminC; }
            set { _vitaminC = value; }
        }

        public Citrus(string name, string color, double vitaminC) : base(name, color)
        {
            Name = name;
            Color = color;
            _vitaminC = vitaminC;
        }

        public override void Input()
        {
            try
            {
                Console.Write("Enter citrus name: ");
                Name = Console.ReadLine();
                Console.Write("Enter citrus color: ");
                Color = Console.ReadLine();
                Console.Write("Enter amount of Vitamin C: ");
                VitaminC = double.Parse(Console.ReadLine());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public new static Citrus Input(string line)
        {
            var parts = line.Split(", ", StringSplitOptions.None).Select(part => part.Split(": ").Last()).ToList();

            return new Citrus(parts[1], parts[2], double.Parse(parts[3]));
        }

        public override void Print()
        {
            Console.WriteLine($"Citrus name: {Name}, Color {Color}, Vitamin C: {VitaminC}");
        }

        public override string ToString()
        {
            return $"Type: {GetType().Name}, Name: {Name}, Color {Color}, Vitamic C: {VitaminC}";
        }
    }
}
