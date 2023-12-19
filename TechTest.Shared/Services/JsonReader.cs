using TechTest.Shared.Interface;

namespace TechTest.Shared.Services
{
    public class JsonReader : IReader
    {
        public string ReadFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath);
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
