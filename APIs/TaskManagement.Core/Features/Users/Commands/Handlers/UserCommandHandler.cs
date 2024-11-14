using AutoMapper;
using MediatR;
using TaskManagement.Core.Features.Users.Commands.Models;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Models;
using TaskManagement.Data.Responses.Users.Commands;
using TaskManagement.Service.Interfaces;

namespace TaskManagement.Core.Features.Users.Commands.Handlers
{
    public class UserCommandHandler : ResponseHandler,
        IRequestHandler<RegisterUserCommand, NewResponse<RegisterUserResponse>>,
        IRequestHandler<LoginUserCommand, NewResponse<LoginUserResponse>>,
        IRequestHandler<EditUserCommand, NewResponse<string>>,
        IRequestHandler<DeleteUserCommand, NewResponse<string>>
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }
        public async Task<NewResponse<RegisterUserResponse>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var userMapper = mapper.Map<User>(request);
            var result = await userRepository.RegisterUser(userMapper, request.Password);
            if (result is not null) return Created(result);
            return BadRequest<RegisterUserResponse>();
        }

        public async Task<NewResponse<LoginUserResponse>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var result = await userRepository.LoginUser(request.UserName, request.Password);
            if (result is null) return Unauthorized<LoginUserResponse>();
            return Success(result!);
        }

        public async Task<NewResponse<string>> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var user = mapper.Map<User>(request);
            var result = await userRepository.EditUser(user);
            switch (result)
            {
                case "NotFound": return NotFound<string>();
                case "Failed": return BadRequest<string>();
                default: return Success("");
            }
        }

        public async Task<NewResponse<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var result = await userRepository.DeleteUser(request.Id);
            switch (result)
            {
                case "NotFound": return NotFound<string>();
                case "Failed": return BadRequest<string>();
                default: return Deleted<string>();
            }
        }
    }
}
