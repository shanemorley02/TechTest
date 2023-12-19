using TechTest.Shared.Interface;

namespace TechTest.Shared.Services
{
    public class JsonWriter : IWriter
    {
        public void WriteFile(string filePath, string text)
        {
            File.WriteAllText(filePath, text);
        }
    }
}
