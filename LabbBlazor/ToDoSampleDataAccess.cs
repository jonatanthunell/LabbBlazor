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

            using FileStream filestream = File.OpenRead("SampleData/user-sample-data.json");
            
            var result = await JsonSerializer.DeserializeAsync<IEnumerable<ToDo>>(filestream, options);
            await filestream.DisposeAsync();
            return result!;
        }
    }
}
