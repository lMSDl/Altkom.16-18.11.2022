//public class Program
//{
//    public static void Main(string[] args)
//    {

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

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