namespace Practical_Lesson.Interfaces
{
    public interface IFruitManager
    {
        List<IFruit> FilterByColor(IFileManager fileManager, string inputFilePath, string color);
        List<IFruit> FilterByColor(List<IFruit> fruits, string color);

        void SortAndExport(List<IFruit> fruits, IFileManager fileManager, string outputFilePath);
        void SortAndExport(IFileManager fileManager, string inputFilePath, string outputFilePath);
    }
}
