//public class Program
//{
//    public static void Main(string[] args)
//    {

using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Validators;
using Services;
using Services.Fakers;
using Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//automatyczna rejestracja walidatorów z assembly zawieraj¹cego wskazany typ
builder.Services.AddFluentValidationAutoValidation(/*x => x.RegisterValidatorsFromAssemblyContaining<ShoppingListItemValidator>()*/);

//rêczna rejestracja walidatorów
builder.Services.AddTransient<IValidator<ShoppingListItem>, ShoppingListItemValidator>();


builder.Services.AddSingleton<IShoppingListService, ShoppingListService>();
builder.Services.AddTransient<ShoppingListFaker>();

builder.Services.AddSingleton<ICrudService<User>, CrudService<User>>();
builder.Services.AddTransient<BaseFaker<User>, UserFaker>();
builder.Services.AddSingleton<IShoppingListItemsService, ShoppingListItemService>();
builder.Services.AddTransient<ShoppingListItemFaker>();

//wy³¹czenie automatycznej walidacji modelu
//builder.Services.Configure<ApiBehaviorOptions>(x => x.SuppressModelStateInvalidFilter = true);



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