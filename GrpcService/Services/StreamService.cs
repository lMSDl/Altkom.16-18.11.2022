using Grpc.Core;
using GrpcService;
using GrpcService.Protos.Stream;

namespace GrpcService.Services
{
    public class StreamService : GrpcService.Protos.Stream.GrpcStream.GrpcStreamBase
    {

        public override async Task FromServer(Request request, IServerStreamWriter<Response> responseStream, ServerCallContext context)
        {
            foreach (var @char in request.Text)
            {
                await responseStream.WriteAsync(new Response { Text = @char.ToString() });
            }
        }

        public override async Task<Response> ToServer(IAsyncStreamReader<Request> requestStream, ServerCallContext context)
        {
            var response = new Response();
            await foreach(var request in requestStream.ReadAllAsync())
            {
                response.Text += request.Text;
            }

            return response;
        }

        public override async Task FromToServer(IAsyncStreamReader<Request> requestStream, IServerStreamWriter<Response> responseStream, ServerCallContext context)
        {
            await foreach (var request in requestStream.ReadAllAsync())
            {
                await responseStream.WriteAsync(new Response { Text = "-"+request.Text });
            }


        }
    }
}