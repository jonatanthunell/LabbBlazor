using System.Text.Json;

namespace LabbBlazor
{
    public class UserSampleDataAccess : IDataAccess<User>
    {
        public async Task<IEnumerable<User>> GetDataAsync()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            using FileStream filestream = File.OpenRead("SampleData/user-sample-data.json");
            var result = await JsonSerializer.DeserializeAsync<IEnumerable<User>>(filestream, options);
            await filestream.DisposeAsync();
            return result!; 
        }
    }
}
