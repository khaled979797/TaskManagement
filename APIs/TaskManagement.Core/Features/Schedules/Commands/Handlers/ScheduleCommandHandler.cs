using AutoMapper;
using MediatR;
using TaskManagement.Core.Features.Schedules.Commands.Models;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Models;
using TaskManagement.Service.Interfaces;

namespace TaskManagement.Core.Features.Schedules.Commands.Handlers
{
    public class ScheduleCommandHandler : ResponseHandler,
        IRequestHandler<AddScheduleCommand, NewResponse<string>>,
        IRequestHandler<EditScheduleCommand, NewResponse<string>>,
        IRequestHandler<DeleteScheduleCommand, NewResponse<string>>
    {
        private readonly IScheduleRepository scheduleRepository;
        private readonly IMapper mapper;

        public ScheduleCommandHandler(IScheduleRepository scheduleRepository, IMapper mapper)
        {
            this.scheduleRepository = scheduleRepository;
            this.mapper = mapper;
        }

        public async Task<NewResponse<string>> Handle(AddScheduleCommand request, CancellationToken cancellationToken)
        {
            var scheduleMapper = mapper.Map<Schedule>(request);
            var schedule = await scheduleRepository.AddSchedule(scheduleMapper);
            if (schedule is null) return BadRequest<string>();
            return Success($"Schedule was created with jobId: {schedule.JobId}");
        }

        public async Task<NewResponse<string>> Handle(EditScheduleCommand request, CancellationToken cancellationToken)
        {
            var scheduleMapper = mapper.Map<Schedule>(request);
            var schedule = await scheduleRepository.EditSchedule(scheduleMapper);
            if (schedule is null) return BadRequest<string>();
            return Success("");
        }

        public async Task<NewResponse<string>> Handle(DeleteScheduleCommand request, CancellationToken cancellationToken)
        {
            var result = await scheduleRepository.DeleteScheduleById(request.Id);
            switch (result)
            {
                case "NotFound": return NotFound<string>();
                case "Failed": return BadRequest<string>();
                default: return Deleted<string>();
            }
        }
    }
}
