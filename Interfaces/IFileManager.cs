namespace Practical_Lesson.Interfaces
{
    public interface IFileManager
    {
        List<IFruit> ImportFruits(string filePath);
        void ExportFruits(List<IFruit> fruits, string filePath);
    }
}
