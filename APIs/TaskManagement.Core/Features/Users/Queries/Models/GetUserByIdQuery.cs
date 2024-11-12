using MediatR;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Responses.Users.Queries;

namespace TaskManagement.Core.Features.Users.Queries.Models
{
    public class GetUserByIdQuery : IRequest<NewResponse<GetUserByUsernameResponse>>
    {
        public int Id { get; set; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
