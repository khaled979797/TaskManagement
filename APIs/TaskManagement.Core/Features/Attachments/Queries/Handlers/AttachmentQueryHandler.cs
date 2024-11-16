using AutoMapper;
using MediatR;
using TaskManagement.Core.Features.Attachments.Queries.Models;
using TaskManagement.Core.Helpers;
using TaskManagement.Data.Responses.Attachments.Queries;
using TaskManagement.Service.Interfaces;

namespace TaskManagement.Core.Features.Attachments.Queries.Handlers
{
    public class AttachmentQueryHandler : ResponseHandler,
        IRequestHandler<GetAttachmentsQuery, NewResponse<List<GetAttachmentsResponse>>>,
        IRequestHandler<GetAttachmentByIdQuery, NewResponse<GetAttachmentByIdResponse>>
    {
        private readonly IAttachmentRepository attachmentRepository;
        private readonly IMapper mapper;

        public AttachmentQueryHandler(IAttachmentRepository attachmentRepository, IMapper mapper)
        {
            this.attachmentRepository = attachmentRepository;
            this.mapper = mapper;
        }
        public async Task<NewResponse<List<GetAttachmentsResponse>>> Handle(GetAttachmentsQuery request, CancellationToken cancellationToken)
        {
            var attachments = await attachmentRepository.GetAllAttachments();
            if (attachments is null) return NotFound<List<GetAttachmentsResponse>>();
            var attachmentsMapper = mapper.Map<List<GetAttachmentsResponse>>(attachments);
            return Success(attachmentsMapper);
        }

        public async Task<NewResponse<GetAttachmentByIdResponse>> Handle(GetAttachmentByIdQuery request, CancellationToken cancellationToken)
        {
            var attachment = await attachmentRepository.GetAttachmentById(request.Id);
            if (attachment is null) return NotFound<GetAttachmentByIdResponse>();
            var attachmentMapper = mapper.Map<GetAttachmentByIdResponse>(attachment);
            return Success(attachmentMapper);
        }
    }
}
