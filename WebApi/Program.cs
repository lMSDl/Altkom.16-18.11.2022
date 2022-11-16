//public class Program
//{
//    public static void Main(string[] args)
//    {

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Fakers;
using Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton<IShoppingListService, ShoppingListService>();
builder.Services.AddTransient<ShoppingListFaker>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

//app.UseResponseCaching(); // https://learn.microsoft.com/en-us/aspnet/core/performance/caching/response?view=aspnetcore-6.0

app.Use(async (httpContext, next) =>
{
    Console.WriteLine("Before Use1");
    await next();
    Console.WriteLine("After Use1");
});
app.Use(async (httpContext, next) =>
{
    Console.WriteLine("Before Use2");
    await next();
    Console.WriteLine("After Use2");
});


app.UseAuthorization();

app.MapControllers();

//Minimal API
app.MapGet("/hello", () => "Hi!");
app.MapGet("/sum", /*[Authorize]*/ (int value1, int value2) => value1 + value2);

app.Run();


//    }
//}