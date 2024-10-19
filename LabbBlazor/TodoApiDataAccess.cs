using System.Text.Json;

namespace LabbBlazor
{
    public class TodoApiDataAccess : IDataAccess<ToDo>
    {
        public async Task<IEnumerable<ToDo>> GetDataAsync()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var httpClient = new HttpClient();            
            var result = await httpClient.GetFromJsonAsync<IEnumerable<ToDo>>("https://jsonplaceholder.typicode.com/todos", options);

            return result!;
        }
    }
}
