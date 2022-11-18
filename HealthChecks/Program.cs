using HealthChecks.Services;
using HealthChecks.UI.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks()
    .AddCheck<RandomHelath>(nameof(RandomHelath))
    .AddCheck<DirectoryAccessHelath>(nameof(DirectoryAccessHelath))
    .AddSqlServer("Data source=(local)\\SQLEXPRESS;Database=dotnet;Integrated Security=true");

builder.Services.AddHealthChecksUI().AddInMemoryStorage();

var app = builder.Build();

app.MapHealthChecks("/Health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions()
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.MapHealthChecksUI();


app.MapGet("/", () => "Hello World!");

app.Run();
