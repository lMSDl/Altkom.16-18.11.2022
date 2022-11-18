using Grpc.Core;
using GrpcService;
using GrpcService.Protos.Users;
using Services.Interfaces;

namespace GrpcService.Services
{
    public class UsersService : GrpcService.Protos.Users.GrpcUsers.GrpcUsersBase
    {
        private readonly ICrudService<Models.User> _service;

        public UsersService(ICrudService<Models.User> service)
        {
            _service = service;
        }

        public override Task<User> Create(User request, ServerCallContext context)
        {


            return base.Create(request, context);
        }

        public override async Task<User> ReadById(Id request, ServerCallContext context)
        {
            var user = await _service.ReadAsync(request.Value);

            return user != null ? new User { Id = user.Id, Name = user.Name, Password = user.Password } : new User();
        }

        public override async Task<Users> Read(Protos.Users.Void request, ServerCallContext context)
        {
            var users = await _service.ReadAsync();

            var result = new Users();
            result.Collection.AddRange(users.Select(x => new User { Id = x.Id, Name = x.Name, Password = x.Password }));
            return result;
        }

        public override Task<Protos.Users.Void> Delete(Id request, ServerCallContext context)
        {
            return base.Delete(request, context);
        }

        public override Task<Protos.Users.Void> Update(Id request, ServerCallContext context)
        {
            return base.Update(request, context);
        }

    }
}