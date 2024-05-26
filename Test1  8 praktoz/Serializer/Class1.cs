using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace SerializationLibrary
{
    public static class Serializer
    {
        public static async Task SerializeAsync<T>(T obj, string filePath)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            using (FileStream createStream = File.Create(filePath))
            {
                await JsonSerializer.SerializeAsync(createStream, obj, options);
            }
        }

        public static async Task<T> DeserializeAsync<T>(string filePath)
        {
            using (FileStream openStream = File.OpenRead(filePath))
            {
                return await JsonSerializer.DeserializeAsync<T>(openStream);
            }
        }
    }
}