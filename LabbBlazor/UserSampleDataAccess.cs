using System.Text.Json;

namespace LabbBlazor
{
    public class UserSampleDataAccess : IDataAccess<User>
    {
        public async Task<IEnumerable<User>> GetDataAsync()
        {
            var path = "SampleData/user-sample-data.json";
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            try
            {
                using FileStream filestream = File.OpenRead(path);
                var result = await JsonSerializer.DeserializeAsync<IEnumerable<User>>(filestream, options);
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
