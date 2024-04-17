using AutoMapper;
using Entities;
using MediatR;

namespace Business.Features.Auth.Commands.Register
{
    public class RegisterCommand : IRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // bla bla..

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand>
        {
            private readonly IMapper _mapper;

            public RegisterCommandHandler(IMapper mapper)
            {
                _mapper = mapper;
            }

            public Task Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                // Register komutu trigger olduğunda çalışacak fonk.

                User user = _mapper.Map<User>(request);

                // 2:20
                user.PasswordHash = null;
                user.PasswordSalt = null;



                throw new NotImplementedException();
            }
        }
    }
}
