using System.Text.Json;

namespace LabbBlazor
{
    public class UserApiDataAccess : IDataAccess<User>
    {
        public async Task<IEnumerable<User>> GetDataAsync()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var httpClient = new HttpClient();
            var result = await httpClient.GetFromJsonAsync<IEnumerable<User>>("https://jsonplaceholder.typicode.com/users", options);
            return result!;
        }
    }
}
