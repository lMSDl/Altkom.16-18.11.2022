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
using System.Text.Json;
using System.Text.Json.Serialization;
using WebApi.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    /*.AddJsonOptions(x =>
    {
        x.JsonSerializerOptions.IgnoreReadOnlyProperties = true;
        x.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault;
        x.JsonSerializerOptions.NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowNamedFloatingPointLiterals;
        x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    })*/
    .AddNewtonsoftJson(x =>
    {
        x.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
        x.SerializerSettings.DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore;
        x.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
        //x.SerializerSettings.DateFormatString = "yyy MM-d _ ff: ss;mm";
    });


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

builder.Services.AddScoped<ConsoleLogFilter>();
builder.Services.AddSingleton(x => new LimiterFilter(5));
builder.Services.AddScoped<UniqueUserFilter>();




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