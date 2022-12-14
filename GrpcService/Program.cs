using GrpcService.Services;
using Models;
using Services;
using Services.Fakers;
using Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton<ICrudService<User>, CrudService<User>>();
builder.Services.AddTransient<BaseFaker<User>, UserFaker>();

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGrpcService<UsersService>();
app.MapGrpcService<StreamService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
