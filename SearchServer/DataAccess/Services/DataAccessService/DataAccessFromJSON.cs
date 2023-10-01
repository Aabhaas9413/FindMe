using System.Text.Json;
using DataAccess.Common.Interface;

namespace DataAccess.Services.SearchDataAccess
{
    public class DataAccessFromJSON<T> : IGetData<T>
    {
        private T? cachedData { get; set; }

        public async Task<T?> GetData(string? path)
        {
            try
            {
                if (cachedData == null)
                {
                    string jsonData = await File.ReadAllTextAsync(path);

                    cachedData = JsonSerializer.Deserialize<T>(jsonData);
                }
                return cachedData;
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"File '{path}' not found.");
                throw ex;
            }
        }

    }
}
