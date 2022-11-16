//public class Program
//{
//    public static void Main(string[] args)
//    {

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

app.Run();


//    }
//}