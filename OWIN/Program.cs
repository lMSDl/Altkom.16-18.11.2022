using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseOwin(pipe => pipe(environment => OwinResponse));



Task OwinResponse(IDictionary<string, object> arg)
{
    var path = arg["owin.RequestPath"];
    string response = $"Hello from OWIN! Your pas was: {path}";
    var resnseByte = Encoding.UTF8.GetBytes(response);

    var headers = (IDictionary<string, string[]>)arg["owin.ResponseHeaders"];

    headers["Content-Length"] = new string[] { resnseByte.Length.ToString() };
    headers["Content-Type"] = new string[] { "text/plain" };

    var stream = (Stream)arg["owin.ResponseBody"];

    return stream.WriteAsync(resnseByte, 0, resnseByte.Length);
}

app.Run();
