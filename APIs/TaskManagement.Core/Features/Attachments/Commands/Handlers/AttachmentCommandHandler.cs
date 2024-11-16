using AutoMapper;
using MediatR;
using TaskManagement.Core.Features.Attachments.Commands.Models;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Models;
using TaskManagement.Service.Interfaces;

namespace TaskManagement.Core.Features.Attachments.Commands.Handlers
{
    public class AttachmentCommandHandler : ResponseHandler,
        IRequestHandler<AddAttachmentCommand, NewResponse<string>>,
        IRequestHandler<DeleteAttachmentCommand, NewResponse<string>>
    {
        private readonly IAttachmentRepository attachmentRepository;
        private readonly IMapper mapper;

        public AttachmentCommandHandler(IAttachmentRepository attachmentRepository, IMapper mapper)
        {
            this.attachmentRepository = attachmentRepository;
            this.mapper = mapper;
        }
        public async Task<NewResponse<string>> Handle(AddAttachmentCommand request, CancellationToken cancellationToken)
        {
            var result = await attachmentRepository.AddAttachment(request.File!);
            if (result.Error is not null) return BadRequest<string>(result.Error.Message);

            var attchmentMapper = mapper.Map<Attachment>(request);
            attchmentMapper.FilePath = result.Url.ToString();
            attchmentMapper.PublicId = result.PublicId;

            var attachment = await attachmentRepository.AddAsync(attchmentMapper);
            if (attachment is null) return BadRequest<string>();
            return Success("");
        }

        public async Task<NewResponse<string>> Handle(DeleteAttachmentCommand request, CancellationToken cancellationToken)
        {
            var result = await attachmentRepository.DeleteAttachmentById(request.Id);
            if (result.Error is not null) return BadRequest<string>(result.Error.Message);
            return Deleted<string>();
        }
    }
}
