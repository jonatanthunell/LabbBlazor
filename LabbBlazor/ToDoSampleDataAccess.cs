using System.Text.Json;

namespace LabbBlazor
{
    public class ToDoSampleDataAccess : IDataAccess<ToDo>
    {
        public async Task<IEnumerable<ToDo>> GetDataAsync()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            try
            {
                using FileStream filestream = File.OpenRead("SampleData/todo-sample-data.json");
                var result = await JsonSerializer.DeserializeAsync<IEnumerable<ToDo>>(filestream, options);
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
