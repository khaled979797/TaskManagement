using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Core.Features.Users.Queries.Models;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Models;
using TaskManagement.Data.Responses.Users.Queries;
using TaskManagement.Service.Interfaces;

namespace TaskManagement.Core.Features.Users.Queries.Handlers
{
    public class UserQueryHandler : ResponseHandler,
        IRequestHandler<GetUsersQuery, NewResponse<List<GetUsersResponse>>>,
        IRequestHandler<GetUserByIdQuery, NewResponse<GetUserByIdResponse>>
    {
        private readonly IUserRepository userRepository;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        public UserQueryHandler(IUserRepository userRepository, UserManager<User> userManager,
            IMapper mapper)
        {
            this.userRepository = userRepository;
            this.userManager = userManager;
            this.mapper = mapper;
        }
        public async Task<NewResponse<List<GetUsersResponse>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await userManager.Users.ToListAsync();
            if (users is null) return NotFound<List<GetUsersResponse>>();
            var usersMapper = mapper.Map<List<GetUsersResponse>>(users);
            return Success(usersMapper);
        }

        public async Task<NewResponse<GetUserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByIdAsync(request.Id.ToString());
            if (user is null) return NotFound<GetUserByIdResponse>();
            var userMapper = mapper.Map<GetUserByIdResponse>(user);
            return Success(userMapper);
        }
    }
}
