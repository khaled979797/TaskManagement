using AutoMapper;
using MediatR;
using TaskManagement.Core.Features.Schedules.Queries.Models;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Responses.Schedules.Queries;
using TaskManagement.Service.Interfaces;

namespace TaskManagement.Core.Features.Schedules.Queries.Handlers
{
    public class ScheduleQueryHandler : ResponseHandler,
        IRequestHandler<GetSchedulesQuery, NewResponse<List<GetSchedulesResponse>>>,
        IRequestHandler<GetSchedulesForUserQuery, NewResponse<List<GetSchedulesForUserResponse>>>,
        IRequestHandler<GetScheduleByIdQuery, NewResponse<GetScheduleByIdResponse>>
    {
        private readonly IScheduleRepository scheduleRepository;
        private readonly IMapper mapper;

        public ScheduleQueryHandler(IScheduleRepository scheduleRepository, IMapper mapper)
        {
            this.scheduleRepository = scheduleRepository;
            this.mapper = mapper;
        }

        public async Task<NewResponse<List<GetSchedulesResponse>>> Handle(GetSchedulesQuery request, CancellationToken cancellationToken)
        {
            var schedules = await scheduleRepository.GetAllSchedules();
            if (schedules is null) return NotFound<List<GetSchedulesResponse>>();
            return Success(mapper.Map<List<GetSchedulesResponse>>(schedules));
        }

        public async Task<NewResponse<List<GetSchedulesForUserResponse>>> Handle(GetSchedulesForUserQuery request, CancellationToken cancellationToken)
        {
            var schedules = await scheduleRepository.GetAllSchedulesForUser(request.UserId);
            if (schedules is null) return NotFound<List<GetSchedulesForUserResponse>>();
            return Success(mapper.Map<List<GetSchedulesForUserResponse>>(schedules));
        }

        public async Task<NewResponse<GetScheduleByIdResponse>> Handle(GetScheduleByIdQuery request, CancellationToken cancellationToken)
        {
            var schedule = await scheduleRepository.GetScheduleById(request.Id);
            if (schedule is null) return NotFound<GetScheduleByIdResponse>();
            return Success(mapper.Map<GetScheduleByIdResponse>(schedule));
        }
    }
}
