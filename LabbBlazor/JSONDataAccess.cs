using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace LabbBlazor
{
    public class JSONDataAccess : IDataAccess
    {
        public List<User> GetUsers()
        {
            List<User> users = new List<User>();

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.UserAgent.ParseAdd("Nothing");

                var response = client.GetAsync("https://jsonplaceholder.typicode.com/users").Result;

                response.EnsureSuccessStatusCode();

                var usersAsJson = response.Content.ReadAsStringAsync();

                users = JsonConvert.DeserializeObject<List<User>>(usersAsJson.Result) ?? users;

                return users;
            }
        }
    }
}
