using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.UseWebSockets();
app.MapWhen(context => context.WebSockets.IsWebSocketRequest,  websocketApp =>
{
    websocketApp.Run(async context =>
    {
        var websocket = await context.WebSockets.AcceptWebSocketAsync();
        var helloMessage = Encoding.UTF8.GetBytes("Hello from WebSocket!");

        var arraySegment = new ArraySegment<byte>(helloMessage, 0, helloMessage.Length);
        await websocket.SendAsync(arraySegment, System.Net.WebSockets.WebSocketMessageType.Text, true, CancellationToken.None);

        _ = Task.Run(async () =>
        {
            do
            {
                var message = Encoding.UTF8.GetBytes("Ping");
                await websocket.SendAsync(new ArraySegment<byte>(message), System.Net.WebSockets.WebSocketMessageType.Text, true, CancellationToken.None);
                await Task.Delay(5000);

            } while (!websocket.CloseStatus.HasValue);
        });

        do
        {
            byte[] buffer = new byte[1024];

            try
            {
                var receive = await websocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                await websocket.SendAsync(new ArraySegment<byte>(buffer, 0, receive.Count), receive.MessageType, receive.EndOfMessage, CancellationToken.None);
            }
            catch
            {

            }
        } while (!websocket.CloseStatus.HasValue);
            
        await websocket.CloseAsync(websocket.CloseStatus.Value, websocket.CloseStatusDescription, CancellationToken.None);


    });
});



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
