
using Microsoft.AspNetCore.SignalR.Client;
using Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;


var signalR = new HubConnectionBuilder()
    .WithUrl("https://localhost:7027/SignalR/Demo")
    .Build();

//signalR.On<string>("Welcome", x => Console.WriteLine(x));

signalR.On<string>(nameof(Welcome), Welcome);
signalR.On<string>("TextMessage", x => Console.WriteLine(x));



async void Welcome(string message)
{
    Console.WriteLine(message);
    await signalR.SendAsync("SayHelloToOthers", $"Hello my name is {signalR.ConnectionId}");
}

await signalR.StartAsync();

await signalR.SendAsync("JoinToGroup", (DateTime.Now.Second % 3).ToString());


Console.ReadLine();



static async Task WebApiClient()
{
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
}

static async Task OpenApiClient()
{
    var httpClient = new HttpClient();
    var openApiClient = new WebAPI.WebapiService("https://localhost:7027", httpClient);

    var shoppinglistitems = await openApiClient.ShoppingListItemsAllAsync(2);

    Console.WriteLine();
}
