using System.IO;
using System.Text.Json;

namespace LabbBlazor
{
    public class SampleDataAccess : IDataAccess
    {
        public async Task<IEnumerable<User>> GetUsersAsync() => await GetDataAsync<User>("SampleData/user-sample-data.json");
        public async Task<IEnumerable<ToDo>> GetToDosAsync() => await GetDataAsync<ToDo>("SampleData/todo-sample-data.json");
        private async Task<IEnumerable<T>> GetDataAsync<T>(string path)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            try
            {
                using FileStream filestream = File.OpenRead(path);
                var result = await JsonSerializer.DeserializeAsync<IEnumerable<T>>(filestream, options);
                await filestream.DisposeAsync();
                return result ?? throw new ArgumentNullException();
            }
            catch
            {
                throw;
            }
        }
    }
}
