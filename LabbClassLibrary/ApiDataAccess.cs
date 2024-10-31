using System.Text.Json;
using System.Net.Http.Json;
using System.Net.Http;

namespace LabbClassLibrary
{
    public class ApiDataAccess : IDataAccess
    {
        public async Task<IEnumerable<User>> GetUsersAsync() => await GetDataAsync<User>("https://jsonplaceholder.typicode.com/users");
        public async Task<IEnumerable<ToDo>> GetToDosAsync() => await GetDataAsync<ToDo>("https://jsonplaceholder.typicode.com/todos");
        private async Task<IEnumerable<T>> GetDataAsync<T>(string url)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var httpClient = new HttpClient();

            try
            {              
                var result = await httpClient.GetFromJsonAsync<IEnumerable<T>>(url, options);
                return result ?? throw new ArgumentNullException();
            }
            catch
            {
                throw;
            }
            finally
            {
                httpClient.Dispose();
            }
        }
    }
}
