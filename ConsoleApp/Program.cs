
using Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;
var httpClient = new HttpClient();

httpClient.BaseAddress = new Uri("https://localhost:7027/api/");

httpClient.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));

var response = await httpClient.GetAsync("Users");

/*if(response.StatusCode != System.Net.HttpStatusCode.OK)
{
    return;
}*/

/*if(!response.IsSuccessStatusCode)
{
    return;
}*/

response.EnsureSuccessStatusCode();

var users = await response.Content.ReadFromJsonAsync<IEnumerable<User>>();
Console.WriteLine(await response.Content.ReadAsStringAsync());

var user = new User() { Name = "ala", Password = "123123123." };

response = await httpClient.PostAsJsonAsync("users", user);

response.EnsureSuccessStatusCode();

user = await response.Content.ReadFromJsonAsync<User>();

Console.WriteLine();

response = await httpClient.PostAsJsonAsync("users", user);

response = await httpClient.DeleteAsync($"Users/{user.Id}");

response.EnsureSuccessStatusCode();

response = await httpClient.GetAsync($"Users/{user.Id}");

response.EnsureSuccessStatusCode();
